using AutoMapper;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services
{
    public class StudentProfile:Profile
    {
        public StudentProfile() 
        {
            CreateMap<Students, ViewStudentDto>()
                .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => $"{src.Address1},{src.Address2},{src.Address3}"));

            CreateMap<CreateStudentDto,Students>();
            CreateMap<UpdateStudentDto,Students>();
        }
    }
}
