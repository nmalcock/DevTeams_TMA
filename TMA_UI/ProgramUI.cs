using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMA_Classes;

namespace TMA_UI
{
    class ProgramUI
    {
        protected readonly DeveloperRepo _developerRepo = new DeveloperRepo();
        protected readonly DevTeamRepo _developerTeams = new DevTeamRepo();
        
        public void Run()
        {
            SeedDeveloperList();

            DisplayMenu();
        }

        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine(
                    "Enter the number of the option you would like to select: \n" +
                    "1. Show all Developers \n" +
                    "2. Find Developer by ID \n" +
                    "3. Add new Developer \n" +
                    "4. Remove Developer \n" +
                    "5. Update Developer \n" +
                    "6. Create Developer Team \n" +
                    "7. Show Current Developer Teams \n" +
                    "8. Add Developer to Team \n" +
                    "9. Remove Developer from Team \n" +
                    "10. Update a Developer Team Name \n" +
                    "11. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllDeveloper();
                        break;
                    case "2":
                        GetDeveloperByID();
                        break;
                    case "3":
                        CreateNewDeveloper();
                        break;
                    case "4":
                        DeleteDeveloper();
                        break;
                    case "5":
                        UpdateDeveloper();
                        break;
                    case "6":
                        CreateDevTeam();
                        break;
                    case "7":
                        ShowDevTeams();
                        break;
                    case "8":
                        AddDevToTeam();
                        break;
                    case "9":
                        DeleteDevFromTeam();
                        break;
                    case "10":
                        UpdateTeamName();
                        break;
                    case "11":
                        //Exit
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-10!");
                        break;

                }
            }
        }

        //Show All Developers
        private void ShowAllDeveloper()
        {
            Console.Clear();

            List<Developer> listOfDeveloper = _developerRepo.GetDeveloper();

            foreach (Developer developer in listOfDeveloper)
            {
                DisplayContent(developer);
            }
            displayHelper();
        }

        //Find Developer By ID
        private void GetDeveloperByID()
        {
            Console.WriteLine("What Developer ID are you looking for?");

            string devID = Console.ReadLine();
            int devIDinput = Convert.ToInt32(devID);

            Developer developer = _developerRepo.GetDeveloperByID(devIDinput);

            if (developer != null)
            {
                DisplayContent(developer);
            }
            else
            {
                Console.WriteLine("This is not the Developer you were looking for!");
            }
            displayHelper();
        }

        // Add New Developer
        private void CreateNewDeveloper()
        {
            Console.Clear();

            Console.Write("Please enter a Developer ID: ");
            int devID = int.Parse(Console.ReadLine());

            Console.Write("Please enter a First Name: ");
            string fName = Console.ReadLine();

            Console.Write("Please enter a Last Name: ");
            string lName = Console.ReadLine();

            Console.Write("Please enter if they have access to PluralSight: (Yes or No) ");
            string access_PS = Console.ReadLine();

            string ps_checker = access_PS.ToLower();

            bool boolPSAccess;

            switch (ps_checker)
            {
                case "yes":
                    boolPSAccess = true;
                    break;
                case "no":
                    boolPSAccess = false;
                    break;
                default:
                    boolPSAccess = false;
                    break;
            }

            Developer developer = new Developer(devID, fName, lName, boolPSAccess);

            _developerRepo.AddDeveloperToDirectory(developer);

            Console.WriteLine("Please check to see if the developer was added! If they weren't try using a Unique ID number!");
            displayHelper();
        }

        private void DeleteDeveloper()
        {
            Console.Clear();

            Console.WriteLine("What Developer would you like to remove");
            int count = 0;
            //DisplayAllContent
            List<Developer> developerList = _developerRepo.GetDeveloper();
            foreach (Developer developer in developerList)
            {
                count++;
                Console.WriteLine($"{count}. {developer.FirstName} {developer.LastName} ");
            }
            Console.WriteLine("Select DeveloperID that you want to Delete.");
            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            if (targetIndex >= 0 && targetIndex <= developerList.Count())
            {

                Developer targetContent = developerList[targetIndex];

                if (_developerRepo.DeleteCurrentDeveloper(targetContent))
                {
                    Console.WriteLine($" {targetContent.DeveloperID} removed from repo");
                }
                else
                {
                    Console.WriteLine("Sorry something went wrong");
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
            displayHelper();
        }

        //Need to Update Developer
        private void UpdateDeveloper()
        {
            Console.Clear();

            Console.WriteLine("What developer would you like to Update?");
            int userInput = int.Parse(Console.ReadLine());

            //New Content
            Developer updatedDeveloper = new Developer();

            Console.Write("What is the new First Name: ");
            updatedDeveloper.FirstName = Console.ReadLine();

            Console.Write("What is the new Last Name: ");
            updatedDeveloper.LastName = Console.ReadLine();

            Console.Write("Please enter if they have access to PluralSight: (Yes or No) ");
            string access_PS = Console.ReadLine();

            string ps_checker = access_PS.ToLower();

            bool boolPSAccess;

            switch (ps_checker)
            {
                case "yes":
                    boolPSAccess = true;
                    break;
                case "no":
                    boolPSAccess = false;
                    break;
                default:
                    boolPSAccess = false;
                    break;
            }
            updatedDeveloper.PS_Access = boolPSAccess;

            _developerRepo.UpdateCurrentDeveloper(userInput, updatedDeveloper);

        }

        //Creates Developer Team
        private void CreateDevTeam()
        {
            Console.Clear();

            Console.Write("Please enter a Team Name: ");
            string tName = Console.ReadLine();

            Console.Write("Please enter a Team ID: ");
            int devID = int.Parse(Console.ReadLine());

            DevTeam newTeam = new DevTeam(tName, devID);

            _developerTeams.AddTeamToDirectory(newTeam);
        }

        //Shows all Developers in a Team
        private void ShowDevTeams()
        {
            Console.Clear();


            List<DevTeam> teams = _developerTeams.GetDevTeams();

            foreach (DevTeam team in teams)
            {
                DisplayTeam(team);
            }

            displayHelper();
        }

        //Adds Developer to a Team
        private void AddDevToTeam()
        {
            Console.Clear();
            Console.WriteLine("Please Select a TeamID that you would like to Add to");
            ShowDevTeams();
            Console.WriteLine("Please type in any Team ID integer from previous list!");
            string newteamID = Console.ReadLine();
            int teamID = Convert.ToInt32(newteamID);
            Console.WriteLine("Please select a Developer ID that you would like to Add");
            ShowAllDeveloper();
            Console.WriteLine("Please type in an ID Integer from previous List!");
            string newDevID = Console.ReadLine();
            int devID = Convert.ToInt32(newDevID);

            List<DevTeam> teams = _developerTeams.GetDevTeams();

            DevTeam IsEmpty = _developerTeams.GetDevTeamsByTeamID(teamID);

            if (IsEmpty.DeveloperOnTeam == null)
            {
                Developer newDeveloper = _developerRepo.GetDeveloperByID(devID);
                IsEmpty.DeveloperOnTeam = newDeveloper;
            }
            else
            {
                Developer newDeveloper = _developerRepo.GetDeveloperByID(devID);
                DevTeam newTeam = new DevTeam(newDeveloper, IsEmpty.TeamName, IsEmpty.TeamID);
                _developerTeams.AddTeamToDirectory(newTeam);
            }

        }

        private void DeleteDevFromTeam()
        {
            Console.Clear();
            Console.WriteLine("Please Select a TeamID that you would like to delete from.");
            ShowDevTeams();
            Console.WriteLine("Please type in any Team ID integer from previous list.");
            string newteamID = Console.ReadLine();
            int teamID = Convert.ToInt32(newteamID);
            Console.WriteLine("Please select a Developer ID that you would like to delete");
            Console.WriteLine("Please type in a Developer ID Integer from previous List!");
            string delDevID = Console.ReadLine();
            int devID = Convert.ToInt32(delDevID);

            List<DevTeam> teams = _developerTeams.GetDevTeams();
            DevTeam teamToDelete = _developerTeams.GetDevTeamsByTeamID(teamID);

            _developerTeams.DeleteDevFromTeam(teamID, devID, teamToDelete);

        }

        // Updates Team Name
        private void UpdateTeamName()
        {
            Console.Clear();

            DevTeam updatedTeam = new DevTeam();

            Console.WriteLine("Please Select a TeamID that you would like to Add to");
            ShowDevTeams();

            Console.WriteLine("Please type in an ID Integer from previous List!");
            string newteamID = Console.ReadLine();
            int teamID = Convert.ToInt32(newteamID);

            Console.WriteLine("Type in your new Team Name");
            updatedTeam.TeamName = Console.ReadLine();

            _developerTeams.UpdateCurrentDevTeam(teamID, updatedTeam);


        }

        //Helper Methods

        //Displays Developer Object 
        private void DisplayContent(Developer developer)
        {
            Console.WriteLine(
                "Developer ID: " + developer.DeveloperID + "\n" +
                "Full Name: " + developer.FirstName + " " + developer.LastName + "\n" +
                "Pluralsight Access: " + developer.PS_Access + "\n");
        }

        //Displays Developer Object 
        private void DisplayTeam(DevTeam team)
        {
            if (team.DeveloperOnTeam == null)
            {
                Console.WriteLine(
                    "Developer: " + team.DeveloperOnTeam + "\n" +
                    "Team Name: " + team.TeamName + "\n" +
                    "Team ID: " + team.TeamID + "\n");
            }
            else
            {
                Console.WriteLine(
                    "Developer ID: " + team.DeveloperOnTeam.DeveloperID + "\n" +
                    "Developer Name: " + team.DeveloperOnTeam.FirstName + " " +team.DeveloperOnTeam.LastName + "\n" +
                    "Access To PluralSight: " + team.DeveloperOnTeam.PS_Access + "\n" +
                    "Team Name: " + team.TeamName + "\n" +
                    "Team ID: " + team.TeamID + "\n");
            }
        }

        // Helps display Readkey
        private void displayHelper()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //

        //Seed Developer List
        private void SeedDeveloperList()
        {
            Developer jerry = new Developer(1, "Jerry", "Jeudy", true);
            Developer josh = new Developer(2, "Josh", "Peck", true);
            Developer nick = new Developer(3, "Nick", "Alcock", false);

            DevTeam gold = new DevTeam("Gold", 1);
            DevTeam blue = new DevTeam("Blue", 2);

            _developerRepo.AddDeveloperToDirectory(jerry);
            _developerRepo.AddDeveloperToDirectory(josh);
            _developerRepo.AddDeveloperToDirectory(nick);

            _developerTeams.AddTeamToDirectory(gold);
            _developerTeams.AddTeamToDirectory(blue);
        }
    }
}
