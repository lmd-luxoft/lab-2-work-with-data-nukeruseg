using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class UnBoughtableField : BaseField
    {
        public UnBoughtableField(string name, Type type, int rentPrice)
        {
            Name = name;
            Type = type;
            RentPrice = rentPrice;
            CanBeBought = false;
            CanBeRented = true;
        }
    }
}
