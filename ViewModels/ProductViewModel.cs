using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YegnaGebiyaSystem.Models;

namespace YegnaGebiyaSystem.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public Book Book { get; set; }
        public Car Car { get; set; }
        public Cloth Cloth { get; set; }
        public Comment Comment { get; set; }
        public Computer Computer { get; set; }
        public Feedback Feedback { get; set; }
        public House House { get; set; }
        public Phone Phone { get; set; }
        public Shoes Shoes { get; set; }
        public SubCatagory SubCatagory { get; set; }
        public string PageTitle { get; set; }
        public Category Category { get; set; }
        //catagory
        public int CatEgory_Id { get; set; }
        public string Category_Name { get; set; }
        //subcatagory

        public string SubCatagoryName { get; set; }
        public int subCatagoryId { get; set; }
        //Product
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Name cannot execced 50 characters")]

        public string Name { get; set; }
        public Double Price { get; set; }

        public string Image { get; set; }
        public string ExistingPhotoPath { get; set; }
        public IFormFile photo { get; set; }
        public string Status { get; set; }

        public string Service { get; set; }

        public long Quantity { get; set; }
        //BOOK//
        [Key]
        public int B_id { get; set; }
        public string Isbn { get; set; }
        public int No_page { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }
        //Computer
        public int Comp_Id { get; set; }
        public string Core { get; set; }
        public float CPU { get; set; }
        public int RAM { get; set; }
        public long Hard_Disk { get; set; }
        public string Resolution { get; set; }
        public float Size { get; set; }
        public float Processer_Speed { get; set; }
        public string Processer_Type { get; set; }
        //Phone//
        public int PhoneId { get; set; }
        public int Storage { get; set; }
        public int SIM_NO { get; set; }
        public float Display { get; set; }
        public string OS { get; set; }
        public string Card_Slot { get; set; }
        public int Main_Camer { get; set; }
        public int Front_Camer { get; set; }
        public string Finger_Print { get; set; }

        //Car//
        public int car_id { get; set; }// c_id
        public string Model { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string AirBag { get; set; }
        public int Capacity { get; set; }
        //House
        public int H_id { get; set; }
        public int No_bedroom { get; set; }
        public string Location { get; set; }
        public int Bathroom { get; set; }
        public int Total_room { get; set; }
        //Cloth
        public int C_id { get; set; }
        public string Brand { get; set; }
        public int SizeofCloth { get; set; }
        public string Colour { get; set; }
        //Shose
        public int S_id { get; set; }

        public string ShoseBrand { get; set; }

        public int ShoseSize { get; set; }

        public string ShoseColour { get; set; }
        // Foreign key
        [Display(Name = "Product")]
        public int Product_Id { get; set; }
        //order list
        public DateTime OrderedDate { get; set; }
        //Buyer
        public string Buyer_phone { get; set; }
    
        public IEnumerable<Product> Products { get; set; }
       
        public IEnumerable<Seller> Sellers { get; set; }
        public Buyer Buyers { get; set; }
        public Comment Comments { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string currentCategory { get; set; }
        public string CommentBody { get; set; }
        public string CommentReplay { get; set; }
        public int SenderId { get; set; }
         public int PId { get; set; }
        public int CId { get; set; }
        public DateTime SentDate { get; set; }

    }
}
