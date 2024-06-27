using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CategoryEnum Category { get; set; }
        public List<Skill> Skills { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}