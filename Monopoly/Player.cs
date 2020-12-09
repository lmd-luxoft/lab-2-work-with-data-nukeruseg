using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class Player
    {
        public string Name { get; set; }
        public int Cash { get; set; }
        public int Id { get; set; }

        public Player(string name, int cash)
        {
            Name = name;
            Cash = cash;
        }

        public Player(string name, int cash, int id)
        {
            Name = name;
            Cash = cash;
            Id = id;
        }

        public bool Buy(BaseField field)
        {
            if (!field.CanBeBought || field.OwnedPlayerId != 0)
                return false;
            Cash -= field.BuyPrice;
            field.OwnedPlayerId = Id;
            return true;
        }

        public bool Rent(BaseField field)
        {
            if (!field.CanBeRented)
                return false;
            Cash -= field.RentPrice;
            field.OwnedPlayerId = Id;
            return true;
        }

        public void PayRent(BaseField field)
        {
            Cash += field.RentPrice;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Player otherPlayer = obj as Player;
            return Name.Equals(otherPlayer.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
