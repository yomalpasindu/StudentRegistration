using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Modles
{
    public class Students
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]        
        public DateTime DOB{ get; set; }
        [Required]
        [MaxLength(10)]
        public string ContactNo { get; set; }
        [Required]
        [MaxLength (100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(15)]
        public string NIC{ get; set; }
        [Required]
        [MaxLength(20)]
        public string Address1 { get; set; }

        [MaxLength(50)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string Address3 { get; set; }



        public int CourseId { get; set; }
        public Courses Course { get; set; }
        public ICollection<Teachers> Teachers { get; set; }

    }
}
