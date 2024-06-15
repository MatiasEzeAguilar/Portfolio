using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalPortfolio
{
    public class Experience
    {
        [Required]
        [MaxLength(70)]
        public string? Title { get; set; }
        [Required]
        [MaxLength(230)]
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public TagsAttribute? Aptitudes { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string State { get; set; } = "Active";
    }
}