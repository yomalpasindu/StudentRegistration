using StudentRegistration.Modles;
using StudentRegistration.Modles.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Lession_
{
    public interface ILessionsRepository
    {
        public List<Lessions> GetAllLessions(QueryParameters queryParameters);
        public Lessions GetLession(int id);
        public Lessions InsertLession(Lessions lession);
        public Lessions UpdateLession(Lessions lession);
        public Boolean DeleteLession(int id);
    }
}
