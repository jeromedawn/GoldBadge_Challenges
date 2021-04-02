using _01_KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Console
{
    public class ProgramUI
    {
        private readonly MenuRepository _menuRepo = new MenuRepository();

        //Method that runs/starts the application
        public void Run()
        {
            SeedMethod();
            ProgramMenu();
        }

        //Menu Method 

        private void ProgramMenu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                //Display our options to the user 
                Console.WriteLine("Select an option: \n" +
                    " \n" +
                    "1) Create a menu item\n" +
                    "2) View all menu items \n" +
                    "3) View all menu item details \n" +
                    "4) Delete menu items  \n" +
                    "5) Exit ");
                //Get the user's input 
                string userInput = Console.ReadLine();
                // Evaluate the user's input and act accordingly 
                switch (userInput)
                {
                    case "1":
                        //Create New Menu Item 
                        CreateMenuItem();
                        break;
                    case "2":
                        //View All Menu Item Details 
                        ReadMenuItem();
                        break;
                    case "3":
                        //Update Menu Item 
                        ReadMenuItemByName();
                        break;
                    case "4":
                        //Delete Menu Item 
                        DeleteMenuItem();
                        break;
                    case "5":
                        //Exit 
                        Console.WriteLine("Done");
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateMenuItem()
        {
            Menu newItem = new Menu();
            //Enter Menu Item Name 
            Console.WriteLine("Enter the name of this menu item");
            newItem.ItemName = Console.ReadLine();
            //Enter Menu Item Order Number
            Console.WriteLine("Enter order number for this menu item");
            string itemNumberAsString = Console.ReadLine();
            newItem.ItemNumber = double.Parse(itemNumberAsString);
            //Enter Menu Item Name 
            Console.WriteLine("How would you describe this menu item?");
            newItem.ItemDescription = Console.ReadLine();
            //Enter Menu Item Price
            Console.WriteLine("How much will this item menu cost?");
            string priceAsString = Console.ReadLine();
            newItem.ItemPrice = double.Parse(priceAsString);
            //Ingredients
            Console.WriteLine("What ingredients are required to produce this item?");
            //string ingredientsAsString = Console.ReadLine();
            //int ingredientsAsInt = int.Parse(ingredientsAsString);
            //newItem.Ingredients = (Ingredients)ingredientsAsInt;
            newItem.Ingredients = Console.ReadLine();
            _menuRepo.CreateMenuItem(newItem);
        }
        private void ReadMenuItem()
        {
            Console.Clear();
            List<Menu> listOfItems = _menuRepo.ReadMenuItem();

            foreach (Menu item in listOfItems)
            {
                Console.WriteLine($"{ item.ItemNumber}. {item.ItemName}");
                  //  $"Menu Item Number: {item.ItemNumber} \n" +
                  //  $"Menu Item Description: {item.ItemDescription} \n" +
                  //  $"Menu Item Price: {item.ItemPrice} \n" +
                  //  $"Menu Item Ingredients: {item.Ingredients}");
            }
        }

        private void ReadMenuItemByName()
        {
            Console.Clear();
            //Ask User For Menu Item Name 
            Console.WriteLine("Enter the name of the item name:");
            //Get Input
            string input = Console.ReadLine().ToLower();
            //Find Menu details for Menu Item Name
            Menu item = _menuRepo.ReadMenuItemByName(input);
            //Show Menu details as long as its not null 
            if (item != null)
            {
                Console.WriteLine
                    //($"Menu Item Name: {item.ItemName} \n" +
                    ($"Menu Item Number: {item.ItemNumber} \n" +
                    $"Menu Item Description: {item.ItemDescription} \n" +
                    $"Menu Item Price: {item.ItemPrice} \n" +
                    $"Menu Item Ingredients: {item.Ingredients}");
            }
            else
                Console.WriteLine($"No Menu Item By The Name Of { input } ");
        }
        private void DeleteMenuItem()
        {
            ReadMenuItem();
            // Get The user input of menu you want to delete 
            Console.WriteLine("What menu item would you like to delete?");
            //read the input 
            string input = Console.ReadLine().ToLower();
            //call the delete method from repository 
            bool menuItemDeleted = _menuRepo.DeleteMenuItem(input);
            //
            if (menuItemDeleted)
            {
                Console.WriteLine("Menu Item Deleted");
            }
            else
                Console.WriteLine("Menu Item Could Not Be Deleted");
        }
        private void SeedMethod()
        {
            Menu bananaPower = new Menu("Banana Power", 1, "Creamy Delcious Banana Smoothie Packed With Protein And Micronutrients. Great For After A Workout", 7.99, "Banana Milk Protein Powder Greek Yogurt Spinach");
            Menu berryBlast = new Menu("Berry Blast", 2, "Creamy Delcious Banana Smoothie Packed With Protein And Micronutrients. Great For After A Workout", 6.99, "Banana Milk Protein Powder Greek Yogurt Spinach");
            Menu tropicalIsland = new Menu("Tropical Island", 3, "A Customer Favorite! I've heard some say 'Its like an island vacation in a cup!' Very Refreshing!", 6.99, "Banana Mango Peaches Coconut Juice Vanilla Yogurt");

            _menuRepo.CreateMenuItem(bananaPower);
            _menuRepo.CreateMenuItem(berryBlast);
            _menuRepo.CreateMenuItem(tropicalIsland);
        }
    }
}
