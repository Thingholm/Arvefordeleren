using System.ComponentModel.DataAnnotations;
namespace ArvefordelerenWebApp.Models;
public class Inheritor
{
    [Required]
    public string? Name {get; set;}

    // public Inheritor(string name) 
    // {
    //     Name = name;
    // }
    
    public Inheritor()
    {
        
    }
        

}