using System.ComponentModel.DataAnnotations;
namespace ArvefordelerenWebApp.Models;
public class Inheritor
{
    [Required]
    public string Name {get; set;} = null!;

    public Inheritor() {}

    public Inheritor(string name) 
    {
        Name = name;
    }
        

}