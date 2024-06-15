using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private PortfolioContext _portContext;
        public ExperienceController(PortfolioContext portfolioContext)
        {
            _portContext = portfolioContext;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_portContext.GetAll());
        }

        [HttpGet("{idExperience}")]
        public ActionResult Get(int idExperience)
        {
            var experienceToReturn = _portContext.Get(idExperience);
            return Ok(experienceToReturn);
        }

        [HttpGet("search")]
        public ActionResult GetBySearchParameters([FromQuery]string searchCriteria)
        {
            return Ok(_portContext.GetBySearchParameters(searchCriteria));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExperience(int id)
        {
            return Ok(_portContext.Delete(id));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateExperience(int id, [FromBody] ExperienceToUpdate body)
        {

            Experience exp = _portContext.Experiences.FirstOrDefault(a => a.Id == id);
            exp.Description = body.Description ?? exp.Description;
            exp.Summary = body.Summary ?? exp.Summary;
            exp.Aptitudes = body.Aptitudes ?? exp.Aptitudes;
            exp.ImagePath = body.ImagePath ?? exp.ImagePath;
            _portContext.Experiences.Update(exp);
            _portContext.SaveChanges();
            return NoContent();
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
                Aptitudes = body.Aptitudes
            }; 
            return Ok(_portContext.AddExperience(newExperience));
        }
    }
}