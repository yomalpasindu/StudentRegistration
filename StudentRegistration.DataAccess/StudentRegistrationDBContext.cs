using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Lessions> Lessions { get; set; }
        public StudentRegistrationDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relationships
            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Students)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<Teachers>()
                .HasMany(t => t.Courses)
                .WithMany(t => t.Teachers);

            modelBuilder.Entity<Lessions>()
                .HasOne(l => l.Courses)
                .WithMany(l => l.Lessions)
                .HasForeignKey(l => l.CourseId)
                .HasPrincipalKey(l => l.Id);

            modelBuilder.Entity<Activities>()
                .HasMany(a => a.Students)
                .WithMany(a => a.Activities);

            modelBuilder.Entity<Activities>()
                .HasOne(a => a.Teacher)
                .WithOne(a => a.Activity)
                .HasForeignKey<Activities>(a=>a.TeacherId)
                .IsRequired(false);

            //Data Insertions
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
                        ContactNo="0712121222",
                        Email="yomal.test@gmail.com",
                        NIC="943433252V",
                        Address1="no 55/1",
                        Address2="test lane",
                        Address3="kandy"
                    },
                    new Teachers
                    {
                        Id = 2,
                        Name="Ben",
                        DOB=new DateTime().Date,
                        ContactNo="0767788909",
                        Email="ben.test@gmail.com",
                        NIC="992021852V",
                        Address1="no 42/1",
                        Address2="test lane",
                        Address3="kandy"
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
                        Email="top.test@gmail.com",
                        NIC="992021852V",
                        Address1="no 12/21",
                        Address2="test lane",
                        Address3="kandy",
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
                        Address2="test lane",
                        Address3="kurunegala",
                        CourseId=2
                    }
                });

            modelBuilder.Entity<Lessions>()
                .HasData(new Lessions[]
                {
                    new Lessions
                    {
                        Id = 1,
                        Name="DBMS",
                        CourseId = 1
                    },
                    new Lessions
                    {
                        Id = 2,
                        Name="C#",
                        CourseId = 1
                    },
                    new Lessions
                    {
                        Id = 3,
                        Name="BA",
                        CourseId = 2
                    },
                    new Lessions
                    {
                        Id = 4,
                        Name="Stat",
                        CourseId = 2
                    }
                });
        }
    }
}
