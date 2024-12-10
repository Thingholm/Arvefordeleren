namespace ArvefordelerenWebApp.Models
{
    public class InMemoryAssetsRepository : IAssetsRepository
    {
        public List<Asset> Assets { get; } = new List<Asset>();

        public List<Asset> GetAssets()
        {
            return Assets;  // Returnere listen af assets
        }

        public void AddAsset(Asset asset)
        {
            Assets.Add(asset);
        }
    }
}
