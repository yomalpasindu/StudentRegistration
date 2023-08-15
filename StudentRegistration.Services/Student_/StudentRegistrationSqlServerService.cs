using StudentRegistration.DataAccess;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Student_
{
    public class StudentRegistrationSqlServerService : IStudentRepository
    {
        StudentRegistrationDBContext context = new StudentRegistrationDBContext();
        public List<Students> GetStudents()
        {
            return context.Students.ToList();
        }
        public Students GetStudent(int id)
        {
            return context.Students.Where(s => s.Id == id).FirstOrDefault();
        }
        public Students InsertStudents(Students student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }
        public bool DeleteStudent(int id)
        {
            var student = context.Students.Where(s => s.Id == id).FirstOrDefault();
            if (student == null)
            {
                return false;//"Student Id not found! ("+id+")";
            }
            context.Students.Remove(student);
            context.SaveChanges();
            return true;// "Student Successfully Removed! ("+student.Id+")";
        }
        public Students UpdateStudent(Students student)
        {
            context.Students.Update(student);
            context.SaveChanges();
            return GetStudent(student.Id);
        }
    }
}
