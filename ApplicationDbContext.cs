using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedEmployees(modelBuilder);
        }

        private void SeedEmployees(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId=Guid.NewGuid(), EmployeeName = "Rahul", EmployeeNumber = 1, CompanyName = "Cisive" },
                new Employee { EmployeeId = Guid.NewGuid(), EmployeeName = "Ashutosh", EmployeeNumber = 2, CompanyName = "Digilink Ads" }
                );
        }
    }
}

