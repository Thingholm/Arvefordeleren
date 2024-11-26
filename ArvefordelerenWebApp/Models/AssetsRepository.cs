using System.Text.Json;
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
            Value = 1950000, 
            Liquid = true
        },
        new Asset
        {
            Id = 2,
            Name = "Hus",
            Value = 3500000,
            Liquid = false
        }
    };

    public static List<Asset> GetAssets() => assets.ToList();
    public static event Action? OnChange;

    public static Asset? GetAssetById(int id) => assets.FirstOrDefault(a => a.Id == id);

    public static List<Asset> GetAssetsByRightOfWithdrawal(Inheritor inheritor)
    {
        return assets.Where(asset => asset.RightOfWithdrawal?.Id == inheritor.Id).ToList();
    }

    public static void AddAsset(string name, double? value, bool liquid, Inheritor? rightOfWithdrawal)
    {
        if (string.IsNullOrWhiteSpace(name)) return;

        int id = assets.GenerateId();
        assets.Add(new Asset
        {
            Id = id,
            Name = name,
            Value = value,
            Liquid = liquid,
            RightOfWithdrawal = rightOfWithdrawal
        });
        NotifyChange();
    }
    
    
    public static void AddAsset(Asset asset)
    {
        if (asset == null || string.IsNullOrWhiteSpace(asset.Name)) return;

        asset.Id = assets.GenerateId();
        assets.Add(asset);
        NotifyChange();
    }

    public static void UpdateAsset(Asset asset)
    {
        Asset? existingAsset = GetAssetById(asset.Id);

        if (existingAsset == null) return;

        existingAsset.Name = asset.Name;
        existingAsset.Value = asset.Value;
        existingAsset.Liquid = asset.Liquid;
        existingAsset.RightOfWithdrawal = asset.RightOfWithdrawal;
    }

    public static void UpdateAssets(List<Asset> assetsToUpdate)
    {
        foreach(Asset asset in assetsToUpdate)
        {
            UpdateAsset(asset);
        }
    }

    public static void DeleteAsset(Asset asset)
    {
        assets.Remove(asset);
        NotifyChange();
    }
    private static void NotifyChange() => OnChange?.Invoke();

    public static string GetAssetsAsJson()
    {
        return JsonSerializer.Serialize(assets, new JsonSerializerOptions {WriteIndented = true});
    }
}