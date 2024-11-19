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

    private static int GenerateNewId() => assets.MaxBy(x => x.Id)?.Id + 1 ?? 1;

    public static List<Asset> GetAssets() => assets.ToList();

     public static Asset? GetAssetById(int id) => assets.FirstOrDefault(a => a.Id == id);

    public static void AddAsset(string name, double? value, bool liquid)
    {
        if (string.IsNullOrWhiteSpace(name)) return;

        int id = GenerateNewId();
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

            asset.Id = GenerateNewId();
            assets.Add(asset);
        }

        public static void UpdateAsset(Asset asset)
        {
            var existingAsset = GetAssetById(asset.Id);
            if (existingAsset != null)
            {
                existingAsset.Name = asset.Name;
                existingAsset.Value = asset.Value;
                existingAsset.Liquid = asset.Liquid;
            }
        }

   
    public static void UpdateAsset1(int assetId, Asset Asset)
    {
        if (assetId != Asset.Id) return;

        var assetToUpdate = assets.FirstOrDefault(a => a.Id == assetId);
        if (assetToUpdate != null)
        {
            assetToUpdate.Name = Asset.Name;
            assetToUpdate.Value = Asset.Value;
            assetToUpdate.Liquid = Asset.Liquid;
        }
    }

    
    public static void DeleteAsset(Asset asset)
    {
        assets.Remove(asset);
    }



}