using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio;

namespace Controllers
{
    [Route("api/Experience")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private ExperienceRepository _repo;
        public ExperienceController(ExperienceRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{idExperience}")]
        public ActionResult Get(int idExperience)
        {
            var experienceToReturn = _repo.Get(idExperience);
            return Ok(experienceToReturn);
        }

        [HttpGet("search")]
        public ActionResult GetBySearchParameters([FromQuery]string searchCriteria)
        {
            return Ok(_repo.GetBySearchParameters(searchCriteria));
        }

        [HttpPost]
        public ActionResult AddExperience([FromBody] ExperienceToAdd body)
        {
            var newExperience = new Experience()
            {
                Description = body.Description,
                Date = DateTime.UtcNow,
                ImagePath = body.ImagePath,
                Summary = body.Summary,
                Title = body.Title,
                Category = body.Category,
                Skills = body.Skills
            };
            return Ok(_repo.AddExperience(newExperience));
        }
        
        [HttpPut("{id}")]
        public ActionResult UpdateExperience(int id, [FromBody] ExperienceToUpdate body)
        {
            var experienceToReturn = WorkExperience.Experiences.First(a => a.Id == id);
            experienceToReturn.Summary = body.Summary;
            experienceToReturn.Description = body.Description;
            experienceToReturn.Category = body.Category;
            experienceToReturn.ImagePath = body.ImagePath;
            experienceToReturn.Skills = body.Skills;
            _repo.AddExperience(experienceToReturn);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteExperience(int id)
        {
            return Ok(_repo.Delete(id));
        }
    }
}