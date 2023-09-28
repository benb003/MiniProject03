using System;
namespace MiniProject03
{
    public class Service
    {
        private static List<Asset> assets = new List<Asset>();

        public static void AddAsset()
        {
            Console.Write("Enter Type: ");
            string type = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Model: ");
            string model = Console.ReadLine() ?? string.Empty;
            bool isValidOffice = false;
            string officeName="";
            while (!isValidOffice)
            {
                Console.Write("Enter Office (for Malmö '1' for London '2' for New York '3'): ");
                officeName = Console.ReadLine() ?? string.Empty;
                if (officeName == "1" || officeName =="2" || officeName =="3")
                {
                    isValidOffice = true;
                    break;
                }
                Console.WriteLine("Invalid Office. Try Again");
            }
            Location location = (Location)Enum.Parse(typeof(Location), officeName);
            Console.Write("Enter Purchase Date (format yyyy-mm-dd)");            
            bool isValidDate = DateTime.TryParse(Console.ReadLine(), out DateTime purchaseDate);
            if (!isValidDate)
            {
                Console.WriteLine("Invalid date. Date is set as today!");
                purchaseDate = DateTime.Now;
            }
            Console.Write("Enter Price in USD: ");
            bool isValidPrice = int.TryParse(Console.ReadLine(), out int price);
            assets.Add(new Asset(type,brand,model,price,purchaseDate,new Office(location)));
            Console.WriteLine("Asset was added");                       
            MainMenu(); 
        }

        public static void ShowList()
        {
            List<Asset> sortedList = assets.OrderBy(p => p.Office.Location).ThenBy(p => p.PurchaseDate).ToList();
            Console.WriteLine( "TYPE".PadRight(15) + "BRAND".PadRight(15) + "MODEL".PadRight(15) + 
                "Office".PadRight(15) + "PURCHASE DATE".PadRight(15) + "PRICE IN USD".PadRight(15) +
                "CURRENCY".PadRight(15) + "LOCAL PRICE".PadRight(15));
            foreach (var asset in sortedList)
            {
                TimeSpan timeSpan = DateTime.Today - asset.PurchaseDate;
                if (timeSpan.TotalDays > 990)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(asset);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if(timeSpan.TotalDays > 900)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(asset);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(asset);
                }
            }
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine("Please make a selection");
            Console.WriteLine("1: Enter a asset");
            Console.WriteLine("2: Show Asset List");
            Console.WriteLine("0: Quit");
            Console.Write("Your selection :");
            string userInput = Console.ReadLine() ?? string.Empty;

            switch (userInput)
            {
                case "1":
                    Service.AddAsset();
                    break;
                case "2":
                    Service.ShowList();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    MainMenu();
                    break;
            }

        }
    }
}

