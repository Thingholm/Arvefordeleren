namespace ArvefordelerenWebApp.Models
{
    public interface IAssetsRepository
    {
        List<Asset> GetAssets();
        void AddAsset(Asset asset);
    }
}
