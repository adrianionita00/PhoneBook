using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using StefaniniPhoneBook.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StefaniniPhoneBook.Models
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<DetailType> DetailsTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}