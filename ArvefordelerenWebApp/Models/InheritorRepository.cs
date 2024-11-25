using ArvefordelerenWebApp.Utilities;

namespace ArvefordelerenWebApp.Models;

public static class InheritorRepository 
{
    private static List<Inheritor> inheritors = new List<Inheritor>()
    {
        new Inheritor{Id = 1, Name = "Frederikke", InheritorType = InheritorType.Type1},
        new Inheritor{Id = 2, Name = "Gustav", InheritorType = InheritorType.Type1},
        new Inheritor{Id = 3, Name = "Kristoffer", InheritorType = InheritorType.Type1},
        new Inheritor{Id = 4, Name = "Rasmus", InheritorType = InheritorType.Type3},
        new Inheritor{Id = 5, Name = "Denis", InheritorType = InheritorType.Type2},
    };

    public static List<Inheritor> GetInheritors() => inheritors.ToList();

    public static Inheritor? GetInheritorById(int id) => inheritors.FirstOrDefault(i => i.Id == id);

    public static void AddInheritor(string name, InheritorType inheritorType)
    {
        if (string.IsNullOrWhiteSpace(name)) return;

        int id = inheritors.GenerateId();
        Console.WriteLine(id);
        inheritors.Add(new Inheritor
        {
            Id = id,
            Name = name,
            InheritorType = inheritorType
        });
    }
    
    public static void AddInheritor(Inheritor inheritor)
    {
        if (inheritor == null || string.IsNullOrWhiteSpace(inheritor.Name)) return;

        inheritor.Id = inheritors.GenerateId();
        Console.WriteLine(inheritor.Id);
        inheritors.Add(inheritor);
    }

    public static void UpdateInheritor(Inheritor inheritor)
    {
        Inheritor? existingInheritor = GetInheritorById(inheritor.Id);

        if (existingInheritor == null) return;

        existingInheritor.Name = inheritor.Name;
        existingInheritor.InheritorType = inheritor.InheritorType;
    }

    public static void DeleteInheritor(Inheritor inheritor)
    {
        List<Asset> assets = AssetsRepository
            .GetAssetsByRightOfWithdrawal(inheritor)
            .Select(asset => 
                new Asset
                { 
                    Id = asset.Id,
                    Name = asset.Name,
                    Value = asset.Value,
                    Liquid = asset.Liquid
                }
            )
            .ToList();

        AssetsRepository.UpdateAssets(assets);        

        inheritors.Remove(inheritor);
    }
}