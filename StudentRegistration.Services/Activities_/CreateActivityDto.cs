using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Activities_
{
    public class CreateActivityDto
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
    }
}
