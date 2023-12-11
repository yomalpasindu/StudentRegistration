using Microsoft.EntityFrameworkCore;
using StudentRegistration.DataAccess;
using StudentRegistration.Modles;
using StudentRegistration.Modles.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Course_
{
    public class CoursesSqlServerService : ICoursesRepository
    {
        private readonly StudentRegistrationDBContext context;
        public CoursesSqlServerService(StudentRegistrationDBContext _context)
        {
            context = _context;
        }
        //StudentRegistrationDBContext context = new StudentRegistrationDBContext();
        public List<Courses> GetCourses(QueryParameters queryParameters)
        {
            IQueryable<Courses> courses = context.Courses.Skip(queryParameters.Size * (queryParameters.Page - 1)).Take(queryParameters.Size);
            if (!string.IsNullOrEmpty(queryParameters.Sort))
            {
                switch (queryParameters.Sort)
                {
                    case "asc":
                        courses = courses.OrderBy(c => EF.Property<object>(c,queryParameters.Sort)); break;
                    case "desc":
                        courses=courses.OrderByDescending(c => EF.Property<object>(c,queryParameters.Sort));break;
                }
            }
            return courses.ToList();
        }
        public Courses GetCourse(int id)
        {
            return context.Courses.FirstOrDefault(c => c.Id == id);
        }
        public Courses UpdateCourse(Courses course)
        {
            context.Courses.Update(course);
            context.SaveChanges();
            return GetCourse(course.Id);
        }
        public Courses InsertCourse(Courses course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return GetCourse(course.Id);
        }
        public Boolean DeleteCourse(int id)
        {
            var course = context.Courses.Where(c => c.Id == id).FirstOrDefault();
            if (course != null)
            {
                var deletedRecord = context.Courses.Remove(course);
                context.SaveChanges();
                return true;// ("Course Sucessfully Removed!");
            }
            return false;// ("Course not found!");
        }
    }
}
