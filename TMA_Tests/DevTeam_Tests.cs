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
    public class DevTeam_Tests
    {
        [TestMethod]
        public void SetTeamName_ShouldSetCorrectString()
        {
            DevTeam newTeam = new DevTeam();

            newTeam.TeamName = "Gold Team";

            string expected = "Gold Team";
            string actual = newTeam.TeamName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetTeamID_ShouldSetCorrectInt()
        {
            DevTeam newTeam = new DevTeam();

            newTeam.TeamID = 1;

            int expected = 1;
            int actual = newTeam.TeamID;

            Assert.AreEqual(expected, actual);
        }
    }
}
