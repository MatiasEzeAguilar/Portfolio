using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio;

namespace Controllers
{
    [Route("api/Skill")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private SkillRepository _repo;
        public SkillController(SkillRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_repo.Get());
        }

        [HttpPost]
        public ActionResult AddSkill([FromBody] SkillToAdd body)
        {
            var newSkill = new Skill()
            {
                Name = body.Name,
            };
            return Ok(_repo.AddSkill(newSkill));
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteSkill(int id)
        {
            return Ok(_repo.DeleteSkill(id));
        }
    }
}