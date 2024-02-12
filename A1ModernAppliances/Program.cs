using System;

namespace ModernAppliances
{
    internal class Program
    {
        /// <summary>
        /// Entry point to program
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            ModernAppliances modernAppliances = new MyModernAppliances();
            ModernAppliances.Options option = ModernAppliances.Options.None;
            
            while (option != ModernAppliances.Options.SaveExit)
            {
                modernAppliances.DisplayMenu();

                option = Enum.Parse<ModernAppliances.Options>(Console.ReadLine());
                
                switch (option)
                {
                    case ModernAppliances.Options.Checkout:
                    {
                        modernAppliances.Checkout(); // Ensure the Checkout method is called
                        Console.WriteLine(option);
                        break;
                    }
                    case ModernAppliances.Options.Find:
                    {
                        modernAppliances.Find();

                        break;
                    }
                    case ModernAppliances.Options.DisplayType:
                    {
                        modernAppliances.DisplayType();

                        break;
                    }
                        
                    case ModernAppliances.Options.RandomList:
                    {
                        modernAppliances.RandomList();
                        break;
                    }
                    case ModernAppliances.Options.SaveExit:
                    {
                        modernAppliances.Save();
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid option entered. Please try again.");
                        break;
                    }
                }
            }

            
        }
    }
}
