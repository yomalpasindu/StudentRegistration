using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Modles
{
    public class Activities
    {
        [Required]
        public int ActivityId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public Teachers Teacher { get; set; }
    }
}
