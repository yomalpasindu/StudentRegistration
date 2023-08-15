using StudentRegistration.DataAccess;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Teacher_
{
    public class TeacherSqlServerService: ITeacherRepository
    {
        StudentRegistrationDBContext context=new StudentRegistrationDBContext();

        public Teachers GetTeacher(int id)
        {
            return context.Teachers.Where(t=>t.Id==id).FirstOrDefault();
        }
        public Teachers InsertTeacher(Teachers teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
            return GetTeacher(teacher.Id);
        }
    }
}
