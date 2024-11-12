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
}