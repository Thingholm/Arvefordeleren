using ArvefordelerenWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AssetsRepositoryTests
{
    [TestClass]
    public class AssetsRepositoryTests
    {
        private List<Asset> initialAssets;

        [TestInitialize]
        public void Setup()
        {
            // Reset the repository to a known state before each test
            initialAssets = new List<Asset>()
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

            typeof(AssetsRepository)
                .GetField("assets", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                ?.SetValue(null, initialAssets);
        }

        [TestMethod]
        public void GetAssets_ShouldReturnAllAssets()
        {
            // Act
            var assets = AssetsRepository.GetAssets();

            // Assert
            Assert.IsNotNull(assets);
            Assert.AreEqual(2, assets.Count);
        }

        [TestMethod]
        public void GetAssetById_ShouldReturnCorrectAsset()
        {
            // Act
            var asset = AssetsRepository.GetAssetById(1);

            // Assert
            Assert.IsNotNull(asset);
            Assert.AreEqual("Kontanter", asset.Name);
        }

        [TestMethod]
        public void AddAsset()
        {
            // Arrange
            var newAsset = new Asset
            {
                Name = "Bil",
                Value = 100.0,
                Liquid = false
            };

            // Act
            AssetsRepository.AddAsset(newAsset);

            // Assert
            var assets = AssetsRepository.GetAssets();
            Assert.AreEqual(3, assets.Count);
            Assert.AreEqual(3, newAsset.Id);
            Assert.IsTrue(assets.Any(a => a.Name == "Bil" && a.Value == 100.0 && !a.Liquid));
        }

        [TestMethod]
        public void UpdateAsset()
        {
            // Arrange
            var updatedAsset = new Asset
            {
                Id = 1,
                Name = "Opdaterede Kontanter",
                Value = 15.0,
                Liquid = false
            };

            // Act
            AssetsRepository.UpdateAsset(updatedAsset);

            // Assert
            var asset = AssetsRepository.GetAssetById(1);
            Assert.IsNotNull(asset);
            Assert.AreEqual("Opdaterede Kontanter", asset.Name);
            Assert.AreEqual(15.0, asset.Value);
            Assert.IsFalse(asset.Liquid);
        }

        [TestMethod]
        public void DeleteAsset()
        {
            // Arrange
            var assetToDelete = AssetsRepository.GetAssetById(1);

            // Act
            AssetsRepository.DeleteAsset(assetToDelete);

            // Assert
            var assets = AssetsRepository.GetAssets();
            Assert.AreEqual(1, assets.Count);
            Assert.IsFalse(assets.Any(a => a.Id == 1));
        }
    }
}
