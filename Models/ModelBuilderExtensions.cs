



using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(

           new Book
           {
               Author = "mayet",
               No_page = 222,
               ISBN = "101",
               B_ID = 1,
               P_ID = 1


           },
              new Book
              {
                  Author = "misganew",
                  No_page = 345,
                  ISBN = "103",
                  B_ID = 2,
                  P_ID = 2
              }

           );
            modelBuilder.Entity<Car>().HasData(

           new Car
           {
               Capacity = 50,
               C_ID = 1,
               Airbag = "good",
               Model = "toyota",
               Transmission = "noideia",
               fueltype = "oil",
               P_ID = 3,

           },
              new Car
              {
                  Capacity = 100,
                  C_ID = 2,
                  Airbag = "good",
                  Model = "rava4",
                  Transmission = "noideia",
                  fueltype = "oil",
                  P_ID = 4,
              }

           );
            modelBuilder.Entity<Category>().HasData(

             new Category
             {
                 Category_ID = 1,
                 Category_Name = "Electronics",
                 Desceiption = "work with electric status"
             },
                new Category
                {
                    Category_ID = 2,
                    Category_Name = "Fasion",
                    Desceiption = "Fasion for cloth and shoes"
                },
                new Category
                {
                    Category_ID = 3,
                    Category_Name = "Book",
                    Desceiption = "Book for student and learners"
                },
                 new Category
                 {
                     Category_ID = 4,
                     Category_Name = "House",
                     Desceiption = "house for any purpose"
                 },
                 new Category
                 {
                     Category_ID = 5,
                     Category_Name = "Car",
                     Desceiption = "care for transport"
                 }

             );
            modelBuilder.Entity<Cloth>().HasData(

                new Cloth
                {
                    C_ID = 1,
                    Color = "white",
                    Brand = "nike",
                    Size = 33,
                    Type = "jeans",
                    P_ID = 5
                },
                new Cloth
                {
                    C_ID = 2,
                    Color = "blue",
                    Brand = "puma",
                    Size = 25,
                    Type = "tishert",
                    P_ID = 6
                }

                );
            modelBuilder.Entity<Comment>().HasData(

               new Comment
               {
                   CommentBody = "the product is nice",
                   Com_ID = 1,
                   Buyer_ID = 1,
                   Item_ID = 1,
                   Replay = "thank you for your support",
                   Seller_ID = 1,
                   Sent_Date = DateTime.Parse("12/03/2019")
               },
               new Comment
               {
                   CommentBody = "the product has a problem",
                   Com_ID = 2,
                   Buyer_ID = 2,
                   Item_ID = 2,
                   Replay = "what is the problem",
                   Seller_ID = 2,
                   Sent_Date = DateTime.Parse("12/03/2019")
               }

               );
            modelBuilder.Entity<Computer>().HasData(

               new Computer
               {
                   Core = "i3",
                   CPU = 2.5f,
                   Hard_Disk = 500,
                   ID = 1,
                   Model = "toshiba",
                   OS = "window",
                   Procesor_Speed = 2.3f,
                   Processor_Type = "intel",
                   RAM = 4,
                   Resolution = "1080x900",
                   Size = 16,
                   P_ID = 7

               }

               );
            modelBuilder.Entity<Feedback>().HasData(

               new Feedback
               {
                   FeedbackBody = "low speed to process",
                   ID = 1,
                   Replay = "ok",
                   Sender_ID = 2,
                   Sent_Date = DateTime.Parse("12/03/2019")
               }

               );
            modelBuilder.Entity<House>().HasData(

           new House
           {
               ID = 1,
               Location = "gonder",
               Num_Bathroom = 3,
               Num_bedroom = 2,
               Total_room = 6,
               Type = "appartama",
               P_ID = 8
           },
            new House
            {
                ID = 2,
                Location = "Addis ababa",
                Num_Bathroom = 4,
                Num_bedroom = 4,
                Total_room = 8,
                Type = "appartama",
                P_ID = 9
            }

           );
            modelBuilder.Entity<Phone>().HasData(

           new Phone
           {
               ID = 1,
               P_ID = 10,
               Resolution = "1080x700",
               Card_Slot = "accept",
               Front_Camera = 8,
               Main_Camera = 16,
               SIM_NO = 2,
               Finger_Print = "yes",
               Model = "samsung",
               OS = "Android",
               Storage = 32,
               Display = 24
           }

           );
            modelBuilder.Entity<Shoes>().HasData(

           new Shoes
           {
               S_ID = 1,
               P_ID = 11,
               Size = 41,
               Brand = "nike",
               Color = "Black"
           }

           );
            modelBuilder.Entity<Product>().HasData(

           new Product
           {
               ID = 1,
               Price = 120,
               Cat_ID = 3,
               Image = null,
               Name = "java tutorial",
               Quantity = 3,
               Services = "used",
               Status = "avaliable",
               S_ID = 1
           },
           new Product
           {
               ID = 2,
               Price = 100,
               Cat_ID = 3,
               Image = null,
               Name = "DB tutorial",
               Quantity = 3,
               Services = "used",
               Status = "avaliable",
               S_ID = 2
           },
           new Product
           {
               ID = 3,
               Price = 800000,
               Cat_ID = 5,
               Image = null,
               Name = "vitz",
               Quantity = 3,
               Services = "used",
               Status = "avaliable",
               S_ID = 3
           },
           new Product
           {
               ID = 4,
               Price = 600000,
               Cat_ID = 5,
               Image = null,
               Name = "rava4",
               Quantity = 1,
               Services = "new",
               Status = "avaliable",
               S_ID = 4
           },
           new Product
           {
               ID = 5,
               Price = 700,
               Cat_ID = 2,
               Image = null,
               Name = "cloth",
               Quantity = 3,
               Services = "new",
               Status = "avaliable",
               S_ID = 5
           },
           new Product
           {
               ID = 6,
               Price = 700,
               Cat_ID = 2,
               Image = null,
               Name = "cloth",
               Quantity = 3,
               Services = "new",
               Status = "avaliable",
               S_ID = 6
           },
           new Product
           {
               ID = 7,
               Price = 1120,
               Cat_ID = 1,
               Image = null,
               Name = "dell",
               Quantity = 3,
               Services = "used",
               Status = "avaliable",
               S_ID = 7
           },
           new Product
           {
               ID = 8,
               Price = 1234500,
               Cat_ID = 4,
               Image = null,
               Name = "appa1",
               Quantity = 3,
               Services = "used",
               Status = "avaliable",
               S_ID = 8
           },
           new Product
           {
               ID = 9,
               Price = 1234500,
               Cat_ID = 4,
               Image = null,
               Name = "appa2",
               Quantity = 3,
               Services = "new",
               Status = "avaliable",
               S_ID = 9
           },
           new Product
           {
               ID = 10,
               Price = 8000,
               Cat_ID = 1,
               Image = null,
               Name = "Galaxy",
               Quantity = 2,
               Services = "new",
               Status = "avaliable",
               S_ID = 10
           },
           new Product
           {
               ID = 11,
               Price = 5000,
               Cat_ID = 2,
               Image = null,
               Name = "torshin",
               Quantity = 3,
               Services = "used",
               Status = "avaliable",
               S_ID = 11
           }
           );

            modelBuilder.Entity<User>().HasData(

                new User
                {
                    Id = 2,
                    UserName = "natyman",
                    PasswordHash = "natyman",
                    Email = "naty@gmail.com",
                    Name = "naty getnet"
                },

           new User
           {
               Id = 3,
               UserName = "misganew",
               PasswordHash = "achexs",
               Email = "misg@gmail.com",
               Name = "misganew yazie"
           },
             new User
             {
                 Id = 4,
                 UserName = "demeke",
                 PasswordHash = "demeke",
                 Email = "demie@gmail.com",
                 Name = "demeke"
             },
             new User
             {
                 Id = 5,
                 UserName = "Belaynesh",
                 PasswordHash = "bela",
                 Email = "bela@gmail.com",
                 Name = "belaynesh"
             },
             new User
             {
                 Id = 6,
                 UserName = "jhon",
                 PasswordHash = "jhonman",
                 Email = "jhon@gmail.com",
                 Name = "yohanees"
             },
             new User
             {
                 Id = 7,
                 UserName = "sent",
                 PasswordHash = "sent1234",
                 Email = "sent@gmail.com",
                 Name = "sintayehu"
             },
              new User
              {
                  Id = 8,
                  UserName = "sent",
                  PasswordHash = "sent1234",
                  Email = "sent@gmail.com",
                  Name = "sintayehu"
              },
               new User
               {
                   Id = 9,
                   UserName = "sent",
                   PasswordHash = "sent1234",
                   Email = "sent@gmail.com",
                   Name = "sintayehu"
               },
                new User
                {
                    Id = 10,
                    UserName = "sent",
                    PasswordHash = "sent1234",
                    Email = "sent@gmail.com",
                    Name = "sintayehu"
                },
                 new User
                 {
                     Id = 11,
                     UserName = "sent",
                     PasswordHash = "sent1234",
                     Email = "sent@gmail.com",
                     Name = "sintayehu"
                 },
                 new User
                 {
                     Id = 12,
                     UserName = "sent",
                     PasswordHash = "sent1234",
                     Email = "sent@gmail.com",
                     Name = "sintayehu"
                 }

         );

            modelBuilder.Entity<Seller>().HasData(

          new Seller
          {
              Seller_ID = 1,
              Address = "Addis Ababa",
              Ratting = 45,
              U_ID = 2
          },
            new Seller
            {
                Seller_ID = 2,
                Address = "Addis Ababa",
                Ratting = 45,
                U_ID = 3
            },
              new Seller
              {
                  Seller_ID = 3,
                  Address = "Addis Ababa",
                  Ratting = 45,
                  U_ID = 4
              },
              new Seller
              {
                  Seller_ID = 4,
                  Address = "Addis Ababa",
                  Ratting = 45,
                  U_ID = 5
              },
              new Seller
              {
                  Seller_ID = 5,
                  Address = "Addis Ababa",
                  Ratting = 45,
                  U_ID = 6
              },
              new Seller
              {
                  Seller_ID = 6,
                  Address = "Addis Ababa",
                  Ratting = 45,
                  U_ID = 7
              },
              new Seller
              {
                  Seller_ID = 7,
                  Address = "Addis Ababa",
                  Ratting = 45,
                  U_ID = 8
              },
              new Seller
              {
                  Seller_ID = 8,
                  Address = "Addis Ababa",
                  Ratting = 45,
                  U_ID = 9
              },
              new Seller
              {
                  Seller_ID = 9,
                  Address = "Addis Ababa",
                  Ratting = 45,
                  U_ID = 10
              },
              new Seller
              {
                  Seller_ID = 10,
                  Address = "Addis Ababa",
                  Ratting = 45,
                  U_ID = 11
              },
              new Seller
              {
                  Seller_ID = 11,
                  Address = "Addis Ababa",
                  Ratting = 45,
                  U_ID = 12
              }
          );
            modelBuilder.Entity<Buyer>().HasData(

           new Buyer
           {
               B_ID = 1,

               U_ID = 5
           },
            new Buyer
            {
                B_ID = 2,

                U_ID = 6
            }

          );

             modelBuilder.Entity<SubCatagory>().HasData(

        new SubCatagory
        {
            Id = 1,
            SubcatagoryName = "Phone",
            C_ID = 1
        },
          new SubCatagory
          {
              Id = 2,
              SubcatagoryName = "Computer",
              C_ID = 1
          },
          new SubCatagory
          {
              Id = 3,
              SubcatagoryName = "Shoes",
              C_ID = 2
          },
          new SubCatagory
          {
              Id = 4,
              SubcatagoryName = "Cloth",
              C_ID = 2
          },
          new SubCatagory
          {
              Id = 5,
              SubcatagoryName = "House",
              C_ID = 4
          },
          new SubCatagory
          {
              Id = 6,
              SubcatagoryName = "Car",
              C_ID = 5
          },
          new SubCatagory
          {
              Id = 7,
              SubcatagoryName = "Book",
              C_ID = 3
          }
        );
            modelBuilder.Entity<Sold_Items>().HasData(

                    new Sold_Items
                    {
                        S_i_ID = 1,
                        P_ID = 1,
                        S_ID = 1,
                        B_ID = 2,
                        S_Date = DateTime.Now
                    },
                      new Sold_Items
                      {
                          S_i_ID = 2,
                          P_ID = 5,
                          S_ID = 5,
                          B_ID = 2,
                          S_Date = DateTime.Now
                      }

                    );

        }
    }
}
