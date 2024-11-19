namespace ArvefordelerenWebApp.Models;

public static class InheritorRepository 
{
    private static List<Inheritor> _inheritors = new List<Inheritor>()
     {
        new Inheritor{Id = 1, Name = "Frederikke", ArveKlasse = ArveKlasse.Type1},
        new Inheritor{Id = 2, Name = "Gustav", ArveKlasse = ArveKlasse.Type1},
        new Inheritor{Id = 3, Name = "Kristoffer", ArveKlasse = ArveKlasse.Type1},
        new Inheritor{Id = 4, Name = "Rasmus", ArveKlasse = ArveKlasse.Type3},
        new Inheritor{Id = 5, Name = "Denis", ArveKlasse = ArveKlasse.Type2},
       
     };

     public static List<Inheritor> GetInheritors() => _inheritors;

     public static Inheritor? GetInheritorById(int id) => _inheritors.FirstOrDefault(i => i.Id == id);

     public static void UpdateInheritor(Inheritor inheritor)
     {
         Inheritor existingInheritor = GetInheritorById(inheritor.Id);
         if (existingInheritor != null)
         {
            existingInheritor.Name = inheritor.Name;
            existingInheritor.ArveKlasse = inheritor.ArveKlasse;
         }
     }


}