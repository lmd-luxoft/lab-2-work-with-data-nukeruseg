using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Monopoly
    {
        private const int START_CASH = 6000;

        private List<Player> _players = new List<Player>();
        private List<BaseField> _fields = new List<BaseField>();
        public Monopoly(string[] playerNames)
        {
            for (int idx = 1; idx <= playerNames.Length; idx++)
            {
                _players.Add(new Player(playerNames[idx - 1], START_CASH, idx));
            }
            _fields.Add(new Field("Ford", Type.AUTO, 500, 250));
            _fields.Add(new Field("MCDonald", Type.FOOD, 250, 250));
            _fields.Add(new Field("Lamoda", Type.CLOTHER, 1000, 1000));
            _fields.Add(new Field("Air Baltic", Type.TRAVEL, 700, 300));
            _fields.Add(new Field("Nordavia", Type.TRAVEL, 700, 300));
            _fields.Add(new UnBoughtableField("Prison", Type.PRISON, 1000));
            _fields.Add(new Field("MCDonald", Type.FOOD, 250, 250));
            _fields.Add(new Field("TESLA", Type.AUTO, 500, 250));
        }

        internal ReadOnlyCollection<Player> GetPlayersList()
        {
            return _players.AsReadOnly();
        }


        internal ReadOnlyCollection<BaseField> GetFieldsList()
        {
            return _fields.AsReadOnly();
        }

        internal BaseField GetFieldByName(string fieldName)
        {
            return _fields.FirstOrDefault(f => f.Name == fieldName);
        }

        internal bool Buy(int playerId, BaseField field)
        {
            var player = GetPlayerInfo(playerId);
            return player.Buy(field);
        }

        internal Player GetPlayerInfo(int id)
        {
            return _players.FirstOrDefault(p => p.Id == id);
        }

        internal bool Renta(int playerId, BaseField field)
        {
            if (field.OwnedPlayerId == 0)
                return false;
            var player = GetPlayerInfo(playerId);
            var owner = GetPlayerInfo(field.OwnedPlayerId);
            if (player.Rent(field))
            {
                owner.PayRent(field);
                return true;
            }
            else
                return false;
        }
    }
}
