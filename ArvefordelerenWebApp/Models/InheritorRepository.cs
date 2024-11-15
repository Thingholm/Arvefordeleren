namespace ArvefordelerenWebApp.Models;

public static class InheritorRepository 
{
    private static List<Inheritor> _inheritors = new List<Inheritor>()
     {
        new Inheritor{Name = "Frederikke"},
        new Inheritor{Name = "Gustav"},
        new Inheritor{Name = "Kristoffer"},
        new Inheritor{Name = "Rasmus"},
        new Inheritor{Name = "Denis"},
       
     };

     public static List<Inheritor> GetInheritors() => _inheritors;


}