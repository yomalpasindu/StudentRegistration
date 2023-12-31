﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Modles;
using StudentRegistration.Modles.Parameters;
using StudentRegistration.Services.Student_;

namespace StudentRegistration.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetStudents([FromQuery] QueryParameters queryParameters)
        {
            var students=_studentRepository.GetStudents(queryParameters);
            var mappedStudents = _mapper.Map<ICollection<ViewStudentDto>>(students);
            return Ok(mappedStudents);
        }

        [HttpGet("{id}")]
        public ActionResult GetStudent(int id)
        {

            var student=_studentRepository.GetStudent(id);
            var mappedStudent=_mapper.Map<ViewStudentDto>(student);
            return Ok(mappedStudent);
        }
        [HttpPost]
        public ActionResult AddStudent(CreateStudentDto student)
        {
            var mappedStudent=_mapper.Map<Students>(student);
            var insertStudent=_studentRepository.InsertStudents(mappedStudent);
            var getAddedStudent = GetStudent(insertStudent.Id);
            return Ok(getAddedStudent);
        }
        [HttpDelete]
        public ActionResult DeleteStudent(int id)
        {
            var deletedStudent=_studentRepository.DeleteStudent(id);
            if (deletedStudent == true)
            {
                return Ok("Successfully Removed! (Student Id-"+id+")");
            }
            return NotFound("Student Id not found!! (Id-" + id + ")");
        }

        [HttpPut]
        public ActionResult UpdateStudent(UpdateStudentDto student)
        {
            var mappedStudent=_mapper.Map<Students>(student);
            var updateStudent=_studentRepository.UpdateStudent(mappedStudent);
            return Ok(GetStudent(updateStudent.Id));
        }
    }
}
