using System;
using System.Collections.Generic;
using System.IO;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Entities.ProblemDomain;

namespace ModernAppliances
{
    internal abstract class ModernAppliances
    {
        public const string APPLIANCES_TEXT_FILE = "appliances.txt";

        private List<Appliance> appliances;

        public List<Appliance> Appliances
        {
            get { return new List<Appliance>(appliances); }
        }

        public enum Options
        {
            None,
            Checkout = 1,
            Find = 2,
            DisplayType = 3,
            RandomList = 4,
            SaveExit = 5,
        }

        public ModernAppliances()
        {
            this.appliances = ParseAppliancesFile();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to Modern Appliances!");
            Console.WriteLine("How May We Assist You ?");
            Console.WriteLine("1 – Check out appliance");
            Console.WriteLine("2 – Find appliances by brand");
            Console.WriteLine("3 – Display appliances by type");
            Console.WriteLine("4 – Produce random appliance list");
            Console.WriteLine("5 – Save & exit");
        }

        public abstract void Checkout();

        public abstract void Find();

        public void DisplayType()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");

            Console.Write("Enter type of appliance:");

            int applianceTypeNum;
            bool parsedApplianceType = int.TryParse(Console.ReadLine(), out applianceTypeNum);

            if (!parsedApplianceType || applianceTypeNum < 0 || applianceTypeNum > 4)
            {
                Console.WriteLine("Invalid appliance type entered.");
                return;
            }

            switch (applianceTypeNum)
            {
                case 1:
                    {
                        this.DisplayRefrigerators();
                        break;
                    }

                case 2:
                    {
                        this.DisplayVacuums();
                        break;
                    }

                case 3:
                    {
                        this.DisplayMicrowaves();
                        break;
                    }

                case 4:
                    {
                        this.DisplayDishwashers();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Invalid appliance type entered.");
                        break;
                    }
            }
        }

        public abstract void DisplayRefrigerators();

        public abstract void DisplayVacuums();

        public abstract void DisplayMicrowaves();

        public abstract void DisplayDishwashers();

        public abstract void RandomList();

        public void Save()
        {
            Console.Write("Saving... ");

            StreamWriter fileStream = File.CreateText(APPLIANCES_TEXT_FILE);

            foreach (var appliance in appliances)
            {
                fileStream.WriteLine(appliance.FormatForFile());
            }

            fileStream.Close();

            Console.WriteLine("DONE!");
        }

