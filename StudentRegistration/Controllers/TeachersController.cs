using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Modles;
using StudentRegistration.Modles.Parameters;
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
        [HttpGet]
        public ActionResult GetTeachers([FromQuery]QueryParameters queryParameters)
        {
            var teachers = _teacherRepository.GetAllTeachers(queryParameters);
            if(teachers != null)
            {
                var mappedTeachers = _mapper.Map<ICollection<ViewTeacherDto>>(teachers);
                return Ok(mappedTeachers);
            }
            else
                return NoContent();
            
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


            if (teacher != null)
            {
                var mappedTeacher = _mapper.Map<ViewTeacherDto>(teacher);
                return Ok(mappedTeacher);
            }
            return NotFound();
        }
        [HttpPut]
        public ActionResult UpdateTeacher(UpdateTeacherDto teacher)
        {
            var mappedTeacher=_mapper.Map<Teachers>(teacher);
            if (mappedTeacher != null)
            {
                var updateTeacher = _teacherRepository.UpdateTeacher(mappedTeacher);
                var mappedForView=_mapper.Map<ViewTeacherDto>(updateTeacher); 
                return Ok(mappedForView);
            }
            return BadRequest();
        }
        [HttpDelete]
        public string DeleteTeacher(int id)
        {
            if (_teacherRepository.DeleteTeacher(id))
            {
                return ("Sucessfully Removed");
            }

            return ("Teacher not found!");
        }
    }
}
