using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class Field : BaseField
    {
        public Field(string name, Type type, int buyPrice, int rentPrice)
        {
            Name = name;
            Type = type;
            BuyPrice = buyPrice;
            RentPrice = rentPrice;
            CanBeBought = true;
            CanBeRented = true;
        }
    }
}
