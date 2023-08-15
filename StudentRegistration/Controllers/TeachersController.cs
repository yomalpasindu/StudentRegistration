using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Modles;
using StudentRegistration.Services.Teacher_;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace StudentRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        public TeachersController(ITeacherRepository teacherRepository,IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public ActionResult InsertTeacher(CreateTeacherDto teacher)
        {
            var mappedTeacher = _mapper.Map<Teachers>(teacher);
            var addTeacher=_teacherRepository.InsertTeacher(mappedTeacher);
            var mappedForView = _mapper.Map<ViewTeacherDto>(addTeacher);
            if (mappedForView != null)
            {
                return Ok(mappedForView);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public ActionResult GetTeacher(int id) 
        {
            var teacher=_teacherRepository.GetTeacher(id);
            var mappedTeacher = _mapper.Map<ICollection<ViewTeacherDto>>(teacher);
            if (mappedTeacher != null)
            {
                return Ok(mappedTeacher);
            }
            return NotFound();
        }
    }
}
