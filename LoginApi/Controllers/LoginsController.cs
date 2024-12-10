using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginApi.Data;
using LoginApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text;
using LoginApi.Healpers;
using LoginApi.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly LoginApiContext _context;

        public ILoginRepository _userRepo { get; }

        public LoginsController(LoginApiContext context,ILoginRepository repo)
        {
            _context = context;
            _userRepo = repo;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Authenticate userobj)
        {
            if (userobj == null)
                return BadRequest();
            //first it will check the user exist or not
            var user = await _context.Login.FirstOrDefaultAsync(x => x.UserName == userobj.UserName || x.Email == userobj.UserName);

            if (user == null)
                return NotFound(new { Message = "User Not Found!" });
            //if user exist then it comes to here and checks the password maches with the encrypted password

            //the logic for encryption is written in the helpers.PasswordHasher.cs

            if (!PasswordHasher.VerifyPassword(userobj.Password, user.Password))
            {
                return BadRequest(new { Message = "Password is Incorrect" });
            }
            user.Token = CreateJwt(user);
            return Ok(new
            {
                Token = user.Token,
                Message = "Login Successful",
                Role = user.Role,
                UserName = user.UserName,
                Name = user.FirstName + user.LastName,
               


            }) ;
        }

       



        [HttpGet]
        public async Task<Profile> GetDetails(string username)
        {
            return _userRepo.ProfileDetails(username);
        }

        [HttpPut("profile")]
        public async Task<Profile> UpdateFirstName(Profile profile)
        {
            return _userRepo.UpdateProfileDetails(profile);
        }


        [HttpPost("passwordupdate")]
        public async Task<IActionResult> PasswordUpdate([FromBody] passwordchange userobj)
        {
            var user = await _context.Login.FirstAsync(x => x.UserName == userobj.UserName || x.Email == userobj.UserName);

            if (!PasswordHasher.VerifyPassword(userobj.Password, user.Password))
            {
                return BadRequest(new { Message = "Password is Incorrect" });

            }
            

            var pass = CheckPasswordStrength(userobj.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });
            userobj.Password = PasswordHasher.HashPassword(userobj.Password);

            Login passwordupdate=new Login();
            passwordupdate.UserName = userobj.UserName;
            passwordupdate.Password=userobj.Password;
            _userRepo.PasswordUpdate(passwordupdate);
            return Ok(new
            {
                Message = "Password Changed Successfully"
            });

        }



        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] Login userObj)
        {
            if (userObj == null)
                return BadRequest();
            //check username
            if (await CheckUserNameExistAsync(userObj.UserName))
                return BadRequest(new { Message = "Username already exist!" });


            //check email
            if (await CheckEmailExistAsync(userObj.Email))
                return BadRequest(new { Message = "Email already exist!" });

            //check password strength
            var pass = CheckPasswordStrength(userObj.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });

            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            userObj.Role = "User";
            userObj.Token = " ";

            await _context.Login.AddAsync(userObj);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registred"
            });
        }

        private async Task<bool> CheckUserNameExistAsync(string userName)
        {
            return await _context.Login.AnyAsync(x => x.UserName == userName);

        }
        private async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _context.Login.AnyAsync(x => x.Email == email);

        }
        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 6)
                sb.Append("Password Minimum length should be 6" + Environment.NewLine);
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]")
                && Regex.IsMatch(password, "[0-9]")))

                sb.Append("Password should be Alphanumeric" + Environment.NewLine);
            if (!Regex.IsMatch(password, "[<,>,!,@,#,$,%,^,&,*,(,),_,+,|,{,},[,\\],=]"))

                sb.Append("Password should contain special char" + Environment.NewLine);
            return sb.ToString();

        }

        private string CreateJwt(Login user)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("veryverysceret.....");
                var identity = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Name, $"{user.FirstName}{user.LastName}")
                });

                var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

                var now = DateTime.UtcNow;

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Expires = now.AddHours(3),
                    NotBefore = now,
                    IssuedAt = now,
                    SigningCredentials = credentials
                };

                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                return jwtTokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                // Log the exception if you have a logging mechanism in place
                Console.WriteLine($"An error occurred while creating the JWT: {ex.Message}");

                // Optionally, rethrow the exception or return a specific error message
                throw new Exception("An error occurred while generating the JWT token.", ex);
            }
        }


        [HttpGet("forgot")]
        public async Task<ActionResult<int>> Checkpwd(string forgot)
        {
            return _userRepo.ForgotPassword(forgot);
        }
        [HttpPut]
        public async Task<ActionResult<Login>> PasswordUpdate(Login update)
        {
            var pass = CheckPasswordStrength(update.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });
            update.Password = PasswordHasher.HashPassword(update.Password);
            return _userRepo.PasswordUpdate(update);
        }




        // GET: api/Users
        //[HttpGet]
        //public  ActionResult<IEnumerable<User>> GetUser()
        //{
        //    return _userRepo.GetAllUsers();
        //}







    }
}