        private List<Appliance> ParseAppliancesFile()
        {
            List<Appliance> parsedAppliances = new List<Appliance>();

            try
            {
                string[] lines = File.ReadAllLines(APPLIANCES_TEXT_FILE);

                foreach (string line in lines)
                {
                    Appliance? appliance = CreateApplianceFromLine(line);

                    if (appliance != null)
                    {
                        parsedAppliances.Add(appliance);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The appliances.txt file was not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while parsing the appliances file: {ex.Message}");
            }

            return parsedAppliances;
        }

private Appliance? CreateApplianceFromLine(string line)
{
    string[] parts = line.Split(';');

    if (parts.Length == 0)
    {
        Console.WriteLine("Error: Empty line encountered while parsing appliances file.");
        return null;
    }

    long itemNumber;
    if (!long.TryParse(parts[0], out itemNumber))
    {
        Console.WriteLine($"Error: Invalid item number format: {parts[0]}");
        return null;
    }

    switch (Appliance.DetermineApplianceTypeFromItemNumber(itemNumber))
    {
        case Appliance.ApplianceTypes.Refrigerator:
            return CreateRefrigeratorFromParts(parts);
        case Appliance.ApplianceTypes.Vacuum:
            return CreateVacuumFromParts(parts);
        case Appliance.ApplianceTypes.Microwave:
            return CreateMicrowaveFromParts(parts);
        case Appliance.ApplianceTypes.Dishwasher:
            return CreateDishwasherFromParts(parts);
        default:
            Console.WriteLine($"Error: Unknown appliance type for item number: {itemNumber}");
            return null;
    }
}

private Refrigerator? CreateRefrigeratorFromParts(string[] parts)
{
    if (parts.Length != 9)
    {
        Console.WriteLine($"Error: Invalid number of parts for refrigerator: {string.Join(",", parts)}");
        return null;
    }

    long itemNumber = long.Parse(parts[0]);
    string brand = parts[1];
    int quantity = int.Parse(parts[2]);
    decimal wattage = decimal.Parse(parts[3]);
    string color = parts[4];
    decimal price = decimal.Parse(parts[5]);
    short doors = short.Parse(parts[6]);
    int width = int.Parse(parts[7]);
    int height = int.Parse(parts[8]);

    return new Refrigerator(itemNumber, brand, quantity, wattage, color, price, doors, width, height);
}

private Vacuum? CreateVacuumFromParts(string[] parts)
{
    if (parts.Length != 8)
    {
        Console.WriteLine($"Error: Invalid number of parts for vacuum: {string.Join(",", parts)}");
        return null;
    }

    long itemNumber = long.Parse(parts[0]);
    string brand = parts[1];
    int quantity = int.Parse(parts[2]);
    decimal wattage = decimal.Parse(parts[3]);
    string color = parts[4];
    decimal price = decimal.Parse(parts[5]);
    string grade = parts[6];
    short batteryVoltage = short.Parse(parts[7]);

    return new Vacuum(itemNumber, brand, quantity, wattage, color, price, grade, batteryVoltage);
}

private Microwave? CreateMicrowaveFromParts(string[] parts)
{
    if (parts.Length != 8)
    {
        Console.WriteLine($"Error: Invalid number of parts for microwave: {string.Join(",", parts)}");
        return null;
    }

    long itemNumber = long.Parse(parts[0]);
    string brand = parts[1];
    int quantity = int.Parse(parts[2]);
    decimal wattage = decimal.Parse(parts[3]);
    string color = parts[4];
    decimal price = decimal.Parse(parts[5]);
    float capacity = float.Parse(parts[6]);
    char roomType = char.Parse(parts[7]);

    return new Microwave(itemNumber, brand, quantity, wattage, color, price, capacity, roomType);
}

private Dishwasher? CreateDishwasherFromParts(string[] parts)
{
    if (parts.Length != 8)
    {
        Console.WriteLine($"Error: Invalid number of parts for dishwasher: {string.Join(",", parts)}");
        return null;
    }

    long itemNumber = long.Parse(parts[0]);
    string brand = parts[1];
    int quantity = int.Parse(parts[2]);
    decimal wattage = decimal.Parse(parts[3]);
    string color = parts[4];
    decimal price = decimal.Parse(parts[5]);
    string feature = parts[6];
    string soundRating = parts[7];

    return new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating);
}

public void DisplayAppliancesFromList(List<Appliance> appliances, int max)
{
    if (appliances.Count > 0)
    {
        Console.WriteLine("Found appliances:");
        Console.WriteLine();

        int count = 0;
        foreach (Appliance appliance in appliances)
        {
            Console.WriteLine(appliance);
            Console.WriteLine();
            count++;

            if (max > 0 && count >= max)
            {
                break;
            }
        }
    }
    else
    {
        Console.WriteLine("No appliances found.");
    }

    Console.WriteLine();
}

public void PurchaseAppliance()
{
    Console.Write("Enter the item number of the appliance you want to purchase: ");
    long itemNumber;
    if (!long.TryParse(Console.ReadLine(), out itemNumber))
    {
        Console.WriteLine("Invalid item number.");
        return;
    }

    Appliance applianceToPurchase = appliances.Find(appliance => appliance.ItemNumber == itemNumber);
    if (applianceToPurchase == null)
    {
        Console.WriteLine("Appliance not found.");
        return;
    }

    if (!applianceToPurchase.IsAvailable)
    {
        Console.WriteLine("Appliance is not available.");
        return;
    }

    Console.WriteLine("Appliance information:");
    Console.WriteLine(applianceToPurchase);
    Console.WriteLine("Thank you for your purchase!");
    applianceToPurchase.Checkout();
}

public void DisplayAppliancesByBrand()
{
    Console.Write("Enter the brand of appliances you want to search for: ");
    string brand = Console.ReadLine();

    List<Appliance> appliancesByBrand = appliances.FindAll(appliance => appliance.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase));
    DisplayAppliancesFromList(appliancesByBrand, 0);
}

public void DisplayRandomAppliances()
{
    Console.Write("Enter the number of random appliances you want to display: ");
    int count;
    if (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
    {
        Console.WriteLine("Invalid input. Please enter a positive integer.");
        return;
    }

    Random random = new Random();
    for (int i = 0; i < count; i++)
    {
        int randomIndex = random.Next(appliances.Count);
        Console.WriteLine(appliances[randomIndex]);
        Console.WriteLine();
    }
}


        public void OnExit()
        {
            Save();
        }
    }
}
