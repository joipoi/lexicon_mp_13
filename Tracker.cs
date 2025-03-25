using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexicon_mp_13
{
    class Tracker
    {
        public List<Asset> Assets { get; set; }

        public Tracker()
        {
            Assets = new List<Asset>();
        }

        public void AddAsset(Asset asset)
        {
            Assets.Add(asset);
        }

        public void TakeInput()
        {
            Console.WriteLine("Enter Office(Spain/USA/Sweden)");
            string office;
            while (true)
            {
                office = Console.ReadLine();
                if(office.ToLower() == "spain" || office.ToLower() == "usa" || office.ToLower() == "sweden")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter spain,usa or sweden");
                    Console.ResetColor();
                }

            }

            Console.WriteLine("Enter Brand");
            string brand = Console.ReadLine();

            Console.WriteLine("Enter Model");
            string model = Console.ReadLine();

            Console.WriteLine("Enter Price in USD");
            double price;

            while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid non-negative price.");
                Console.ResetColor();
            }

            Console.WriteLine("Enter PurchaseDate in format(yyyy-MM-dd)");
            DateTime purchaseDate;

            while (!DateTime.TryParse(Console.ReadLine(), out purchaseDate))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a date in valid format(yyyy-MM-dd)");
                Console.ResetColor();
            }

            AddAsset(new Asset(brand, model, office, purchaseDate, price));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Succesfully Added new Asset");
            Console.ResetColor();
        }
        public void DisplayAssets()
        {
            Assets = Assets.OrderBy(a => a.Office).ThenBy(a => a.PurchaseDate).ToList();

            Console.WriteLine("--------------------------------------------------------------");

            int padding = 15;
            string headers = string.Concat(
            "Office".PadRight(padding),
            "Asset".PadRight(padding),
            "Brand".PadRight(padding),
            "Model".PadRight(padding),
            "Price(USD)".PadRight(padding),
            "Price(Local)".PadRight(padding),
            "PurchaseDate".PadRight(padding)
        );
            Console.WriteLine(headers);
            foreach (Asset asset in Assets)
            {
                Console.ForegroundColor = LineColor(asset.PurchaseDate);
                Console.WriteLine(asset.ToString());
                Console.ResetColor();
            }

            Console.WriteLine("--------------------------------------------------------------");
        }

        private static ConsoleColor LineColor(DateTime purchaseDate)
        {
            DateTime endOfLife = purchaseDate.AddYears(Asset.EndOfLife);
            int dayDiff = (endOfLife - DateTime.Now).Days;

            ConsoleColor cc;

            if (dayDiff < 0)
            {
                cc = ConsoleColor.DarkGray;
            }
            else if (dayDiff < 90)
            {
                cc = ConsoleColor.Red;
            }
            else if (dayDiff < 180)
            {
                cc = ConsoleColor.Yellow;
            }
            else
            {
                cc = ConsoleColor.White;
            }
            return cc;
        }
    }
}
