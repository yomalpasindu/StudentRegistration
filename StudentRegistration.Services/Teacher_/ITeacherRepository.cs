using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Teacher_
{
    public interface ITeacherRepository
    {
        public Teachers GetTeacher(int id);
        public Teachers InsertTeacher(Teachers teacher);
    }
}
