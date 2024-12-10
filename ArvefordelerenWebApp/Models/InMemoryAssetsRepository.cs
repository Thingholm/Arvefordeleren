namespace ArvefordelerenWebApp.Models
{
    public class InMemoryAssetsRepository : IAssetsRepository
    {
        public List<Asset> Assets { get; } = new List<Asset>();

        public void AddAsset(Asset asset)
        {
            Assets.Add(asset);
        }
    }
}
