using System;
using System.IO;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArvefordelerenWebApp.Models;
using ArvefordelerenWebApp.Services;
using System.Collections.Generic;

namespace UnitTest
{

    // Fiktiv implementering af repositoryerne
    public class InMemoryAssetsRepository : IAssetsRepository
    {
        public List<Asset> Assets { get; } = new List<Asset>();

        public void AddAsset(Asset asset)
        {
            Assets.Add(asset);
        }
    }

    public class InMemoryInheritorRepository : IInheritorRepository
    {
        public List<Inheritor> Inheritors { get; } = new List<Inheritor>();

        public void AddInheritor(Inheritor inheritor)
        {
            Inheritors.Add(inheritor);
        }
    }

    [TestClass]
    public class RepositoryUpdateServiceTests
    {
        // Repositories med in-memory implementering
        private InMemoryAssetsRepository _assetsRepository;
        private InMemoryInheritorRepository _inheritorRepository;

        [TestInitialize]
        public void SetUp()
        {
            // Initialize the in-memory repositories
            _assetsRepository = new InMemoryAssetsRepository();
            _inheritorRepository = new InMemoryInheritorRepository();
        }

        [TestMethod]
        public void UpdateRepositoriesFromJson_ValidJson_UpdatesRepositories()
        {
            // Arrange: Create a valid JSON string for testing
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

            // Act: Call the method to update repositories from the JSON
            RepositoryUpdateService.UpdateRepositoriesFromJson(jsonContent);

            // Assert: Verify that assets and inheritors were added to the in-memory repositories
            Assert.AreEqual(2, _assetsRepository.Assets.Count);  // Verify 2 assets were added
            Assert.AreEqual(2, _inheritorRepository.Inheritors.Count);  // Verify 2 inheritors were added
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void UpdateRepositoriesFromJson_InvalidJson_ThrowsInvalidDataException()
        {
            // Arrange: Create invalid JSON content
            var invalidJsonContent = "{ invalid json }";

            // Act: Verify that an InvalidDataException is thrown for invalid JSON
            RepositoryUpdateService.UpdateRepositoriesFromJson(invalidJsonContent);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void UpdateRepositoriesFromJson_EmptyJson_ThrowsInvalidDataException()
        {
            // Arrange: Create empty JSON content
            var emptyJsonContent = "{}";

            // Act: Verify that an InvalidDataException is thrown for empty JSON
            RepositoryUpdateService.UpdateRepositoriesFromJson(emptyJsonContent);
        }
    }

}
