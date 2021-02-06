using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context - DB tabloları proje klaslarını ilişkilendirme
    //EF Contexten kalıtım aldıık
    /*
     Veritabanını belirtmek gerekiyor.
     */
    public class NordwindContext:DbContext
    {
        //Veritabanı ilişkilendirme
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //şifre sorgusu olmadan northwind database ine bağlandık.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        //hangi class hangi tabloya bağlanacak - şimdilik böyle sonra değişecek
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
