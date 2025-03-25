using lexicon_mp_13;
using System.Diagnostics;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {

        Tracker tracker = new Tracker();

        //Sample data
        tracker.AddAsset(new Asset("iPhone", "8", "Spain", new DateTime(2023, 3, 25), 970, "Phone"));
        tracker.AddAsset(new Asset("HP", "Elitebook", "Spain", new DateTime(2022, 6, 1), 1423.70, "Computer"));
        tracker.AddAsset(new Asset("Lenovo", "Yoga 530", "USA", new DateTime(2023, 3, 20), 1030.40, "Computer"));
        tracker.AddAsset(new Asset("Motorola", "Razr", "Sweden", new DateTime(2022, 3, 16), 970, "Computer"));
        tracker.AddAsset(new Asset("HP", "Elitebook", "Sweden", new DateTime(2021, 2, 2), 588, "Computer"));
        tracker.AddAsset(new Asset("iPhone", "X", "Sweden", new DateTime(2022, 7, 15), 1245, "Phone"));
        tracker.AddAsset(new Asset("ASUS", "W234", "USA", new DateTime(2022, 4, 21), 1200, "Computer"));
        tracker.AddAsset(new Asset("iPhone", "11", "Spain", new DateTime(2023, 9, 25), 990, "Phone"));
        tracker.AddAsset(new Asset("Lenovo", "Yoga 730", "USA", new DateTime(2020, 3, 24), 835, "Computer"));
   
        string input;
        while (true)
        {
            Console.WriteLine("Choose to Display Assets or Add new Asset");
            Console.WriteLine("(1) Add new Asset");
            Console.WriteLine("(2) Display Assets");
            Console.WriteLine("(3) Quit program");

            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    tracker.TakeInput();
                    break;
                case "2":
                    tracker.DisplayAssets();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

       





