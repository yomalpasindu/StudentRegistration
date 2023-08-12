using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Modles
{
    public class Lessions
    {
        [Required]
        public int LessionId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public Courses course { get; set; }
    }
}
