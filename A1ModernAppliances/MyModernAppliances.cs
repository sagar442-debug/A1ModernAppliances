using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Entities.ProblemDomain;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            Console.WriteLine("Enter the item number of an appliance: ");

            // Create long variable to hold item number
            int itemNumber;

            // Get user input as string and assign to variable.
            string input = Console.ReadLine();

            // Convert user input from string to long and store as item number variable.
            if (!int.TryParse(input, out itemNumber))   
            {
                Console.WriteLine("Invalid item number.");
                return;
            }

            // Create 'foundAppliance' variable to hold appliance with item number
            Appliance foundAppliance = Appliances.FirstOrDefault(appliance => appliance.ItemNumber == itemNumber);

            // Test appliance was not found (foundAppliance is null)
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.");
            }
            else
            {
                // Test found appliance is available
                if (foundAppliance.IsAvailable)
                {
                    foundAppliance.Checkout();
                    Console.WriteLine($"Appliance {itemNumber} has been checked out.");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.WriteLine("Enter brand to search for: ");

            // Get user input as string and assign to variable.
            string brandToSearch = Console.ReadLine();

            // Create list to hold found Appliance objects
            List<Appliance> foundAppliances = new List<Appliance>();

            // Iterate through loaded appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test current appliance brand matches what user entered
                if (appliance.Brand.Equals(brandToSearch, StringComparison.OrdinalIgnoreCase))
                {
                    // Add current appliance in list to found list
                    foundAppliances.Add(appliance);
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");
            Console.Write("Enter number of doors: ");

            // Get user input as string and assign to variable
            string input = Console.ReadLine();

            // Convert user input from string to int and store as number of doors variable
            if (!int.TryParse(input, out int numberOfDoors))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            // Create list to hold found Appliance objects
            List<Appliance> foundRefrigerators = new List<Appliance>();

            // Iterate/loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test that current appliance is a refrigerator
                if (appliance is Refrigerator refrigerator)
                {
                    // Test user entered 0 or refrigerator doors equals what user entered
                    if (numberOfDoors == 0 || refrigerator.Doors == numberOfDoors)
                    {
                        // Add current appliance in list to found list
                        foundRefrigerators.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(foundRefrigerators, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");
            Console.Write("Enter grade: ");

            // Get user input as string and assign to variable
            string gradeInput = Console.ReadLine();

            // Create grade variable to hold grade to find (Any, Residential, or Commercial)
            string grade;

            // Test input is "0"
            if (gradeInput == "0")
            {
                grade = "Any";
            }
            // Test input is "1"
            else if (gradeInput == "1")
            {
                grade = "Residential";
            }
            // Test input is "2"
            else if (gradeInput == "2")
            {
                grade = "Commercial";
            }
            // Otherwise (input is something else)
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");
            Console.Write("Enter voltage: ");

            // Get user input as string
            string voltageInput = Console.ReadLine();

            // Create variable to hold voltage
            int voltage;

            // Test input is "0"
            if (voltageInput == "0")
            {
                voltage = 0;
            }
            // Test input is "1"
            else if (voltageInput == "1")
            {
                voltage = 18;
            }
            // Test input is "2"
            else if (voltageInput == "2")
            {
                voltage = 24;
            }
            // Otherwise
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            // Create list to hold found Appliance objects
            List<Appliance> foundVacuums = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Check if current appliance is vacuum
                if (appliance is Vacuum vacuum)
                {
                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                    if (grade == "Any" || (vacuum.Grade == grade && (voltage == 0 || vacuum.BatteryVoltage == voltage)))
                    {
                        // Add current appliance in list to found list
                        foundVacuums.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(foundVacuums, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Work site");
            Console.Write("Enter room type: ");

            // Get user input as string and assign to variable
            string roomTypeInput = Console.ReadLine();

            // Create character variable that holds room type
            char roomType;

            // Test input is "0"
            if (roomTypeInput == "0")
            {
                roomType = 'A';
            }
            // Test input is "1"
            else if (roomTypeInput == "1")
            {
                roomType = 'K';
            }
            // Test input is "2"
            else if (roomTypeInput == "2")
            {
                roomType = 'W';
            }
            // Otherwise (input is something else)
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            // Create list to hold found Appliance objects
            List<Appliance> foundMicrowaves = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test current appliance is Microwave
                if (appliance is Microwave microwave)
                {
                    // Test room type equals 'A' or microwave room type
                    if (roomType == 'A' || microwave.RoomType == roomType)
                    {
                        // Add current appliance in list to found list
                        foundMicrowaves.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(foundMicrowaves, 0);
        }

        public override void DisplayDishwashers()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");
            Console.Write("Enter sound rating: ");

            // Get user input as string and assign to variable
            string soundRatingInput = Console.ReadLine();

            // Create variable that holds sound rating
            string soundRating;

            // Test input is "0"
            if (soundRatingInput == "0")
            {
                soundRating = "Any";
            }
            // Test input is "1"
            else if (soundRatingInput == "1")
            {
                soundRating = "Qt";
            }
            // Test input is "2"
            else if (soundRatingInput == "2")
            {
                soundRating = "Qr";
            }
            // Test input is "3"
            else if (soundRatingInput == "3")
            {
                soundRating = "Qu";
            }
            // Test input is "4"
            else if (soundRatingInput == "4")
            {
                soundRating = "M";
            }
            // Otherwise (input is something else)
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            // Create list to hold found Appliance objects
            List<Appliance> foundDishwashers = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test if current appliance is dishwasher
                if (appliance is Dishwasher dishwasher)
                {
                    // Test sound rating is "Any" or equals sound rating for current dishwasher
                    if (soundRating == "Any" || dishwasher.SoundRating == soundRating)
                    {
                        // Add current appliance in list to found list
                        foundDishwashers.Add(appliance);
                    }
                }
            }

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(foundDishwashers, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
       public override void RandomList()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");
            Console.Write("Enter type of appliance: ");

            // Get user input as string and assign to appliance type variable
            string applianceTypeInput = Console.ReadLine();

            // Write "Enter number of appliances: "
            Console.Write("Enter number of appliances: ");

            // Get user input as string and assign to variable
            string numInput = Console.ReadLine();

            // Convert user input from string to int
            if (!int.TryParse(numInput, out int num))
            {
                Console.WriteLine("Invalid input for number of appliances.");
                return;
            }

            // Create variable to hold list of found appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test inputted appliance type is "0"
                if (applianceTypeInput == "0")
                {
                    // Add current appliance in list to found list
                    found.Add(appliance);
                }
                // Test inputted appliance type is "1"
                else if (applianceTypeInput == "1" && appliance is Refrigerator)
                {
                    // Add current appliance in list to found list
                    found.Add(appliance);
                }
                // Test inputted appliance type is "2"
                else if (applianceTypeInput == "2" && appliance is Vacuum)
                {
                    // Add current appliance in list to found list
                    found.Add(appliance);
                }
                // Test inputted appliance type is "3"
                else if (applianceTypeInput == "3" && appliance is Microwave)
                {
                    // Add current appliance in list to found list
                    found.Add(appliance);
                }
                // Test inputted appliance type is "4"
                else if (applianceTypeInput == "4" && appliance is Dishwasher)
                {
                    // Add current appliance in list to found list
                    found.Add(appliance);
                }
            }

            // Randomize list of found appliances
            found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, num);
        }
    }
}
