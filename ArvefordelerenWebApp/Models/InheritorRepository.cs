namespace ArvefordelerenWebApp.Models;

public static class InheritorRepository
{
    private static List<Inheritor> _inheritors = new List<Inheritor>()
     {
        new Inheritor{Id = 1, Name = "Frederikke", InheritorType = InheritorType.Type1},
        new Inheritor{Id = 2, Name = "Gustav", InheritorType = InheritorType.Type1},
        new Inheritor{Id = 3, Name = "Kristoffer", InheritorType = InheritorType.Type1},
        new Inheritor{Id = 4, Name = "Rasmus", InheritorType = InheritorType.Type3},
        new Inheritor{Id = 5, Name = "Denis", InheritorType = InheritorType.Type2},

     };

    public static List<Inheritor> GetInheritors() => _inheritors.ToList();

    public static Inheritor? GetInheritorById(int id) => _inheritors.FirstOrDefault(i => i.Id == id);

    public static void UpdateInheritor(Inheritor inheritor)
    {
        Inheritor existingInheritor = GetInheritorById(inheritor.Id);
        if (existingInheritor != null)
        {
            existingInheritor.Name = inheritor.Name;
            existingInheritor.InheritorType = inheritor.InheritorType;
        }
    }


}