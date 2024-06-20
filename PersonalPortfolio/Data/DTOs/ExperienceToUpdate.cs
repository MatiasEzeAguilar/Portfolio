using System.ComponentModel.DataAnnotations;

namespace PersonalPortfolio
{
    public class ExperienceToUpdate
    {
        [Required]
        [MaxLength(230)]
        public string? Summary {get; set;}
        public string? Description {get; set;}
        public string? ImagePath {get;set;}
        public ExperienceAptitudEnum Aptitudes { get; set; }
    }
}