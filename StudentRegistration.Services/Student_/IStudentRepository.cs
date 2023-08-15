using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Student_
{
    public interface IStudentRepository
    {
        public List<Students> GetStudents();
        public Students InsertStudents(Students students);
        public Students GetStudent(int id);
        public bool DeleteStudent(int id);
        public Students UpdateStudent(Students student);
    }
}
