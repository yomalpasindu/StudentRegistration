using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Lession_
{
    public class CreateLessionDto
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}
