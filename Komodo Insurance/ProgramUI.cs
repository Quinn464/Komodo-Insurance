using Komodo_Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    internal class ProgramUI
    {
        private readonly KomodoRepositorys _devRepository = new KomodoRepositorys();
        private TeamsRepositorys _teamRepository = new TeamsRepositorys();

        // Method that runs/starts the application
        public void Run()
        {
            SeedDevList();
            Menu();
        }
        //Menu


        //was private both throw up errors
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display
                Console.WriteLine("Select a option\n" +
                    "1. Add new dev\n" +
                    "2.View All Devs\n" +
                    "3. Update dev\n" +
                    "4. Delete dev\n" +
                    "5. Add new Team \n" +
                    "6.View all teams\n" +
                    "7.View teams by name\n" +
                    "8. Delete Team\n");
                //Get the user's input and act acordingly 
                string input = Console.ReadLine();

                switch (input)
                {
                    //add
                    case "1":
                        CreateNewDev();

                        break;
                    //view all
                    case "2":
                        DisplayAllDevs();
                        break;
                    //Update dev
                    case "3":
                        UpdateExistingDev();
                        break;
                    //Delete dev
                    case "4":
                        DeleteDev();
                        break;

                    case "5":
                        AddNewTeam();
                        break;
                    case "6":
                        ViewAllTeams();
                        break;
                    case "7":
                        GetTeamByName();
                        break;
                    case "8":
                        DeleteTeam();
                        break;
                    default:
                        Console.WriteLine("Input not valid");
                        break;


                }
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
                Console.Clear();

            }
        }
        //Dev Users
        //create
        private void CreateNewDev()
        {
            //name
            Devs newDev = new Devs();
            Console.WriteLine("Enter the name for the Dev:");
            newDev.Name = Console.ReadLine();



            //Id
            Console.WriteLine(newDev.Dev_ID);
            Console.WriteLine("Enter Dev's ID");
            newDev.Dev_ID = Console.ReadLine();


            //Has access
            Console.WriteLine("Has access to Plural Y/N?");
            string hasAccessToPlural = Console.ReadLine().ToLower();

            if (hasAccessToPlural == "y")
            {
                newDev.HasAccessToPlural = true;
            }
            else
            {
                newDev.HasAccessToPlural = false;
            }

            //what developer they are
            Console.WriteLine("Select type" +
                "1. Web,\n" +
                "2. Software\n");

            int devID = int.Parse(Console.ReadLine());
            DevType devType = (DevType)devID;
            newDev.TypeOfDev = devType;

            //linking to create method
            _devRepository.AddDevToList(newDev);

        }
        //Display all devs
        private void DisplayAllDevs()
        {
            List<Devs> listOfDevs = _devRepository.GetListOfDevs();
            foreach (Devs devs in listOfDevs)
            {
                Console.WriteLine($"Name: {devs.Name}, ID: {devs.Dev_ID } HasAccess: {devs.HasAccessToPlural}");

            }
        }
        //update existing dev
        private void UpdateExistingDev()
        {
            //Display all devs
            DisplayAllDevs();

            //ask to update the ID of dev 
            Console.WriteLine("enter the ID of the dev you would like to update");
            //get dev name 
            string oldID = Console.ReadLine();
            Devs newDev = _devRepository.GetDevByID(oldID);
            if (newDev != null)
            {
                Console.WriteLine("Enter the name for the Dev:");
                newDev.Name = Console.ReadLine();

                //Id
                Console.WriteLine(newDev.Dev_ID);
                Console.WriteLine("Enter Dev's ID");
                newDev.Dev_ID = Console.ReadLine();

                //Has access
                Console.WriteLine("Has access to Plural Y/N?");
                string hasAccessToPlural = Console.ReadLine().ToLower();

                if (hasAccessToPlural == "y")
                {
                    newDev.HasAccessToPlural = true;
                }
                else
                {
                    newDev.HasAccessToPlural = false;
                }

                //what developer they are
                Console.WriteLine("Select type" +
                    "1. Web,\n" +
                    "2. Software\n");

                int devID = int.Parse(Console.ReadLine());
                DevType devType = (DevType)devID;
                newDev.TypeOfDev = devType;
                _devRepository.UpdateExistingDev(oldID, newDev);
            }
            else
                Console.WriteLine("This user doesn't exist");
        }
        //delete existing dev
        private void DeleteDev()
        {

            DisplayAllDevs();

            //get dev name
            Console.WriteLine("\n" +
                "Enter ID of Dev");
            string input = Console.ReadLine();

            //call delete
            bool wasDeleted = _devRepository.RemoveDevFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("Seccesfully removed");
            }


            //if dev was removed give feedback

            //if not display feedback acordingly
            else
            {
                Console.WriteLine("Dev could not be removed");
            }
        }

        //Dev Teams
        private void AddNewTeam()
        {
            List<Devs> devList = new List<Devs>();
            //name
            Teams newTeam = new Teams();
            Console.WriteLine("Enter the name for the Team:");
            newTeam.TeamName = Console.ReadLine();

            List<Devs> devs = _devRepository.GetListOfDevs();
            foreach(Devs dev in devs)
            {
                Console.WriteLine($"{dev.Name}{dev.Dev_ID}{dev.TypeOfDev}{dev.HasAccessToPlural}");
            }

            //Disc.
            Console.WriteLine(newTeam.TeamMembers);
            Console.WriteLine("Enter Dev's id number)");
            string id = Console.ReadLine();
            Devs devId = _devRepository.GetDevByID(id);
            if (devId != null)
            {
                Console.WriteLine($"{devId.Name} {devId.Dev_ID} {devId.TypeOfDev} {devId.HasAccessToPlural}");
                Console.WriteLine("would you like to add this user to this team? y or n");
                string userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    devList.Add(devId);
                }
                else Console.WriteLine("This user has not been added.");

                Console.WriteLine("Would you like to add another user? y or n");
                string userInput1 = Console.ReadLine();
                while (userInput1 == "y")
                {
                    Console.WriteLine("Enter Dev's id number)");
                    id = Console.ReadLine();
                    devId = _devRepository.GetDevByID(id);
                    if (devId != null)
                    {
                        Console.WriteLine($"{devId.Name} {devId.Dev_ID} {devId.TypeOfDev} {devId.HasAccessToPlural}");
                        Console.WriteLine("would you like to add this user to this team? y or n");
                        string userInput2 = Console.ReadLine();
                        if (userInput2 == "y")
                        {
                            devList.Add(devId);
                        }
                        else Console.WriteLine("This user has not been added.");
                    }

                    Console.WriteLine("Would you like to add another user? y or n");
                    userInput1 = Console.ReadLine();
                }
                newTeam.TeamMembers = devList;

                //what developer they are
                Console.WriteLine("Select what type of team" +
                    "1. Web,\n" +
                    "2. Software\n");

                int teamId = int.Parse(Console.ReadLine());
                DeveloperType devType = (DeveloperType)teamId;
                newTeam.TypeOfDev = devType;
                _teamRepository.AddTeamToList(newTeam);

            }
        }
        private void ViewAllTeams()
        {
            List<string > teamNames = new List<string>();
            List<Teams> listOfTeams = _teamRepository.GetTeamList();
            foreach (Teams teams in listOfTeams)
            {
               foreach(var person in teams.TeamMembers)
                {
                    string names = person.Name;
                    teamNames.Add(names);
                }
               string teamMates = String.Join(", ", teamNames);

                Console.WriteLine($"Name: {teams.TeamName}, ID: {teamMates} HasAccess: {teams.TypeOfDev }");

            }
        }
        private void GetTeamByName()
        {
            string name = Console.ReadLine();
            var team = _teamRepository.GetTeamsByName(name);
            var names = _teamRepository.JoinListTogether(name);
     
            Console.WriteLine($"Name: {team.TeamName}, ID: {names} HasAccess: {team.TypeOfDev }");

        }
        private void DeleteTeam()
        {
            ViewAllTeams();
            Console.WriteLine("Enter name of team ");
            string input = Console.ReadLine();

            bool wasDeleted = _teamRepository.RemoveTeamFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("Seccesfully removed");
            }
        }
        private void SeedDevList()
        {
            Devs Quinn = new Devs("Quinn Sempsrott", "onetwothree", true, DevType.Software);
            Devs Sebastian = new Devs("Sebastian Sempsrott", "onefourthree", true, DevType.Software);
            Devs Finn = new Devs("Finn Sempsrott", "onetwofour", false, DevType.Web);
            _devRepository.AddDevToList(Quinn);
            _devRepository.AddDevToList(Sebastian);
            _devRepository.AddDevToList(Finn);

            Teams TeamOne = new Teams("TeamOne", new List<Devs> { Quinn, Sebastian, Finn }, DeveloperType.Software);
            _teamRepository.AddTeamToList(TeamOne);
        }

    }
}
