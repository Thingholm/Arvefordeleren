using System.Text.Json;
using ArvefordelerenWebApp.Models;

namespace ArvefordelerenWebApp.Services;

public static class RepositoryUpdateService
{
    public static void UpdateRepositoriesFromJson(string jsonContent)
    {
        var data = JsonSerializer.Deserialize<UploadData>(jsonContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (data == null) throw new InvalidDataException("Invalid JSON format in the uploaded file.");

        foreach (Asset asset in data.Assets)
        {
            AssetsRepository.AddAsset(asset);
        }

        foreach (Inheritor inheritor in data.Inheritors)
        {
            InheritorRepository.AddInheritor(inheritor);
        }
    }

    private class UploadData
    {
        public List<Asset> Assets {get; set;} = new();
        public List<Inheritor> Inheritors {get; set;} = new();
    }
}