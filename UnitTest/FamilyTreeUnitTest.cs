using ArvefordelerenWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace InheritorRepositoryTests
{
    [TestClass]
    public class InheritorRepositoryTests
    {
        private List<Inheritor> initialInheritors;

        [TestInitialize]
        public void Setup()
        {

            initialInheritors = new List<Inheritor>
            {
                new Inheritor { Id = 1, Name = "Frederikke", InheritorType = InheritorType.Type1 },
                new Inheritor { Id = 2, Name = "Gustav", InheritorType = InheritorType.Type1 },
                new Inheritor { Id = 3, Name = "Kristoffer", InheritorType = InheritorType.Type1 },
                new Inheritor { Id = 4, Name = "Rasmus", InheritorType = InheritorType.Type3 },
                new Inheritor { Id = 5, Name = "Denis", InheritorType = InheritorType.Type2 }
            };
        }

        [TestMethod]
        public void GetInheritors()
        {
            // Act
            var inheritors = InheritorRepository.GetInheritors();

            // Assert
            Assert.IsNotNull(inheritors);
            Assert.AreEqual(5, inheritors.Count);
        }

        [TestMethod]
        public void GetInheritorById_ShouldReturnCorrectInheritor()
        {
            // Act
            var inheritor = InheritorRepository.GetInheritorById(1);

            // Assert
            Assert.IsNotNull(inheritor);
            Assert.AreEqual("Frederikke", inheritor.Name);
        }

        [TestMethod]
        public void GetInheritorById_InvalidId_ShouldReturnNull()
        {
            // Act
            var inheritor = InheritorRepository.GetInheritorById(99);

            // Assert
            Assert.IsNull(inheritor);
        }

        [TestMethod]
        public void UpdateInheritor_ShouldModifyExistingInheritor()
        {
            // Arrange
            var updatedInheritor = new Inheritor
            {
                Id = 1,
                Name = "Updated Frederikke",
                InheritorType = InheritorType.Type2
            };

            // Act
            InheritorRepository.UpdateInheritor(updatedInheritor);

            // Assert
            var inheritor = InheritorRepository.GetInheritorById(1);
            Assert.IsNotNull(inheritor);
            Assert.AreEqual("Updated Frederikke", inheritor.Name);
            Assert.AreEqual(InheritorType.Type2, inheritor.InheritorType);
        }

        [TestMethod]
        public void UpdateInheritor_InvalidId_ShouldNotChangeRepository()
        {
            // Arrange
            var updatedInheritor = new Inheritor
            {
                Id = 99,
                Name = "Nonexistent Inheritor",
                InheritorType = InheritorType.Type1
            };

            // Act
            InheritorRepository.UpdateInheritor(updatedInheritor);

            // Assert
            var inheritors = InheritorRepository.GetInheritors();
            Assert.AreEqual(5, inheritors.Count);
            Assert.IsFalse(inheritors.Any(i => i.Name == "Nonexistent Inheritor"));
        }
        [TestMethod]
        public void AddInheritor_ShouldAddNewInheritor()
        {
            // Arrange
            Inheritor newInheritor = new Inheritor
            {
                Name = "Gulle",
                InheritorType = InheritorType.Type3
            };

            // Act
            InheritorRepository.AddInheritor(newInheritor);

            // Assert
            var inheritors = InheritorRepository.GetInheritors();
            Assert.AreEqual(6, inheritors.Count);
            Assert.IsTrue(inheritors.Any(i => i.Name == "Gulle" && i.InheritorType == InheritorType.Type3));
            Assert.AreEqual(6, newInheritor.Id); // Ensure the new inheritor has the correct ID
            Assert.AreEqual("Gulle", newInheritor.Name);
        }
    }
}
