using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexicon_mp_13
{
    class Asset
    {
        public  const int EndOfLife = 3;

        public string Brand { get; set; }
        public string Model { get; set; }

        public double Price { get; set; }
        public double LocalPrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string Office { get; set; }

        public string Currency { get; set; }

        public Asset(string brand, string model, string office, DateTime purchaseDate, double price)
        {
            Office = office;
            Brand = brand;
            Model = model;
            Price = price;
            Currency = SetCurrency();
            PurchaseDate = purchaseDate;
            LocalPrice = CurrencyConverter.Convert(price, "USD", Currency);
            
        }
        private string SetCurrency()
        {
            if(Office.ToLower() == "spain")
            {
                return"EUR";
            }else if (Office.ToLower() == "usa")
            {
                return "USD";
            }
            else if (Office.ToLower() == "sweden")
            {
                return "SEK";
            }
            return "";
        }

        public override string? ToString()
        {
            int padding = 15;
            return string.Concat(
        Office.PadRight(padding),
        this.GetType().Name.PadRight(padding),  
        Brand.PadRight(padding),
        Model.PadRight(padding),
        Price.ToString("0.00").PadRight(padding),
        Currency," ",
        LocalPrice.ToString("0.00").PadRight(padding-4),
        PurchaseDate.ToString().PadRight(padding)
    );
        }

       
    }
}
