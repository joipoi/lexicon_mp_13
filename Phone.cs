using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexicon_mp_13
{
    class Phone : Asset
    {
        public Phone(string brand, string model, string office, DateTime purchaseDate, double price)
            : base(brand, model, office, purchaseDate, price)
        {
        }
    }
}
