using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YegnaGebiyaSystem.Migrations
{
    public partial class Initail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(nullable: true),
                    Desceiption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    U_ID = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.U_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    B_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.B_ID);
                    table.ForeignKey(
                        name: "FK_Buyers_AspNetUsers_U_ID",
                        column: x => x.U_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackBody = table.Column<string>(nullable: true),
                    Sender_ID = table.Column<int>(nullable: false),
                    Replayer_Id = table.Column<int>(nullable: false),
                    Sent_Date = table.Column<DateTime>(nullable: false),
                    Replay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Feedbacks_AspNetUsers_Sender_ID",
                        column: x => x.Sender_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Seller_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ratting = table.Column<float>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Balance = table.Column<float>(nullable: false),
                    U_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Seller_ID);
                    table.ForeignKey(
                        name: "FK_Sellers_AspNetUsers_U_ID",
                        column: x => x.U_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCatagories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubcatagoryName = table.Column<string>(nullable: true),
                    C_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCatagories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCatagories_Categories_C_ID",
                        column: x => x.C_ID,
                        principalTable: "Categories",
                        principalColumn: "Category_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Services = table.Column<string>(nullable: true),
                    Quantity = table.Column<long>(nullable: false),
                    Cat_ID = table.Column<int>(nullable: false),
                    S_ID = table.Column<int>(nullable: false),
                    AddtDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_Cat_ID",
                        column: x => x.Cat_ID,
                        principalTable: "Categories",
                        principalColumn: "Category_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_S_ID",
                        column: x => x.S_ID,
                        principalTable: "Sellers",
                        principalColumn: "Seller_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    B_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(nullable: true),
                    No_page = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    P_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.B_ID);
                    table.ForeignKey(
                        name: "FK_Books_Products_P_ID",
                        column: x => x.P_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    C_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    fueltype = table.Column<string>(nullable: true),
                    Transmission = table.Column<string>(nullable: true),
                    Airbag = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    P_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.C_ID);
                    table.ForeignKey(
                        name: "FK_Cars_Products_P_ID",
                        column: x => x.P_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cloths",
                columns: table => new
                {
                    C_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    P_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cloths", x => x.C_ID);
                    table.ForeignKey(
                        name: "FK_Cloths_Products_P_ID",
                        column: x => x.P_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Com_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentBody = table.Column<string>(nullable: true),
                    Item_ID = table.Column<int>(nullable: true),
                    Seller_ID = table.Column<int>(nullable: true),
                    Buyer_ID = table.Column<int>(nullable: false),
                    Sent_Date = table.Column<DateTime>(nullable: false),
                    Replay = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Com_ID);
                    table.ForeignKey(
                        name: "FK_Comments_Buyers_Buyer_ID",
                        column: x => x.Buyer_ID,
                        principalTable: "Buyers",
                        principalColumn: "B_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Products_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Sellers_Seller_ID",
                        column: x => x.Seller_ID,
                        principalTable: "Sellers",
                        principalColumn: "Seller_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    Core = table.Column<string>(nullable: true),
                    CPU = table.Column<float>(nullable: false),
                    RAM = table.Column<int>(nullable: false),
                    Procesor_Speed = table.Column<float>(nullable: false),
                    Processor_Type = table.Column<string>(nullable: true),
                    OS = table.Column<string>(nullable: true),
                    Hard_Disk = table.Column<long>(nullable: false),
                    Resolution = table.Column<string>(nullable: true),
                    Size = table.Column<float>(nullable: false),
                    P_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Computers_Products_P_ID",
                        column: x => x.P_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Num_bedroom = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Num_Bathroom = table.Column<int>(nullable: false),
                    Total_room = table.Column<int>(nullable: false),
                    P_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Houses_Products_P_ID",
                        column: x => x.P_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsID = table.Column<int>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    OrderTotal = table.Column<double>(nullable: false),
                    Orderplaced = table.Column<DateTime>(nullable: false),
                    PaymentTransactionId = table.Column<string>(nullable: true),
                    HasBeenShipped = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    Storage = table.Column<int>(nullable: false),
                    SIM_NO = table.Column<int>(nullable: false),
                    Display = table.Column<float>(nullable: false),
                    Resolution = table.Column<string>(nullable: true),
                    OS = table.Column<string>(nullable: true),
                    Card_Slot = table.Column<string>(nullable: true),
                    Main_Camera = table.Column<int>(nullable: false),
                    Front_Camera = table.Column<int>(nullable: false),
                    Finger_Print = table.Column<string>(nullable: true),
                    P_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Phones_Products_P_ID",
                        column: x => x.P_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    S_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    P_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.S_ID);
                    table.ForeignKey(
                        name: "FK_Shoes_Products_P_ID",
                        column: x => x.P_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    productId = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sold_Items",
                columns: table => new
                {
                    S_i_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_ID = table.Column<int>(nullable: true),
                    B_ID = table.Column<int>(nullable: true),
                    P_ID = table.Column<int>(nullable: true),
                    S_Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sold_Items", x => x.S_i_ID);
                    table.ForeignKey(
                        name: "FK_Sold_Items_Buyers_B_ID",
                        column: x => x.B_ID,
                        principalTable: "Buyers",
                        principalColumn: "B_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sold_Items_Products_P_ID",
                        column: x => x.P_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sold_Items_Sellers_S_ID",
                        column: x => x.S_ID,
                        principalTable: "Sellers",
                        principalColumn: "Seller_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sold_Items_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    P_ID = table.Column<int>(nullable: true),
                    S_ID = table.Column<int>(nullable: true),
                    B_ID = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Buyers_B_ID",
                        column: x => x.B_ID,
                        principalTable: "Buyers",
                        principalColumn: "B_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_P_ID",
                        column: x => x.P_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Sellers_S_ID",
                        column: x => x.S_ID,
                        principalTable: "Sellers",
                        principalColumn: "Seller_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "Name", "Nationality", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sex", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "552908c4-46c7-45f7-a3cd-73cf1e7a64e2", "naty@gmail.com", false, null, false, null, "naty getnet", null, null, null, "natyman", null, false, null, null, null, false, "natyman" },
                    { 3, 0, "8f8d803f-34cd-42ba-b088-68df8672c67e", "misg@gmail.com", false, null, false, null, "misganew yazie", null, null, null, "achexs", null, false, null, null, null, false, "misganew" },
                    { 4, 0, "cfd94a6a-fae7-4e6f-9e0b-765e5e1be575", "demie@gmail.com", false, null, false, null, "demeke", null, null, null, "demeke", null, false, null, null, null, false, "demeke" },
                    { 5, 0, "1d62c19e-1736-4089-87d7-9671ea84d265", "bela@gmail.com", false, null, false, null, "belaynesh", null, null, null, "bela", null, false, null, null, null, false, "Belaynesh" },
                    { 6, 0, "46c357b0-5a7b-4c0e-93eb-c6c0ea325f9b", "jhon@gmail.com", false, null, false, null, "yohanees", null, null, null, "jhonman", null, false, null, null, null, false, "jhon" },
                    { 7, 0, "f6baf203-af44-4007-af3a-03454e5afadb", "sent@gmail.com", false, null, false, null, "sintayehu", null, null, null, "sent1234", null, false, null, null, null, false, "sent" },
                    { 8, 0, "5e6ac72a-08da-4a9b-a9b1-a10bd44c4d4a", "sent@gmail.com", false, null, false, null, "sintayehu", null, null, null, "sent1234", null, false, null, null, null, false, "sent" },
                    { 9, 0, "0773c686-8e58-42c5-bc6c-8fa0f8b62802", "sent@gmail.com", false, null, false, null, "sintayehu", null, null, null, "sent1234", null, false, null, null, null, false, "sent" },
                    { 10, 0, "483d3877-83c0-49f7-89fa-79f9bc88448e", "sent@gmail.com", false, null, false, null, "sintayehu", null, null, null, "sent1234", null, false, null, null, null, false, "sent" },
                    { 11, 0, "d2a0cc5d-6260-419b-8b80-8e0663f1da43", "sent@gmail.com", false, null, false, null, "sintayehu", null, null, null, "sent1234", null, false, null, null, null, false, "sent" },
                    { 12, 0, "5f30e3b7-9d9f-48b4-9d0d-f196c568b417", "sent@gmail.com", false, null, false, null, "sintayehu", null, null, null, "sent1234", null, false, null, null, null, false, "sent" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Category_ID", "Category_Name", "Desceiption" },
                values: new object[,]
                {
                    { 1, "Electronics", "work with electric status" },
                    { 2, "Fasion", "Fasion for cloth and shoes" },
                    { 3, "Book", "Book for student and learners" },
                    { 4, "House", "house for any purpose" },
                    { 5, "Car", "care for transport" }
                });

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "B_ID", "U_ID" },
                values: new object[,]
                {
                    { 2, 6 },
                    { 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "ID", "FeedbackBody", "Replay", "Replayer_Id", "Sender_ID", "Sent_Date" },
                values: new object[] { 1, "low speed to process", "ok", 0, 2, new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Seller_ID", "Address", "Balance", "Ratting", "U_ID" },
                values: new object[,]
                {
                    { 3, "Addis Ababa", 0f, 45f, 4 },
                    { 9, "Addis Ababa", 0f, 45f, 10 },
                    { 8, "Addis Ababa", 0f, 45f, 9 },
                    { 7, "Addis Ababa", 0f, 45f, 8 },
                    { 6, "Addis Ababa", 0f, 45f, 7 },
                    { 5, "Addis Ababa", 0f, 45f, 6 },
                    { 4, "Addis Ababa", 0f, 45f, 5 },
                    { 11, "Addis Ababa", 0f, 45f, 12 },
                    { 2, "Addis Ababa", 0f, 45f, 3 },
                    { 1, "Addis Ababa", 0f, 45f, 2 },
                    { 10, "Addis Ababa", 0f, 45f, 11 }
                });

            migrationBuilder.InsertData(
                table: "SubCatagories",
                columns: new[] { "Id", "C_ID", "SubcatagoryName" },
                values: new object[,]
                {
                    { 6, 5, "Car" },
                    { 5, 4, "House" },
                    { 7, 3, "Book" },
                    { 4, 2, "Cloth" },
                    { 3, 2, "Shoes" },
                    { 2, 1, "Computer" },
                    { 1, 1, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "AddtDate", "Cat_ID", "Image", "Name", "Price", "Quantity", "S_ID", "Services", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "java tutorial", 120.0, 3L, 1, "used", "avaliable" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "DB tutorial", 100.0, 3L, 2, "used", "avaliable" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, "vitz", 800000.0, 3L, 3, "used", "avaliable" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, "rava4", 600000.0, 1L, 4, "new", "avaliable" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "cloth", 700.0, 3L, 5, "new", "avaliable" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "cloth", 700.0, 3L, 6, "new", "avaliable" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "dell", 1120.0, 3L, 7, "used", "avaliable" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, "appa1", 1234500.0, 3L, 8, "used", "avaliable" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, "appa2", 1234500.0, 3L, 9, "new", "avaliable" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Galaxy", 8000.0, 2L, 10, "new", "avaliable" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "torshin", 5000.0, 3L, 11, "used", "avaliable" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "B_ID", "Author", "ISBN", "No_page", "P_ID", "Type" },
                values: new object[,]
                {
                    { 1, "mayet", "101", 222, 1, null },
                    { 2, "misganew", "103", 345, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "C_ID", "Airbag", "Capacity", "Model", "P_ID", "Transmission", "Type", "fueltype" },
                values: new object[,]
                {
                    { 1, "good", 50, "toyota", 3, "noideia", null, "oil" },
                    { 2, "good", 100, "rava4", 4, "noideia", null, "oil" }
                });

            migrationBuilder.InsertData(
                table: "Cloths",
                columns: new[] { "C_ID", "Brand", "Color", "P_ID", "Size", "Type" },
                values: new object[,]
                {
                    { 1, "nike", "white", 5, 33, "jeans" },
                    { 2, "puma", "blue", 6, 25, "tishert" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Com_ID", "Buyer_ID", "CommentBody", "Item_ID", "Replay", "Seller_ID", "Sent_Date", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "the product is nice", 1, "thank you for your support", 1, new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 2, "the product has a problem", 2, "what is the problem", 2, new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Computers",
                columns: new[] { "ID", "CPU", "Core", "Hard_Disk", "Model", "OS", "P_ID", "Procesor_Speed", "Processor_Type", "RAM", "Resolution", "Size" },
                values: new object[] { 1, 2.5f, "i3", 500L, "toshiba", "window", 7, 2.3f, "intel", 4, "1080x900", 16f });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "ID", "Location", "Num_Bathroom", "Num_bedroom", "P_ID", "Total_room", "Type" },
                values: new object[,]
                {
                    { 1, "gonder", 3, 2, 8, 6, "appartama" },
                    { 2, "Addis ababa", 4, 4, 9, 8, "appartama" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "ID", "Card_Slot", "Display", "Finger_Print", "Front_Camera", "Main_Camera", "Model", "OS", "P_ID", "Resolution", "SIM_NO", "Storage" },
                values: new object[] { 1, "accept", 24f, "yes", 8, 16, "samsung", "Android", 10, "1080x700", 2, 32 });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "S_ID", "Brand", "Color", "P_ID", "Size" },
                values: new object[] { 1, "nike", "Black", 11, 41 });

            migrationBuilder.InsertData(
                table: "Sold_Items",
                columns: new[] { "S_i_ID", "B_ID", "P_ID", "S_Date", "S_ID", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2020, 1, 27, 21, 23, 9, 494, DateTimeKind.Local).AddTicks(6126), 1, null },
                    { 2, 2, 5, new DateTime(2020, 1, 27, 21, 23, 9, 515, DateTimeKind.Local).AddTicks(9716), 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_P_ID",
                table: "Books",
                column: "P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_U_ID",
                table: "Buyers",
                column: "U_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_P_ID",
                table: "Cars",
                column: "P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Cloths_P_ID",
                table: "Cloths",
                column: "P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Buyer_ID",
                table: "Comments",
                column: "Buyer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Item_ID",
                table: "Comments",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Seller_ID",
                table: "Comments",
                column: "Seller_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_P_ID",
                table: "Computers",
                column: "P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Sender_ID",
                table: "Feedbacks",
                column: "Sender_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_P_ID",
                table: "Houses",
                column: "P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_B_ID",
                table: "OrderDetails",
                column: "B_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_P_ID",
                table: "OrderDetails",
                column: "P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_S_ID",
                table: "OrderDetails",
                column: "S_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UserId",
                table: "OrderDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductsID",
                table: "Orders",
                column: "ProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_P_ID",
                table: "Phones",
                column: "P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Cat_ID",
                table: "Products",
                column: "Cat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_S_ID",
                table: "Products",
                column: "S_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_U_ID",
                table: "Sellers",
                column: "U_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_P_ID",
                table: "Shoes",
                column: "P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_productId",
                table: "ShoppingCartItems",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Sold_Items_B_ID",
                table: "Sold_Items",
                column: "B_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sold_Items_P_ID",
                table: "Sold_Items",
                column: "P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sold_Items_S_ID",
                table: "Sold_Items",
                column: "S_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sold_Items_UserId",
                table: "Sold_Items",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCatagories_C_ID",
                table: "SubCatagories",
                column: "C_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Cloths");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Sold_Items");

            migrationBuilder.DropTable(
                name: "SubCatagories");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
