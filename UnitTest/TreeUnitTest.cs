using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArvefordelerenWebApp;
using ArvefordelerenWebApp.Models;

namespace UnitTest
{
    [TestClass]
    public class InheritorRepositoryTests
    {
        [TestInitialize]
        public void Setup()
        {
            typeof(InheritorRepository)
                .GetField("inheritors", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                ?.SetValue(null, new List<Inheritor>
                { new Inheritor { Id = 1, Name = "Frederikke", InheritorType = InheritorType.Type1 },
                    new Inheritor { Id = 2, Name = "Gustav", InheritorType = InheritorType.Type1 },
                    new Inheritor { Id = 3, Name = "Kristoffer", InheritorType = InheritorType.Type1 },
                    new Inheritor { Id = 4, Name = "Rasmus", InheritorType = InheritorType.Type3 },
                    new Inheritor { Id = 5, Name = "Denis", InheritorType = InheritorType.Type2 },
                });
        }
        
        [TestMethod]
        public void GetInheritors_ShouldReturnAllInheritors()
        {
            // Act
            var result = InheritorRepository.GetInheritors();

            // Assert
            Assert.AreEqual(5, result.Count);
            Assert.IsTrue(result.Any(i => i.Name == "Frederikke"));
            Assert.IsTrue(result.Any(i => i.Name == "Gustav"));
        }

        [TestMethod]
        public void AddInheritor_ShouldAddNewInheritor()
        {
            // Arrange
            var initialCount = InheritorRepository.GetInheritors().Count;
            
            // Act
            InheritorRepository.AddInheritor("Jens", InheritorType.Type2);

            // Assert
            var result = InheritorRepository.GetInheritors();
            Assert.AreEqual(initialCount + 1, result.Count);
            Assert.IsTrue(result.Any(i => i.Name == "Jens"));
        }
        [TestMethod]
        public void UpdateInheritor_ShouldUpdateExistingInheritor()
        {
            // Arrange
            var inheritor = new Inheritor { Id = 1, Name = "UpdatedName", InheritorType = InheritorType.Type3 };

            // Act
            InheritorRepository.UpdateInheritor(inheritor);

            // Assert
            var result = InheritorRepository.GetInheritorById(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("UpdatedName", result?.Name);
            Assert.AreEqual(InheritorType.Type3, result?.InheritorType);
        }

        [TestMethod]
        public void DeleteInheritor_ShouldRemoveInheritor()
        {
            // Arrange
            var inheritor = InheritorRepository.GetInheritorById(1);
            Assert.IsNotNull(inheritor);

            var initialCount = InheritorRepository.GetInheritors().Count;

            // Act
            InheritorRepository.DeleteInheritor(inheritor!);

            // Assert
            var result = InheritorRepository.GetInheritors();
            Assert.AreEqual(initialCount - 1, result.Count);
            Assert.IsFalse(result.Any(i => i.Id == 1));
        }

        [TestMethod]
        public void AddInheritor_ShouldNotAddWhenNameIsEmpty()
        {
            // Arrange
            var initialCount = InheritorRepository.GetInheritors().Count;

            // Act
            InheritorRepository.AddInheritor("", InheritorType.Type2);

            // Assert
            var result = InheritorRepository.GetInheritors();
            Assert.AreEqual(initialCount, result.Count);
        }


    }
}
