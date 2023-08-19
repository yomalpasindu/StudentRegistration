using StudentRegistration.Services.Student_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Course_
{
    public class ViewCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ViewStudentDto> Students { get; set; } = new List<ViewStudentDto>();
    }
}
