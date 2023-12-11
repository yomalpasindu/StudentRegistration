using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Modles;
using StudentRegistration.Modles.Parameters;
using StudentRegistration.Services.Course_;

namespace StudentRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IMapper _mapper;
        public CoursesController(ICoursesRepository coursesRepository,IMapper mapper)
        {
            _coursesRepository= coursesRepository;
            _mapper=mapper;
        }
        [HttpGet]
        public IActionResult GetCourses([FromQuery]QueryParameters queryParameters)
        {
            var courses= _coursesRepository.GetCourses(queryParameters);
            var mappedCourses=_mapper.Map<ICollection<ViewCourseDto>>(courses);
            if (mappedCourses != null)
            {
                return Ok(mappedCourses);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult GetCourse(int id)
        {
            var course= _coursesRepository.GetCourse(id);
            var mappedCourse=_mapper.Map<ViewCourseDto>(course);
            if(mappedCourse!=null)
            {
                return Ok(mappedCourse);
            }
            return NotFound();
        }
        [HttpPut]
        public ActionResult UpdateCourse(UpdateCourseDto courses)
        {
            var mappedCourse=_mapper.Map<Courses>(courses);
            var updateCourse=_coursesRepository.UpdateCourse(mappedCourse);
            var mappedForView = _mapper.Map<ViewCourseDto>(updateCourse);
            if (updateCourse != null)
            {
                return Ok(mappedForView);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult InsertCourse(CreateCourseDto course) 
        {
            var mappedCourse = _mapper.Map<Courses>(course);
            var createCourse=_coursesRepository.InsertCourse(mappedCourse);
            var mappedForView = _mapper.Map<ViewCourseDto>(createCourse);
            if(mappedForView != null)
            {
                return Ok(mappedForView);
            }
            return BadRequest();
        }
        [HttpDelete]
        public string DeleteCourse(int id)
        {
            var removeCourse=_coursesRepository.DeleteCourse(id);
            if (removeCourse == true)
                return ("Course Sucessfully Removed!");
            else
                return ("Course not found!");
        }
    }
}
