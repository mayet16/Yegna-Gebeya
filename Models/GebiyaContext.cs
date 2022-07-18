using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YegnaGebiyaSystem.Models
{
    public class GebiyaContext : IdentityDbContext<User, UserRole, int>
    {

        public GebiyaContext(DbContextOptions<GebiyaContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cloth> Cloths { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Sold_Items> Sold_Items { get; set; }
        public DbSet<SubCatagory> SubCatagories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().ToTable("User")
                .Property(p=>p.Id).HasColumnName("U_ID");

            //modelBuilder.Entity<Feedback>()
            //  .HasOne(f => f.Replayer)
            //  .WithMany(p => p.FeedbackReplay)
            //  .HasForeignKey(f => f.Replayer_Id)
            //   .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Feedback>()
             .HasOne(f => f.Users)
             .WithMany(p => p.Feedbacks)
             .HasForeignKey(f => f.Sender_ID)
             .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<User>().Property(p => p.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            //modelBuilder.Entity<Feedback>()
            //        .HasRequired(m => m.Users)
            //        .WithMany(t => t.Feedbacks)
            //        .HasForeignKey(m => m.Sender_ID)
            //        .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Feedback>()
            //            .HasRequired(m => m.Replayer)
            //            .WithMany(t => t.FeedbackReplay)
            //            .HasForeignKey(m => m.Replay_Id)
            //            .WillCascadeOnDelete(false);
            

        }
    }
}