using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Modles;
using StudentRegistration.Modles.Parameters;
using StudentRegistration.Services.Activities_;
using System.Diagnostics;

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
        public ActionResult GetActivities([FromQuery]QueryParameters queryParameters)
        {            
            var activities=_activityRepository.GetAllActivities(queryParameters);
            if (activities!=null)
            {
                var mappedActivities = _mapper.Map<ICollection<ViewActivityDto>>(activities);
                return Ok(mappedActivities);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public ActionResult GetActivity(int id)
        {
            var activity = _activityRepository.GetActivity(id);
            var mappedActivity = _mapper.Map<ViewActivityDto>(activity);
            return Ok(mappedActivity);
        }

        [HttpPost]
        public ActionResult InsertActivities(CreateActivityDto activity)
        {
            var mappedActivity = _mapper.Map<Activities>(activity);
            var insertActivity=_activityRepository.InsertActivity(mappedActivity);
            var mappedForView = _mapper.Map<ViewActivityDto>(insertActivity);
            return Ok(mappedForView);
        }

        [HttpPut]
        public ActionResult UpdateActivity(UpdateActivityDto activity)
        {
            var mappedActivity=_mapper.Map<Activities>(activity);
            var updateActivity=_activityRepository.UpdateActivity(mappedActivity);
            var mappedForView=_mapper.Map<UpdateActivityDto>(updateActivity);
            return Ok(mappedForView);
        }
        [HttpDelete]
        public string DeleteActivity(int id)
        {
            var removeActivity=_activityRepository.DeleteActivity(id);
            if (removeActivity)
                return ("Activity Succesfully Removed!");
            return ("Activity not found!");
        }
    }
}
