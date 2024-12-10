using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    Noofstocks = table.Column<int>(type: "int", nullable: false),
                    Imageurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductRating = table.Column<double>(type: "float", nullable: false),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Imageurl", "Noofstocks", "ProductCategory", "ProductDescription", "ProductName", "ProductPrice", "ProductRating", "SellerName" },
                values: new object[,]
                {
                    { 1, "https://th.bing.com/th?id=OIP.1lnPiC5kC4p5yZ0q8IGS9wHaHa&w=250&h=250&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2", 17, "Electronics", "The AirPods (3rd generation) provide personalized spatial audio with dynamic head tracking and Dolby Atmos support, while being IPX4 rated for sweat and water resistance. With a Lightning Charging Case, they offer up to 6 hours of listening time and 30 hours total. Features include pinch-perfect control, always-on ‘Hey Siri’ functionality, and seamless pairing with Apple devices, allowing for automatic audio switching.", "Apple AirPods (3rd Generation) Wireless Ear Buds", 189.99000000000001, 1.0, "Appario Retail Private Ltd" },
                    { 2, "https://media.kohlsimg.com/is/image/kohls/3583992_Black_White?wid=805&hei=805&op_sharpen=1", 11, "Fashion", "A closet staple, the Nike Sportswear Club Fleece men’s pullover hoodie combines classic style with the soft comfort of fleece for an elevated, everyday look that you really can wear every day.", "Men's Nike Sportswear Club Fleece Pullover Hoodie", 48.75, 2.5, "Maruti Enterprises" },
                    { 3, "https://fdn2.gsmarena.com/vv/bigpic/realme-10-pro.jpg", 8, "Electronics", "oneplus 10 Pro+ 5G (Nebula Blue, 128 GB) (8 GB RAM)", "oneplus 10 Pro+ 5G (Nebula Blue, 128 GB) (8 GB RAM)", 150.0, 3.0, "Oppo Mobiles India Private Limited" },
                    { 4, "https://m.media-amazon.com/images/I/51USDDRcTjL._AC_SX679_.jpg", 12, "Home & Kitchen", "Your Perfect Cup of Coffee, Every Time. Holds 8 US Cups--- Excellent for Home, Office, Restaurant, or Gathering. Our thermal carafe is made with durable high-quality stainless steel, triple-layer vacuum insulation, and sweat-free design with zero condensation.", "Heritage66 Thermal Coffee Carafe -Triple Wall Vacuum insulated Flask", 26.989999999999998, 4.2000000000000002, "Vinod Cookware" },
                    { 5, "https://m.media-amazon.com/images/I/61J5Z-OYUUL._SY522_.jpg", 15, "Books", "Dear reader, I hope this book feels like a warm hug to you. I wrote this book for the ones who feel everything too deeply. This book was meant to find you if you’ve ever loved someone who didn’t love you back, or if you have a hard time letting go.", "I Don’t Love You Anymore: Moving On and Living Your Best Life", 12.99, 5.0, "Penguin Ananda (8 October 2018)" },
                    { 6, "https://m.media-amazon.com/images/I/61iYG7ArviL._AC_UL480_FMwebp_QL65_.jpg", 10, "Watches", "Military Sport Design: Fashionable sporty dial design, military style outlook. Large Dial (acrylic crystal glass window, case diameter high-quality watch band, Reinforced resin band design is more ergonomic, comfortable to wear.", "KXAITO Men's Watches Sports Outdoor Waterproof Military Watch", 21.989999999999998, 0.0, "Vee Ess Sales Pvt Ltd" },
                    { 7, "https://m.media-amazon.com/images/I/61i9Rwk3OhL._AC_UL480_FMwebp_QL65_.jpg", 9, "Perfume", "PURE FRAGRANCE POWDERY TOBACCO: Features the unique scent of tobacco leaves, highlighted by sweet honey and fruity notes with a touch of ginger.", "Dossier - Powdery Tobacco - Eau de Parfum", 39.0, 0.0, "Vini Cosmetics" },
                    { 8, "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/electronics-software-and-accessories/accessories/dell/carrying-case/ecoloop-pro-slim-backpack-cp5724s/media-gallery/en/carrying-cases-backpack-ecoloop-cp5724s-gallery-1-en.psd?fmt=png-alpha&pscan=auto&scl=1&hei=476&wid=472&qlt=100,1&resMode=sharp2&size=472,476&chrss=full", 9, "Bags", "Get the Dell EcoLoop Pro Slim Backpack 15 that protects your gear on-the-go and helps reduce environmental impact.", "Dell EcoLoop Pro Slim Backpack 15", 49.990000000000002, 4.2000000000000002, "Cannycom Store" },
                    { 9, "https://snpi.dell.com/snp/images/products/large/520-AAUL_MVI4.jpg", 8, "HeadPhones", "Experience exceptional audio clarity with this Teams certified wired headset that allows you to wear the microphone on either side for a customized fit.", "Dell Pro Stereo Headset | WH3022", 69.989999999999995, 4.2000000000000002, "gadgets storm" },
                    { 10, "https://i.dell.com/is/image/DellContent//content/dam/ss2/product-images/dell-client-products/peripherals/monitors/s-series/s2722dc/media-gallery/s2722dc_cfp_00000ff090_gy.psd?fmt=png-alpha&pscan=auto&scl=1&hei=476&wid=476&qlt=100,1&resMode=sharp2&size=476,476&chrss=full", 8, "Monitors", "Feature Height Adjustment, Anti Glare Screen, Pivot Adjustment, USB Hub, High Dynamic Range.", "Dell 27 QHD Monitor (USB-C) | S2722DC", 259.99000000000001, 4.2000000000000002, "BenQ, BenQ Corporation 16 Jihu Road, Neihu 114, Taipei, Taiwan" },
                    { 11, "https://jcpenney.scene7.com/is/image/JCPenney/DP0423202011002668M.tif?$gallery$&wid=350&hei=350&op_sharpen=1", 9, "Watches", "Case style: Analog watch with a stainless steel circular case Dial style: Black dial with silver hands Strap style: Stainless steel strap with a butterfly clasp for comfort and style.", "Citizen Diamond Maleficent Sleeping Beauty Womens Diamond Accent Black Stainless Steel Bracelet Watch", 32.850000000000001, 4.0, "VRP Telematics" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
