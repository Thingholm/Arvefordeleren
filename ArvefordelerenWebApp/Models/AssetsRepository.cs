namespace ArvefordelerenWebApp.Models;

public static class AssetsRepository
{
    private static List<Asset> assets = new List<Asset>()
    {
        new Asset
        {
            Id = 1,
            Name = "Kontanter",
            Value = 10.12321312, 
            Liquid = true
        },
        new Asset
        {
            Id = 2,
            Name = "Hus",
            Value = 2.211,
            Liquid = false
        }
    };
    

    public static List<Asset> GetAssets()
    {
        return assets.ToList();
    }

    public static void AddAsset(string name, double? value, bool liquid)
    {
        if (name == null) return;

        int id = assets.MaxBy(x => x.Id)?.Id + 1 ?? 1;

        assets.Add
        ( 
            new Asset() 
            {
                Id = id,
                Name = name,
                Value = value,
                Liquid = liquid
            }
        );
    }

    public static void AddAsset(Asset asset)
    {
        if (asset.Name == null) return;

        int id = assets.MaxBy(x => x.Id)?.Id + 1 ?? 1;

        assets.Add(asset);
    }

    public static void DeleteAsset(Asset asset)
    {
        assets.Remove(asset);
    }
}