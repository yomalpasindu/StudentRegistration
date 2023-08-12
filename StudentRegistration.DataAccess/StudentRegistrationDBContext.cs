using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.DataAccess
{
    public class StudentRegistrationDBContext : DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        /*public DbSet<Activities> Activities { get; set; }
        public DbSet<Lessions> Lessions { get; set; }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost; Database=StudentsDB;Trusted_Connection=True;Encrypt=False;";
            optionsBuilder.UseSqlServer(connectionString);
            //base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Students)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId)
                .HasPrincipalKey(c => c.Id);


            modelBuilder.Entity<Teachers>()
                .HasMany(t => t.Courses)
                .WithMany(t => t.Teachers);
                

        }
    }
}
