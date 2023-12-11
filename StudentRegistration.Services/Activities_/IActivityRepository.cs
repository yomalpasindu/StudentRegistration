using StudentRegistration.Modles;
using StudentRegistration.Modles.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Activities_
{
    public interface IActivityRepository
    {
        public List<Activities> GetAllActivities(QueryParameters queryParameters);
        public Activities GetActivity(int id);
        public Activities InsertActivity(Activities activity);
        public Activities UpdateActivity(Activities activity);
        public Boolean DeleteActivity(int id);
    }
}
