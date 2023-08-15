using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Course_
{
    public interface ICoursesRepository
    {
        public List<Courses> GetCourses();
        public Courses GetCourse(int id);
        public Courses UpdateCourse(Courses course);
        public Courses InsertCourse(Courses course);
        public Boolean DeleteCourse(int id);
    }
}
