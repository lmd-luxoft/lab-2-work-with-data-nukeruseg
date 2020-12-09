using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class BaseField
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public int OwnedPlayerId { get; set; }
        public int BuyPrice { get; set; }
        public int RentPrice { get; set; }
        public bool CanBeBought { get; set; }
        public bool CanBeRented { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            BaseField otherField = obj as BaseField;
            return Name == otherField.Name &&
                Type == otherField.Type &&
                OwnedPlayerId == otherField.OwnedPlayerId &&
                BuyPrice == otherField.BuyPrice &&
                RentPrice == otherField.RentPrice &&
                CanBeBought == otherField.CanBeBought &&
                CanBeRented == otherField.CanBeRented;
        }
    }
}
