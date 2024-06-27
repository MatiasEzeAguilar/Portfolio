using System.Text.Json.Serialization;

namespace PersonalPortfolio;

class ExperienceToReturn
{
    public string? Title {get; set;}
    public string? Summary {get; set;}
    public string? Description {get; set;}
    public DateTime Date {get;set;}
    public string? ImagePath {get;set;}
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CategoryEnum Category {get; set;}
    public List<Skill> Skills {get; set;}
}
