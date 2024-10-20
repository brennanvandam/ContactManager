using System;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Family" },
                new Category { CategoryID = 2, CategoryName = "Friends" },
                new Category { CategoryID = 3, CategoryName = "Work" }
            );

            // Seed data for Contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    Firstname = "John",
                    Lastname = "Doe",
                    Phone = "555-1234",
                    Email = "john.doe@example.com",
                    Organization = "Company A",
                    CategoryID = 1, // Family
                    DateAdded = DateTime.Now // Sets the current date
                },
                new Contact
                {
                    ContactId = 2,
                    Firstname = "Jane",
                    Lastname = "Smith",
                    Phone = "555-5678",
                    Email = "jane.smith@example.com",
                    Organization = "Company B",
                    CategoryID = 2, // Friends
                    DateAdded = DateTime.Now // Sets the current date
                }
            );
        }
    }
}
