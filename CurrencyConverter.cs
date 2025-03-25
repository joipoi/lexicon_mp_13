using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lexicon_mp_13
{
    class CurrencyConverter
    {
        private static List<CurrencyObj> currencyList = new List<CurrencyObj>();

        public static void FetchRates()
        {
            string url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml"; // Exchange rate XML document

            XmlTextReader reader = new XmlTextReader(url);
            while (reader.Read()) // Goes through the XML document and saves the currency exchange rates to the local list
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    while (reader.MoveToNextAttribute())
                    {
                        if (reader.Name == "currency") // Identifies each currency attribute and saves the currency code and rate as an object
                        {
                            string currencyCode = reader.Value;

                            reader.MoveToNextAttribute();
                            double rate = double.Parse(reader.Value);
                            currencyList.Add(new CurrencyObj(currencyCode, rate));
                        }
                    }
                }
            }
        }

        public static double Convert(double input, string fromCurrency, string toCurrency) // Method that uses the fetched rates to convert between the given rates via Euro
        {
            FetchRates();

            double value = 0;

            if (fromCurrency == "EUR")
            {
                value = input * currencyList.Find(c => c.CurrencyCode == toCurrency).Rate;
            }
            else if (toCurrency == "EUR")
            {
                value = input / currencyList.Find(c => c.CurrencyCode == fromCurrency).Rate;
            }
            else
            {
                value = input / currencyList.Find(c => c.CurrencyCode == fromCurrency).Rate;
                value *= currencyList.Find(c => c.CurrencyCode == toCurrency).Rate;
            }

            return value;
        }
    }
    class CurrencyObj
    {
        public string CurrencyCode { get; set; }
        public double Rate { get; set; }

        public CurrencyObj(string currencyCode, double rate)
        {
            CurrencyCode = currencyCode;
            Rate = rate;
        }
    }
}
