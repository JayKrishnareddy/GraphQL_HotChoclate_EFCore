using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_HotChoclate_EFCore.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        #region Seed Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id =1,
                    Name = "Jay krishna Reddy",
                    Designation = "Full Stack Developer"
                },
                new Employee
                {
                    Id = 2,
                    Name = "JK",
                    Designation = "SSE"
                },
                new Employee 
                {
                    Id = 3,
                    Name = "Jay",
                    Designation = "Software Engineer"
                },
                new Employee
                {
                    Id = 4,
                    Name = "krishna Reddy",
                    Designation = "Database Developer"
                },
                new Employee
                {
                    Id = 5,
                    Name = "Reddy",
                    Designation = "Cloud Engineer"
                }
                );
        }
        #endregion

    }
}
