using StudentRegistration.DataAccess;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services
{
    public class StudentRegistrationSqlServerService: IStudentRepository
    {
        StudentRegistrationDBContext context=new StudentRegistrationDBContext();
        public List<Students> GetStudents()
        {
            return context.Students.ToList();
        }
    }
}
