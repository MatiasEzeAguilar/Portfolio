using System.ComponentModel.DataAnnotations;

namespace PersonalPortfolio
{
    public class SkillToAdd
    {
        [Required]
        public string? Name {get; set;}
    }
}