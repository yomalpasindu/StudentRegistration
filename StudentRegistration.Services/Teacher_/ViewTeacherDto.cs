using StudentRegistration.Modles;
using StudentRegistration.Services.Course_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Teacher_
{
    public class ViewTeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public string Address { get; set; }
        public Courses Courses { get; set; }
    }
}
