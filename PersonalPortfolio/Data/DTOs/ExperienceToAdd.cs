using System.ComponentModel.DataAnnotations;

namespace PersonalPortfolio
{
    public class ExperienceToAdd
    {
        [Required]
        [MaxLength(70)]
        public string? Title {get; set;}
        [Required]
        [MaxLength(230)]
        public string? Summary {get; set;}
        public string? Description {get; set;}
        public string? ImagePath {get;set;}
        public ExperienceAptitudEnum Aptitudes { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}