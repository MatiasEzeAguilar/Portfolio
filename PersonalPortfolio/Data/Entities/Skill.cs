using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PersonalPortfolio
{
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [JsonIgnore]
        public string State { get; set; } = "Active";
    }
}