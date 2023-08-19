using StudentRegistration.DataAccess;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Lession_
{
    public class LessionsSqlServerService: ILessionsRepository
    {
        StudentRegistrationDBContext context= new StudentRegistrationDBContext();
        public List<Lessions> GetAllLessions()
        {
            return context.Lessions.ToList();
        }
        public Lessions GetLession(int id)
        {
            return context.Lessions.FirstOrDefault(l=>l.Id==id);
        }
        public Lessions InsertLession(Lessions lession)
        {
            context.Lessions.Add(lession);
            context.SaveChanges();
            return GetLession(lession.Id);
        }
        public Lessions UpdateLession(Lessions lession)
        {
            context.Lessions.Update(lession);
            context.SaveChanges();
            return GetLession(lession.Id);
        }
        public Boolean DeleteLession(int id)
        {
            var lession=context.Lessions.Where(l=>l.Id==id).FirstOrDefault();
            if (lession!=null)
            {
                context.Lessions.Remove(lession);
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
