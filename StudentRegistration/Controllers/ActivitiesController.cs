using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Services.Activities_;

namespace StudentRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public ActivitiesController(IActivityRepository activityRepository,IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetActivities()
        {            
            var activities=_activityRepository.GetAllActivities();
            if (activities!=null)
            {
                var mappedActivities = _mapper.Map<ViewActivityDto>(activities);
                return Ok(mappedActivities);
            }
            return NotFound();
        }
    }
}
