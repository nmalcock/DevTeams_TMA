using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMA_Classes
{
    public class DevTeam
    {
        //public int TeamMemberID { get; set; }
        public Developer DeveloperOnTeam {get; set;}
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        
        //Empty Constructor
        public DevTeam() { }

        public DevTeam(string teamName, int teamID)
        {
            TeamName = teamName;
            TeamID = teamID;
        }

        public DevTeam(Developer devOnTeam, string teamName, int teamID)
        {
            DeveloperOnTeam = devOnTeam;
            TeamName = teamName;
            TeamID = teamID;
        }
    }
}
