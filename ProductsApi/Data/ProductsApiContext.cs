using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Data
{
    public class ProductsApiContext : DbContext
    {
        public ProductsApiContext(DbContextOptions<ProductsApiContext> options)
            : base(options)
        {
        }

        public DbSet<ProductsApi.Models.Products> Products { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(

                 new Products
                 {
                     ProductId = 1,
                     ProductCategory = "Electronics",
                     ProductName = "Apple AirPods (3rd Generation) Wireless Ear Buds",
                     ProductPrice = 189.99,
                     Noofstocks = 17,
                     ProductRating = 1,
                     Imageurl = "https://th.bing.com/th?id=OIP.1lnPiC5kC4p5yZ0q8IGS9wHaHa&w=250&h=250&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2",
                     ProductDescription = "The AirPods (3rd generation) provide personalized spatial audio with dynamic head tracking and Dolby Atmos support, while being IPX4 rated for sweat and water resistance. With a Lightning Charging Case, they offer up to 6 hours of listening time and 30 hours total. Features include pinch-perfect control, always-on ‘Hey Siri’ functionality, and seamless pairing with Apple devices, allowing for automatic audio switching.",
                     SellerName = "Appario Retail Private Ltd"
                 },

                 new Products
                 {
                     ProductId = 2,
                     ProductCategory = "Fashion",
                     ProductName = "Men's Nike Sportswear Club Fleece Pullover Hoodie",
                     ProductPrice = 48.75,
                     Noofstocks = 11,
                     ProductRating = 2.5,
                     Imageurl = "https://media.kohlsimg.com/is/image/kohls/3583992_Black_White?wid=805&hei=805&op_sharpen=1",
                     ProductDescription = "A closet staple, the Nike Sportswear Club Fleece men’s pullover hoodie combines classic style with the soft comfort of fleece for an elevated, everyday look that you really can wear every day.",
                     SellerName = "Maruti Enterprises"
                 },

                 new Products
                 {
                     ProductId = 3,
                     ProductCategory = "Electronics",
                     ProductName = "oneplus 10 Pro+ 5G (Nebula Blue, 128 GB) (8 GB RAM)",
                     ProductPrice = 150,
                     Noofstocks = 8,
                     ProductRating = 3,
                     Imageurl = "https://fdn2.gsmarena.com/vv/bigpic/realme-10-pro.jpg",
                     ProductDescription = "oneplus 10 Pro+ 5G (Nebula Blue, 128 GB) (8 GB RAM)",
                     SellerName = "Oppo Mobiles India Private Limited"
                 },

                 new Products
                 {
                     ProductId = 4,
                     ProductCategory = "Home & Kitchen",
                     ProductName = "Heritage66 Thermal Coffee Carafe -Triple Wall Vacuum insulated Flask",
                     ProductPrice = 26.99,
                     Noofstocks = 12,
                     ProductRating = 4.2,
                     Imageurl = "https://m.media-amazon.com/images/I/51USDDRcTjL._AC_SX679_.jpg",
                     ProductDescription = "Your Perfect Cup of Coffee, Every Time. Holds 8 US Cups--- Excellent for Home, Office, Restaurant, or Gathering. Our thermal carafe is made with durable high-quality stainless steel, triple-layer vacuum insulation, and sweat-free design with zero condensation.",
                     SellerName = "Vinod Cookware"
                 },

                 new Products
                 {
                     ProductId = 5,
                     ProductCategory = "Books",
                     ProductName = "I Don’t Love You Anymore: Moving On and Living Your Best Life",
                     ProductPrice = 12.99,
                     Noofstocks = 15,
                     ProductRating = 5,
                     Imageurl = "https://m.media-amazon.com/images/I/61J5Z-OYUUL._SY522_.jpg",
                     ProductDescription = "Dear reader, I hope this book feels like a warm hug to you. I wrote this book for the ones who feel everything too deeply. This book was meant to find you if you’ve ever loved someone who didn’t love you back, or if you have a hard time letting go.",
                     SellerName = "Penguin Ananda (8 October 2018)"
                 },

                 new Products
                 {
                     ProductId = 6,
                     ProductCategory = "Watches",
                     ProductName = "KXAITO Men's Watches Sports Outdoor Waterproof Military Watch",
                     ProductPrice = 21.99,
                     Noofstocks = 10,
                     ProductRating = 0,
                     Imageurl = "https://m.media-amazon.com/images/I/61iYG7ArviL._AC_UL480_FMwebp_QL65_.jpg",
                     ProductDescription = "Military Sport Design: Fashionable sporty dial design, military style outlook. Large Dial (acrylic crystal glass window, case diameter high-quality watch band, Reinforced resin band design is more ergonomic, comfortable to wear.",
                     SellerName = "Vee Ess Sales Pvt Ltd"
                 },

                 new Products
                 {
                     ProductId = 7,
                     ProductCategory = "Perfume",
                     ProductName = "Dossier - Powdery Tobacco - Eau de Parfum",
                     ProductPrice = 39,
                     Noofstocks = 9,
                     ProductRating = 0,
                     Imageurl = "https://m.media-amazon.com/images/I/61i9Rwk3OhL._AC_UL480_FMwebp_QL65_.jpg",
                     ProductDescription = "PURE FRAGRANCE POWDERY TOBACCO: Features the unique scent of tobacco leaves, highlighted by sweet honey and fruity notes with a touch of ginger.",
                     SellerName = "Vini Cosmetics"
                 },

                 new Products
                 {
                     ProductId = 8,
                     ProductCategory = "Bags",
                     ProductName = "Dell EcoLoop Pro Slim Backpack 15",
                     ProductPrice = 49.99,
                     Noofstocks = 9,
                     ProductRating = 4.2,
                     Imageurl = "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/electronics-software-and-accessories/accessories/dell/carrying-case/ecoloop-pro-slim-backpack-cp5724s/media-gallery/en/carrying-cases-backpack-ecoloop-cp5724s-gallery-1-en.psd?fmt=png-alpha&pscan=auto&scl=1&hei=476&wid=472&qlt=100,1&resMode=sharp2&size=472,476&chrss=full",
                     ProductDescription = "Get the Dell EcoLoop Pro Slim Backpack 15 that protects your gear on-the-go and helps reduce environmental impact.",
                     SellerName = "Cannycom Store"
                 },

                 new Products
                 {
                     ProductId = 9,
                     ProductCategory = "HeadPhones",
                     ProductName = "Dell Pro Stereo Headset | WH3022",
                     ProductPrice = 69.99,
                     Noofstocks = 8,
                     ProductRating = 4.2,
                     Imageurl = "https://snpi.dell.com/snp/images/products/large/520-AAUL_MVI4.jpg",
                     ProductDescription = "Experience exceptional audio clarity with this Teams certified wired headset that allows you to wear the microphone on either side for a customized fit.",
                     SellerName = "gadgets storm"
                 },

                 new Products
                 {
                     ProductId = 10,
                     ProductCategory = "Monitors",
                     ProductName = "Dell 27 QHD Monitor (USB-C) | S2722DC",
                     ProductPrice = 259.99,
                     Noofstocks = 8,
                     ProductRating = 4.2,
                     Imageurl = "https://i.dell.com/is/image/DellContent//content/dam/ss2/product-images/dell-client-products/peripherals/monitors/s-series/s2722dc/media-gallery/s2722dc_cfp_00000ff090_gy.psd?fmt=png-alpha&pscan=auto&scl=1&hei=476&wid=476&qlt=100,1&resMode=sharp2&size=476,476&chrss=full",
                     ProductDescription = "Feature Height Adjustment, Anti Glare Screen, Pivot Adjustment, USB Hub, High Dynamic Range.",
                     SellerName = "BenQ, BenQ Corporation 16 Jihu Road, Neihu 114, Taipei, Taiwan"
                 },

                 new Products
                 {
                     ProductId = 11,
                     ProductCategory = "Watches",
                     ProductName = "Citizen Diamond Maleficent Sleeping Beauty Womens Diamond Accent Black Stainless Steel Bracelet Watch",
                     ProductPrice = 32.85,
                     Noofstocks = 9,
                     ProductRating = 4,
                     Imageurl = "https://jcpenney.scene7.com/is/image/JCPenney/DP0423202011002668M.tif?$gallery$&wid=350&hei=350&op_sharpen=1",
                     ProductDescription = "Case style: Analog watch with a stainless steel circular case Dial style: Black dial with silver hands Strap style: Stainless steel strap with a butterfly clasp for comfort and style.",
                     SellerName = "VRP Telematics"
                 }
            );
        }
    }
}
