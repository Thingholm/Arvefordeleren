using System.Text.Json;
using ArvefordelerenWebApp.Models;

namespace ArvefordelerenWebApp.Services;

public class RepositoryUpdateService
{
    private readonly IAssetsRepository _assetsRepository;
    private readonly IInheritorRepository _inheritorRepository;

    public RepositoryUpdateService(IAssetsRepository assetsRepository, IInheritorRepository inheritorRepository)
    {
        _assetsRepository = assetsRepository;
        _inheritorRepository = inheritorRepository;
    }

    public void UpdateRepositoriesFromJson(string jsonContent)
    {
        if (string.IsNullOrWhiteSpace(jsonContent))
        {
            throw new InvalidDataException("Empty JSON content.");
        }

        try
        {
            var data = JsonSerializer.Deserialize<UploadData>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (data == null || (data.Assets.Count == 0 && data.Inheritors.Count == 0))
            {
                throw new InvalidDataException("Invalid JSON format in the uploaded file.");
            }

            foreach (Asset asset in data.Assets)
            {
                _assetsRepository.AddAsset(asset);
            }

            foreach (Inheritor inheritor in data.Inheritors)
            {
                _inheritorRepository.AddInheritor(inheritor);
            }
        }
        catch (JsonException)
        {
            throw new InvalidDataException("Invalid JSON format in the uploaded file.");
        }
    }




    private class UploadData
    {
        public List<Asset> Assets { get; set; } = new();
        public List<Inheritor> Inheritors { get; set; } = new();
    }
}
