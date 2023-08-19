using AutoMapper;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Lession_
{
    public class LessionsProfile:Profile
    {
        public LessionsProfile()
        {
            CreateMap<Lessions,ViewLessionsDto>();
            CreateMap<CreateLessionDto, Lessions>();
            CreateMap<UpdateLessionDto, Lessions>();
        }
    }
}
