using AutoMapper;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Activities_
{
    public class ActivityProfile:Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activities,ViewActivityDto>();
            CreateMap<CreateActivityDto, Activities>();
            CreateMap<UpdateActivityDto,Activities>();
            CreateMap<Activities,UpdateActivityDto>();
        }
    }
}
