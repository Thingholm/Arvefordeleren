using System.ComponentModel.DataAnnotations;
namespace ArvefordelerenWebApp.Models;
public class Inheritor
{
    [Required]
    public int Id { get; set; }
    public string? Name {get; set;}
    public ArveKlasse ArveKlasse {get; set;}
    
    public Inheritor()
    {
        
    }

}
public enum ArveKlasse
{
    Type1 = 1,
    Type2 = 2,
    Type3 = 3
}