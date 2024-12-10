using ArvefordelerenWebApp.Models;
using ArvefordelerenWebApp.Services;

namespace UpdateServiceUnitTest;

[TestClass]
public class RepositoryUpdateServiceTests
{
    private InMemoryAssetsRepository _assetsRepository;
    private InMemoryInheritorRepository _inheritorRepository;
    private RepositoryUpdateService _repositoryUpdateService;

    [TestInitialize]
    public void SetUp()
    {
        _assetsRepository = new InMemoryAssetsRepository();
        _inheritorRepository = new InMemoryInheritorRepository();
        _repositoryUpdateService = new RepositoryUpdateService(_assetsRepository, _inheritorRepository);
    }

    [TestMethod]
    public void UpdateRepositoriesFromJson_ValidJson_UpdatesRepositories()
    {
        // Arrange
        var jsonContent = @"
        {
            ""Assets"": [
                { ""Id"": 1, ""Name"": ""Asset 1"", ""Value"": 1000 },
                { ""Id"": 2, ""Name"": ""Asset 2"", ""Value"": 2000 }
            ],
            ""Inheritors"": [
                { ""Id"": 1, ""Name"": ""Inheritor 1"" },
                { ""Id"": 2, ""Name"": ""Inheritor 2"" }
            ]
        }";

        // Act
        _repositoryUpdateService.UpdateRepositoriesFromJson(jsonContent);

        // Assert
        Assert.AreEqual(2, _assetsRepository.Assets.Count);
        Assert.AreEqual(2, _inheritorRepository.Inheritors.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidDataException))]
    public void UpdateRepositoriesFromJson_InvalidJson_ThrowsInvalidDataException()
    {
        // Arrange
        var invalidJsonContent = "{ invalid json }";

        // Act
        _repositoryUpdateService.UpdateRepositoriesFromJson(invalidJsonContent);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidDataException))]
    public void UpdateRepositoriesFromJson_EmptyJson_ThrowsInvalidDataException()
    {
        // Arrange
        var emptyJsonContent = "{}";

        // Act
        _repositoryUpdateService.UpdateRepositoriesFromJson(emptyJsonContent);
    }
}
