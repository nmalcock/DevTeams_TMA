using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TMA_Classes;

namespace TMA_Tests
{
    [TestClass]
    public class DeveloperRepo_Tests
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            Developer newDev = new Developer();
            newDev.DeveloperID = 1;
            newDev.FirstName = "John";
            DeveloperRepo repository = new DeveloperRepo();

            bool addResult = repository.AddDeveloperToDirectory(newDev);
            Developer devFromDirectory = repository.GetDeveloperByID(1);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void AddTwoToDirectory_ShouldGetFalseBoolean()
        {
            Developer newDev = new Developer();
            newDev.DeveloperID = 1;
            newDev.FirstName = "John";
            DeveloperRepo repository = new DeveloperRepo();
            repository.AddDeveloperToDirectory(newDev);

            Developer sameDev = new Developer();
            sameDev.DeveloperID = 1;
            sameDev.FirstName = "Jake";

            bool added = repository.AddDeveloperToDirectory(sameDev);

            Assert.IsFalse(added);

        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            Developer testDeveloper = new Developer(1, "John", "Jacoby", true);

            DeveloperRepo repo = new DeveloperRepo();
            repo.AddDeveloperToDirectory(testDeveloper);

            List<Developer> developers = repo.GetDeveloper();
            bool directoryHasContent = developers.Contains(testDeveloper);

            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void GetUniqueID_ShouldReturnBool()
        {
            Developer testDev = new Developer(2, "jack", "johnson", false);

            DeveloperRepo repo = new DeveloperRepo();
            repo.AddDeveloperToDirectory(testDev);

            Developer nonUniqueDev = new Developer(2, "dirk", "duggerton", true);

            bool notUnique = repo.IsDeveloperIDUnique(nonUniqueDev);

            Assert.IsFalse(notUnique);
        }

        private Developer _developer;
        private DeveloperRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new DeveloperRepo();
            _developer = new Developer(1, "John", "Jacoby", false);
            _repo.AddDeveloperToDirectory(_developer);
        }

        [TestMethod]
        public void GetByID_ShouldReturnCorrectDeveloper()
        {
            Developer searchResult = _repo.GetDeveloperByID(1);
            Assert.AreEqual(_developer, searchResult);
        }

        [TestMethod]
        public void UpdateExistingDev_ShouldReturnTrue()
        {
            //arrange
            Developer updatedInfo = new Developer(1, "Jacob", "Evans", true);
            //Act!
            bool updateResult = _repo.UpdateCurrentDeveloper(1, updatedInfo);
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //Arrange
            Developer foundContent = _repo.GetDeveloperByID(1);
            //ACT!
            bool removeResult = _repo.DeleteCurrentDeveloper(foundContent);
            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}

