using StudentRegistration.Modles;
using StudentRegistration.Services.Teacher_;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Activities_
{
    public class ViewActivityDto
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public ViewTeacherDto Teacher { get; set; }
    }
}
