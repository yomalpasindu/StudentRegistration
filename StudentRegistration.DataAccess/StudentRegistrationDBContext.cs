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
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Students)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId)
                .HasPrincipalKey(c => c.Id);


            modelBuilder.Entity<Teachers>()
                .HasMany(t => t.Courses)
                .WithMany(t => t.Teachers);

            modelBuilder.Entity<Courses>()
                .HasData(new Courses[]
                {
                    new Courses
                    {
                        Id = 1,
                        Name="IT"
                    },
                    new Courses
                    {
                        Id = 2,
                        Name="Management"
                    }
                });
            modelBuilder.Entity<Teachers>()
                .HasData(new Teachers[]
                {
                    new Teachers
                    {
                        Id = 1,
                        Name="Yomal",
                        DOB=new DateTime().Date,
                        ContactNo="0717992131",
                        Email="yomal.devanz@gmail.com",
                        NIC="942021852V",
                        Address1="no 55/1",
                        Address2="gattuwana",
                        Address3="kurunegala"
                    },
                    new Teachers
                    {
                        Id = 2,
                        Name="Ben",
                        DOB=new DateTime().Date,
                        ContactNo="0767788909",
                        Email="ben.devanz@gmail.com",
                        NIC="992021852V",
                        Address1="no 42/1",
                        Address2="gattuwana",
                        Address3="kurunegala"
                    }
                });

            modelBuilder.Entity<Students>()
                .HasData(new Students[]
                {
                    new Students 
                    {                         
                        Id = 1,
                        Name="Top",
                        DOB=new DateTime().Date,
                        ContactNo="0767788909",
                        Email="top.devanz@gmail.com",
                        NIC="992021852V",
                        Address1="no 12/1",
                        Address2="gattuwana",
                        Address3="kurunegala",
                        CourseId=1
                    },

                    new Students
                    {
                        Id = 2,
                        Name="Bottom",
                        DOB=new DateTime().Date,
                        ContactNo="0767788909",
                        Email="bottom.devanz@gmail.com",
                        NIC="992021852V",
                        Address1="no 12/1",
                        Address2="gattuwana",
                        Address3="kurunegala",
                        CourseId=2
                    }
                });
        }
    }
}
