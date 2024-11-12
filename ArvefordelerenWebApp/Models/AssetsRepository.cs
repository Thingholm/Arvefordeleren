namespace ArvefordelerenWebApp.Models;

public static class AssetsRepository
{
    private static List<Asset> assets = new List<Asset>();
    
    public static List<Asset> GetAssets()
    {
        return assets.ToList();
    }
    
}