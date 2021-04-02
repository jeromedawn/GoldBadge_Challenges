using _02_KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims_Console
{
    class ProgramUI
    {
        //ref claims repository here 
        private readonly ClaimsRepository _claimsRepository = new ClaimsRepository();
        public void Run()
        {
            SeedClaims();
            ProgramMenu();
        }
        private void ProgramMenu()
        {
            bool whileRunning = true;
            while (whileRunning)
            {
                //Display The Menu 

                Console.WriteLine("Choose a menu item: \n" +
                                                     " \n" +
                                    "1.See all claims \n" +
                                    "2.Take care of next claim \n" +
                                    "3.Enter a new claim \n");

                //Get The User's Input 
                string input = Console.ReadLine();
                //Act Based on User's Input 
                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
                //Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claims> claims = _claimsRepository.SeeAllClaims();
            foreach (var claim in claims)
            {
                Console.WriteLine($"ClaimID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Claim Description: {claim.Description}\n" +
                    $"Claim Amount: ${claim.ClaimAmount}\n" +
                    $"Date Of Incident: {claim.DateOfIncident.ToShortDateString()}\n" +
                    $"Date Of Claim: {claim.DateOfClaim.ToShortDateString()}\n" +
                    $"Is Valid: {claim.IsValid}\n");
            }
            Console.WriteLine("Press Enter Twice To Go Back To Main Menu");
            Console.ReadKey();
        }
        private void TakeCareOfNextClaim()
        {
            Console.WriteLine();
            Console.WriteLine("Here are the details for the next claim to be processed:");
            Claims claim =_claimsRepository.ViewNextClaim();
            if (claim != null)
            {
                Console.WriteLine($"ClaimID: {claim.ClaimID}\n" +
                 $"Claim Type: {claim.ClaimType}\n" +
                 $"Claim Description: {claim.Description}\n" +
                 $"Claim Amount: ${claim.ClaimAmount}\n" +
                 $"Date Of Incident: {claim.DateOfIncident}\n" +
                 $"Date Of Claim: {claim.DateOfClaim}\n" +
                 $"Is Valid: {claim.IsValid}\n");
            }
            else
            {
                Console.WriteLine("No Claims To Be Processed");
                Console.ReadKey();
                Console.Clear();
                ProgramMenu();
            }
            Console.WriteLine("Do you want to process next claim? (Y/N)");
            Console.WriteLine();
            string input = Console.ReadLine().ToLower();
            if (input == "y" && _claimsRepository.SeeAllClaims().Count > 0)
            {
                _claimsRepository.ProcessClaim();
                Console.WriteLine();
                Console.WriteLine("Claim Proccessed.Press Enter To Go Back To Main Menu");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Claim Was Not Processed. Press Enter To Go Back To Main Menu");
                Console.ReadKey();
                Console.Clear();
                ProgramMenu();
            }

        }
        private void EnterANewClaim()
        {
            Claims claim = new Claims();
            //Enter Claim ID 
            Console.WriteLine();
            Console.WriteLine("Enter the claimID:");
            string string_claimID = Console.ReadLine();
            claim.ClaimID = double.Parse(string_claimID);
            //Enter Claim Type 
            Console.WriteLine("What type of claim is this?\n" +
                "Press 1 for Car\n" +
                "Press 2 for Home\n" + "Press 3 for Theft");
            string typeOfClaim = Console.ReadLine();
            Console.WriteLine();
            switch (typeOfClaim)
            {
                case "1":
                    claim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Not A Valid Claim Type Please Start Over");
                    EnterANewClaim();
                    break;
            }
            //Enter the Description
            Console.WriteLine("Please describe the incident:");
            claim.Description = Console.ReadLine();
            //Enter Claim Amount 
            Console.WriteLine("What is the claim amount?");
            string claimAmount = Console.ReadLine();
            claim.ClaimAmount = double.Parse(claimAmount);
            //Enter Date of Incident 
            Console.WriteLine("What date did this indcident occur? ");
            string dateOfIncident = Console.ReadLine();
            claim.DateOfIncident = DateTime.Parse(dateOfIncident);
            //Enter Date of Claim 
            Console.WriteLine("What date are you filing this claim?");
            string dateOfClaim = Console.ReadLine();
            claim.DateOfClaim = DateTime.Parse(dateOfClaim);
            if (claim.IsValid)
            {
                Console.WriteLine("This claim is valid");
            }
            else
            {
            Console.WriteLine("This claim is not valid");                   
            }
            _claimsRepository.EnterNewClaim(claim);
        }
        private void SeedClaims()
        {
            Claims claim = new Claims(12345, ClaimType.Car, "Car reck", 2000.25, new DateTime(2021, 1, 1), new DateTime(2021, 1, 5));
            Claims claimA = new Claims(43215, ClaimType.Car, "Car reck", 2000.25, new DateTime(2021, 1, 1), new DateTime(2021, 1, 5));
            Claims claimB = new Claims(22114, ClaimType.Home, "Home INvasion", 2000.25, new DateTime(2021, 1, 1), new DateTime(2021, 1, 5));
            Claims claimC = new Claims(89542, ClaimType.Theft, "Theft...", 2000.25, new DateTime(2021, 1, 1), new DateTime(2021, 1, 5));
            Claims claimD = new Claims(32654, ClaimType.Car, "Broken window", 2000.25, new DateTime(2021, 1, 1), new DateTime(2021, 1, 5));

            _claimsRepository.EnterNewClaim(claim);
            _claimsRepository.EnterNewClaim(claimA);
            _claimsRepository.EnterNewClaim(claimB);
            _claimsRepository.EnterNewClaim(claimC);
            _claimsRepository.EnterNewClaim(claimD);
        }
    }
}
