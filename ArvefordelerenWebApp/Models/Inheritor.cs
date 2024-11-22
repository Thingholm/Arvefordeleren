using System.ComponentModel.DataAnnotations;
namespace ArvefordelerenWebApp.Models;
public class Inheritor
{
    [Required]
    public int Id { get; set; }
    public string? Name {get; set;}
    public InheritorType InheritorType {get; set;}
    
}
public enum InheritorType
{
    // Necessary for Blazorise Select component validator to register no selected option
    TypeEmpty = 0,
    Type1 = 1,
    Type2 = 2,
    Type3 = 3
}