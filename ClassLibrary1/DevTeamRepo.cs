using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMA_Classes
{
    public class DevTeamRepo
    {
        protected readonly List<DevTeam> _developerTeams = new List<DevTeam>();

        //Create
        public bool AddTeamToDirectory(DevTeam newDevTeam)
        {
            int startingcount = _developerTeams.Count;

            _developerTeams.Add(newDevTeam);
            bool wasAdded = (_developerTeams.Count > startingcount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<DevTeam> GetDevTeams()
        {
            return _developerTeams;
        }

        //Gets Dev Teams by Team IDs
        public DevTeam GetDevTeamsByTeamID(int DevTeamID)
        {
            foreach (DevTeam team in _developerTeams)
            {
                if (team.TeamID == DevTeamID)
                {
                    return team;
                }
            }
            return null;
        }

        //Updates a CurrentTeam
        public bool UpdateCurrentDevTeam(int originalID, DevTeam newTeam)
        {
            DevTeam oldTeam = GetDevTeamsByTeamID(originalID);

            if (oldTeam != null)
            {
                oldTeam.DeveloperOnTeam= oldTeam.DeveloperOnTeam;
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamID = oldTeam.TeamID;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Removes a Current Team
        public bool DeleteCurrentTeam(DevTeam existingTeam)
        {
            bool deleteResult = _developerTeams.Remove(existingTeam);
            return deleteResult;
        }

        //Removes a Dev from Team
        public bool DeleteDevFromTeam(int teamID, int devID, DevTeam devTeam)
        {
            foreach (DevTeam dev in _developerTeams)
            {
                if (dev.TeamID == teamID && devTeam.DeveloperOnTeam.DeveloperID == devID)
                {
                    bool deleteResult = _developerTeams.Remove(devTeam);
                    return deleteResult;
                }
            }
            return false;    
        }
    }
}
