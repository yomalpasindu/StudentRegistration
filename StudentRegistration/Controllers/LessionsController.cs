using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Modles;
using StudentRegistration.Modles.Parameters;
using StudentRegistration.Services.Lession_;

namespace StudentRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessionsController : ControllerBase
    {
        private readonly ILessionsRepository _lessionsRepository;
        private readonly IMapper _mapper;
        public LessionsController(ILessionsRepository lessionsRepository, IMapper mapper) 
        {
            _lessionsRepository = lessionsRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetAllLessions([FromQuery]QueryParameters queryParameters)
        {
            var lessions = _lessionsRepository.GetAllLessions(queryParameters);
            if (lessions != null)
            {
                var mappedLessions = _mapper.Map<ICollection<ViewLessionsDto>>(lessions);
                return Ok(mappedLessions);
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult GetLession(int id)
        {
            var lession=_lessionsRepository.GetLession(id);
            if (lession != null)
                return Ok(lession);
            else
                return NoContent();
        }
        [HttpPost]
        public ActionResult InsertLession(CreateLessionDto lession)
        {
            var mappedLession = _mapper.Map<Lessions>(lession);
            var addLession=_lessionsRepository.InsertLession(mappedLession);
            if (addLession != null)
            {
                var mappedForView=_mapper.Map<ViewLessionsDto>(addLession);
                return Ok(mappedForView);
            }
            return NoContent();
        }
        [HttpPut]
        public ActionResult UpdateLession(UpdateLessionDto lession)
        {
            var mappedLession=_mapper.Map<Lessions>(lession);
            var updateLession=_lessionsRepository.UpdateLession(mappedLession);
            if (updateLession != null)
            {
                var mappedForView=_mapper.Map<ViewLessionsDto>(updateLession);
                return Ok(mappedForView);
            }
            return NotFound();
        }
        [HttpDelete]
        public String DeleteLession(int id)
        {
            var lession=_lessionsRepository.DeleteLession(id);
            if(lession)
            return "Lession Sucessfully Removed!";
            return "Lession not found!";
        }
    }
}
