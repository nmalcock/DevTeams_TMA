using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMA_Classes;

namespace TMA_Tests
{
    [TestClass]
    public class DevTeamRepo_Tests
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            Developer testDeveloper = new Developer(1, "John", "Jacoby", true);
            Developer testDeveloper2 = new Developer(2, "Nick", "Alcock", true);
            DevTeam newTeam = new DevTeam(testDeveloper, "backend", 2);
            DevTeam newTeam2 = new DevTeam(testDeveloper2, "backend", 2);

            DevTeamRepo repository = new DevTeamRepo();

            bool addResult = repository.AddTeamToDirectory(newTeam);
            bool addResult2 = repository.AddTeamToDirectory(newTeam2);

            Assert.IsTrue(addResult && addResult2);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            Developer testDeveloper = new Developer(1, "John", "Jacoby", true);
            DevTeam testTeam = new DevTeam(testDeveloper, "BackEnd", 1);

            DevTeamRepo repo = new DevTeamRepo();
            repo.AddTeamToDirectory(testTeam);

            List<DevTeam> teams = repo.GetDevTeams();
            bool directoryHasTeam = teams.Contains(testTeam);

            Assert.IsTrue(directoryHasTeam);
        }

        private Developer _developer;
        private DeveloperRepo _repo;
        private DevTeam _team;
        private DevTeamRepo _teamRepo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new DeveloperRepo();
            _developer = new Developer(1, "John", "Jacoby", false);
            
            _repo.AddDeveloperToDirectory(_developer);

            _team = new DevTeam(_developer, "gold", 1);
            _teamRepo = new DevTeamRepo();

            _teamRepo.AddTeamToDirectory(_team);
        }

        [TestMethod]
        public void GetByTeamID_ShouldReturnCorrectTeam()
        {
            DevTeam searchResult = _teamRepo.GetDevTeamsByTeamID(1);
            Assert.AreEqual(_team, searchResult);
        }

        [TestMethod]
        public void UpdateExistingDevTeam_ShouldReturnTrue()
        {
            //arrange
            DevTeam updatedInfo = new DevTeam(_developer, "blue", 1);
            //Act!
            bool updateResult = _teamRepo.UpdateCurrentDevTeam(1, updatedInfo);
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingDevTeam_ShouldReturnTrue()
        {
            //Arrange
            DevTeam foundContent = _teamRepo.GetDevTeamsByTeamID(1);
            //ACT!
            bool removeResult = _teamRepo.DeleteCurrentTeam(foundContent);
            //Assert
            Assert.IsTrue(removeResult);
        }

        [TestMethod]
        public void DeleteDevTeam_ShouldReturnTrue()
        {
            DevTeam foundContent = _teamRepo.GetDevTeamsByTeamID(1);
            bool removeResult = _teamRepo.DeleteDevFromTeam(1, 1, foundContent);
            Assert.IsTrue(removeResult);
        }

    }
}
