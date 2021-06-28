using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMA_Classes
{
    public class Developer
    {
        // Properties
        public int DeveloperID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool PS_Access { get; set; }

        // Empty Constructor
        public Developer() { }

        // Full Constructor
        public Developer(int developerID, string firstName, string lastName, bool ps_Access)
        {
            DeveloperID = developerID;
            FirstName = firstName;
            LastName = lastName;
            PS_Access = ps_Access;
        }
    }
}
