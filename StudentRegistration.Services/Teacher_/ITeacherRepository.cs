using StudentRegistration.Modles;
using StudentRegistration.Modles.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Teacher_
{
    public interface ITeacherRepository
    {
        public List<Teachers> GetAllTeachers(QueryParameters queryParameters);
        public Teachers GetTeacher(int id);
        public Teachers InsertTeacher(Teachers teacher);
        public Teachers UpdateTeacher(Teachers teacher);
        public Boolean DeleteTeacher(int id);
    }
}
