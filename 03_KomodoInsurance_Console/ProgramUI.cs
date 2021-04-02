using _03_KomodoInsuranceBadges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoInsuranceBadges_Console
{
    class ProgramUI
    {
        private readonly BadgesRepository _badgeRepo = new BadgesRepository();
        public void Run()
        {
            SeedMethod();
            ProgramMenu();
        }

        private void ProgramMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display Menu 
                Console.WriteLine
                    ("Menu \n" +
                    " \n" +
                    "Hello Security Admin, What would you like to do? \n" +
                    "\n" +
                    "Select an option: \n" +

                    "\n" +
                    "1) Add A Badge \n" +
                    "2) Edit A Badge \n" +
                    "3) List All Badges \n" +
                    "4) Exit \n");
                //Get The User's Input 
                string userInput = Console.ReadLine();
                //Evaluate The User's Input And Act Accordingly 
                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine();
                        //Console.WriteLine("Press enter to exit.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid selection.");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddABadge()
        {
            Console.WriteLine();
            Dictionary<int, Badges> listOfBadges = _badgeRepo.GetDictionaryAllBadges();
            Badges newBadge = new Badges();
            bool hasFilledRooms = false;

            while (hasFilledRooms == false)
            {
                Console.WriteLine($"Badge ID: {listOfBadges.Count + 1}");
                Console.WriteLine();
                Console.WriteLine("Do you want to add door access to this badge? Enter: (Y/N) ");
                string userInputHasFilledRooms = Console.ReadLine().ToLower();
                if (userInputHasFilledRooms == "y")
                {
                    Console.WriteLine("List the door this badge needs access to:");
                    string accessToDoors = Console.ReadLine();
                    newBadge.DoorNames.Add(accessToDoors);
                }
                else if (userInputHasFilledRooms == "n")
                {
                    hasFilledRooms = true;
                    _badgeRepo.AddABadge(newBadge);
                }
                else
                {
                    hasFilledRooms = true;
                    Console.WriteLine("Press any key to return to main menu");
                    Console.ReadKey();
                    ProgramMenu();
                }
            }
        }

        private void EditABadge()
        {
            ListAllBadges();
            bool running = true;
            while (running)
            {
                Console.WriteLine("What is the badge number you want to update?");
                int userInput = int.Parse(Console.ReadLine());

                Badges badges = _badgeRepo.GetDictionaryBadgesById(userInput);
                Console.WriteLine();
                if (badges != null)
                {
                    Console.Write($"BadgeID: {badges.BadgeID} Has Access To Doors : ");
                    foreach (var item in badges.DoorNames)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();

                    Console.WriteLine("What would you like to do? \n" +
                        "\n" +
                        "1) Remove A Door\n" +
                        "2) Add A Door \n" +
                        "\n");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case
                            "1":
                            RemoveDoor(badges, userInput);
                            running = false;
                            break;
                        case "2":
                            AddDoor(badges, userInput);
                            running = false;
                            break;
                        default:
                            Console.WriteLine($"{choice} is not a valid option. Please enter a valid option.");
                            break;
                    }
                }
                //Console.WriteLine("Enter a valid BadgeID");
            }
        }

        private void RemoveDoor(Badges badges, int userInput)
        {
            Console.WriteLine("What door would you like to remove?");
            string removeDoor = Console.ReadLine();
            Console.WriteLine($"Removing {removeDoor} from Badge {userInput} ");
            _badgeRepo.RemoveDoor(removeDoor, userInput);
            Console.Write($"BadgeID: {badges.BadgeID} Has Access To Doors : ");
            foreach (var item in badges.DoorNames)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        private void AddDoor(Badges badges, int userInput)
        {
            Console.WriteLine("What door would you like to add?");
            string addDoor = Console.ReadLine();
            Console.WriteLine($"Adding {addDoor} to Badge {userInput} ");
            _badgeRepo.AddDoor(addDoor, userInput);
            Console.Write($"BadgeID: {badges.BadgeID} Has Access To Doors : ");
            foreach (var item in badges.DoorNames)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badges> listOfBadges = _badgeRepo.GetDictionaryAllBadges();
            Console.WriteLine($"BadgeID #  \tDoor Access");
            Console.WriteLine();
            //Console.Write("Door Access:\n");
            foreach (var item in listOfBadges)
            {
                Console.Write($"{item.Key}\t\t");
                foreach (var Door in item.Value.DoorNames)
                {
                    Console.Write($"{Door} ");
                }
                Console.WriteLine();
            }
        }

        private void SeedMethod()
        {
            Badges badges = new Badges(new List<string> { "A1", "A3", "A6" });
            Badges badges1 = new Badges(new List<string> { "A4", "A3", "B6" });
            Badges badges2 = new Badges(new List<string> { "A1", "B3", "A6" });

            _badgeRepo.AddABadge(badges);
            _badgeRepo.AddABadge(badges1);
            _badgeRepo.AddABadge(badges2);
        }





    }

}
