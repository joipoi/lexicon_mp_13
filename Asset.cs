using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexicon_mp_13
{
    class Asset
    {
        public  const int EndOfLife = 3; //how many years until end of life

        public string Brand { get; set; }
        public string Model { get; set; }

        public double Price { get; set; }
        public double LocalPrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string Office { get; set; }

        public string Currency { get; set; }

        public string AssetType { get; set; }

        
        public Asset(string brand, string model, string office, DateTime purchaseDate, double price, string assetType)
        {
            Office = office;
            Brand = brand;
            Model = model;
            Price = price;
            PurchaseDate = purchaseDate;
            AssetType = assetType;
            Currency = SetCurrency();
            LocalPrice = CurrencyConverter.Convert(price, "USD", Currency);
            
        }
        //Sets the currency based on office
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
            AssetType.PadRight(padding),  
            Brand.PadRight(padding),
            Model.PadRight(padding),
            Price.ToString("0.00").PadRight(padding),
            Currency," ",
            LocalPrice.ToString("0.00").PadRight(padding-4), //padding changes because of Currency
            PurchaseDate.ToString("yyyy-MM-dd").PadRight(padding)
        );
        }

       
    }
}
