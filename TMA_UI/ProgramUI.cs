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
        
        public void Run()
        {
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
                    "5. Update Developer \n +" +
                    "6. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        //Exit
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-6!");
                        break;

                }
            }
        }
    }
}
