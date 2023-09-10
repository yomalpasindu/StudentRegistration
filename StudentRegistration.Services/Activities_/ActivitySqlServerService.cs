using StudentRegistration.DataAccess;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Activities_
{
    public class ActivitySqlServerService: IActivityRepository
    {
        private readonly StudentRegistrationDBContext context;
        public ActivitySqlServerService(StudentRegistrationDBContext _context)
        {
            context = _context;
        }
        //StudentRegistrationDBContext context=new StudentRegistrationDBContext();
        public List<Activities> GetAllActivities()
        {
            return context.Activities.ToList();
        }

        public Activities GetActivity(int id)
        {
            return context.Activities.Where(a => a.Id == id).FirstOrDefault();
        }

        public Activities InsertActivity(Activities activity)
        {
            context.Activities.Add(activity);
            context.SaveChanges();
            return GetActivity(activity.Id);
        }
        public Activities UpdateActivity(Activities activity)
        {
            context.Activities.Update(activity);
            context.SaveChanges();
            return(GetActivity(activity.Id));
        }
        public Boolean DeleteActivity(int id)
        {
            var activity=context.Activities.Where(a=>a.Id==id).FirstOrDefault();
            if(activity!=null) { 
            context.Activities.Remove(activity);
            context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
