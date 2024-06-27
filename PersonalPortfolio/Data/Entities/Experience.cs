using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PersonalPortfolio
{
    public class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(70)]
        public string? Title { get; set; }
        [MaxLength(230)]
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CategoryEnum Category { get; set; }
        public List<Skill> Skills {get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public string State { get; set; } = "Active";
    }
}