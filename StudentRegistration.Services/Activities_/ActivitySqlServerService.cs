using StudentRegistration.DataAccess;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Activities_
{
    public class ActivitySqlServerService: IActivityRepository
    {
        StudentRegistrationDBContext context=new StudentRegistrationDBContext();
        public List<Activities> GetAllActivities()
        {
            return context.Activities.ToList();
        }
    }
}
