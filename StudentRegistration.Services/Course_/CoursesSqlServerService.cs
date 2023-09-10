using StudentRegistration.DataAccess;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Course_
{
    public class CoursesSqlServerService: ICoursesRepository
    {
        private readonly StudentRegistrationDBContext context;
        public CoursesSqlServerService(StudentRegistrationDBContext _context)
        {
            context = _context;
        }
        //StudentRegistrationDBContext context = new StudentRegistrationDBContext();
        public List<Courses> GetCourses()
        {
            return context.Courses.ToList();
        }
        public Courses GetCourse(int id)
        {
            return context.Courses.FirstOrDefault(c=>c.Id==id);
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
            if(course != null)
            {
                var deletedRecord = context.Courses.Remove(course);
                context.SaveChanges();
                return true;// ("Course Sucessfully Removed!");
            }
            return false;// ("Course not found!");
        }
    }
}
