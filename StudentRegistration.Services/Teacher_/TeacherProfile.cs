using AutoMapper;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Teacher_
{
    public class TeacherProfile:Profile
    {
        public TeacherProfile()
        {
            CreateMap<CreateTeacherDto, Teachers>();
            CreateMap<Teachers, ViewTeacherDto>()
                .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => $"{src.Address1},{src.Address2},{src.Address3}"));
            CreateMap<UpdateTeacherDto,Teachers>();
        }
    }
}
