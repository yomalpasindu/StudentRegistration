using AutoMapper;
using StudentRegistration.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Course_
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {
            CreateMap<Courses, ViewCourseDto>();
            CreateMap<ViewCourseDto, Courses>();
            CreateMap<CreateCourseDto,Courses>();
            CreateMap<UpdateCourseDto,Courses>();
        }
    }
}
