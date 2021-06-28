using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TMA_Classes;

namespace TMA_Tests
{
    [TestClass]
    public class Developer_Tests
    {
        [TestMethod]
        public void SetDevID_ShouldSetCorrectInt()
        {
            Developer newDevID = new Developer();

            newDevID.DeveloperID = 1;

            int expected = 1;
            int actual = newDevID.DeveloperID;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetFName_ShouldSetCorrectString()
        {
            Developer newFName = new Developer();

            newFName.FirstName = "John";

            string expected = "John";
            string actual = newFName.FirstName;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void SetLName_ShouldSetCorrectString()
        {
            Developer newLName = new Developer();

            newLName.LastName = "Jacoby";

            string expected = "Jacoby";
            string actual = newLName.LastName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetPS_Access_ShouldSetCorrectBool()
        {
            Developer newPS_Access = new Developer();

            newPS_Access.PS_Access = true;

            bool expected = true;
            bool actual = newPS_Access.PS_Access;

            Assert.AreEqual(expected, actual);
        }
    }
}
