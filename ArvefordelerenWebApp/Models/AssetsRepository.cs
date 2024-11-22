using ArvefordelerenWebApp.Utilities;

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

    public static List<Asset> GetAssets() => assets.ToList();

     public static Asset? GetAssetById(int id) => assets.FirstOrDefault(a => a.Id == id);

    public static void AddAsset(string name, double? value, bool liquid)
    {
        if (string.IsNullOrWhiteSpace(name)) return;

        int id = assets.GenerateId();
        assets.Add(new Asset
        {
            Id = id,
            Name = name,
            Value = value,
            Liquid = liquid
        });
    }
    
    
    public static void AddAsset(Asset asset)
    {
        if (asset == null || string.IsNullOrWhiteSpace(asset.Name)) return;

        asset.Id = assets.GenerateId();
        assets.Add(asset);
    }

    public static void UpdateAsset(Asset asset)
    {
        Asset? existingAsset = GetAssetById(asset.Id);

        if (existingAsset == null) return;

        existingAsset.Name = asset.Name;
        existingAsset.Value = asset.Value;
        existingAsset.Liquid = asset.Liquid;
    }

    public static void DeleteAsset(Asset asset)
    {
        assets.Remove(asset);
    }
}