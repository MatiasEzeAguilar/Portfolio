using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio;

namespace Controllers
{
    [Route("api/Experience")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly ExperienceRepository _repo;
        private readonly PortfolioContext _context;
        public ExperienceController(ExperienceRepository repo, PortfolioContext context)
        {
            _repo = repo;
            _context = context;
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
            Experience experience = _context.Experiences.First(a => a.Id == id);
            experience.Summary = body.Summary;
            experience.Description = body.Description;
            experience.Category = body.Category;
            experience.ImagePath = body.ImagePath;
            experience.Skills = body.Skills;
            _context.Experiences.Update(experience);
            _context.SaveChanges();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteExperience(int id)
        {
            return Ok(_repo.Delete(id));
        }
    }
}