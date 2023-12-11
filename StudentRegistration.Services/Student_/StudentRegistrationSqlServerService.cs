using Microsoft.EntityFrameworkCore;
using StudentRegistration.DataAccess;
using StudentRegistration.Modles;
using StudentRegistration.Modles.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Student_
{
    public class StudentRegistrationSqlServerService : IStudentRepository
    {
        private readonly StudentRegistrationDBContext context;
        public StudentRegistrationSqlServerService(StudentRegistrationDBContext _context)
        {
            context = _context;
        }
        public List<Students> GetStudents(QueryParameters queryParameters)
        {
            IQueryable<Students>students=context.Students.Skip(queryParameters.Size*(queryParameters.Page-1)).Take(queryParameters.Size);
            if(!string.IsNullOrEmpty(queryParameters.Sort))
            {
                switch(queryParameters.Sort)
                {
                    case "asc":
                        students=students.OrderBy(x=>EF.Property<object>(x,queryParameters.Sort));break;
                    case "desc":
                        students=students.OrderByDescending(x=>EF.Property<object>(x,queryParameters.Sort));break;
                }
            }
            return students.ToList();
        }
        public Students GetStudent(int id)
        {
            return context.Students.Where(s => s.Id == id).FirstOrDefault();
        }
        public Students InsertStudents(Students student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }
        public bool DeleteStudent(int id)
        {
            var student = context.Students.Where(s => s.Id == id).FirstOrDefault();
            if (student == null)
            {
                return false;//"Student Id not found! ("+id+")";
            }
            context.Students.Remove(student);
            context.SaveChanges();
            return true;// "Student Successfully Removed! ("+student.Id+")";
        }
        public Students UpdateStudent(Students student)
        {
            context.Students.Update(student);
            context.SaveChanges();
            return GetStudent(student.Id);
        }
    }
}
