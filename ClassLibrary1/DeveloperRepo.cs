using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMA_Classes
{
    public class DeveloperRepo
    {
        // Psuedo-Database of Developers at Komodo Insurance
        protected readonly List<Developer> _devDirectory = new List<Developer>();

        // AddDeveloperToDirectory()
        // Creating Developer in _devDirectory
        //NEED TO MAKE SURE IT IS UNIQUEID
        public bool AddDeveloperToDirectory(Developer newDeveloper)
        {
            int startingCount = _devDirectory.Count();
            bool uniqueID = IsDeveloperIDUnique(newDeveloper);

            if (uniqueID == true)
            {
                _devDirectory.Add(newDeveloper);
            }
            bool wasAdded = (_devDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Returns the whole _devDirectory
        public List<Developer> GetDeveloper()
        {
            return _devDirectory;
        }

        //Returns a specific Developer by their DeveloperID
        public Developer GetDeveloperByID(int ID)
        {
            foreach (Developer developer in _devDirectory)
            {
                if (developer.DeveloperID == ID)
                {
                    return developer;
                }
            }
            return null;
        }

        public bool IsDeveloperIDUnique(Developer newDeveloper)
        {
            int checkID = newDeveloper.DeveloperID;

            foreach (Developer developer in _devDirectory)
            {
                if (developer.DeveloperID == checkID)
                {
                    return false;
                }
            }
            return true;
        }

        //Updates a Current Developer.
        //LOOK INTO IF IT'S WORTH NOT UPDATING DEVELOPERID
        public bool UpdateCurrentDeveloper(int originalID, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperByID(originalID);

            if (oldDeveloper != null)
            {
                oldDeveloper.DeveloperID = oldDeveloper.DeveloperID;
                oldDeveloper.FirstName = newDeveloper.FirstName;
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.PS_Access = newDeveloper.PS_Access;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Removes a Current Developer
        public bool DeleteCurrentDeveloper(Developer existingDeveloper)
        {
            bool deleteResult = _devDirectory.Remove(existingDeveloper);
            return deleteResult;
        }



    }
}
