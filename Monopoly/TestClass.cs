// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static Monopoly.Monopoly;

namespace Monopoly
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void GetPlayersListReturnCorrectList()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Player[] expectedPlayers = new Player[]
            {
                new Player("Peter",6000),
                new Player("Ekaterina",6000),
                new Player("Alexander",6000),
            };
            Monopoly monopoly = new Monopoly(players);
            Player[] actualPlayers = monopoly.GetPlayersList().ToArray();

            Assert.AreEqual(expectedPlayers, actualPlayers);
        }
        [Test]
        public void GetFieldsListReturnCorrectList()
        {
            BaseField[] expectedCompanies = new BaseField[]
            {
                new Field("Ford", Type.AUTO, 500, 250),
                new Field("MCDonald", Type.FOOD, 250, 250),
                new Field("Lamoda", Type.CLOTHER, 1000, 1000),
                new Field("Air Baltic", Type.TRAVEL, 700, 300),
                new Field("Nordavia", Type.TRAVEL, 700, 300),
                new UnBoughtableField("Prison", Type.PRISON, 1000),
                new Field("MCDonald", Type.FOOD, 250, 250),
                new Field("TESLA", Type.AUTO, 500, 250),
            };
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            BaseField[] actualCompanies = monopoly.GetFieldsList().ToArray();
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }
        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            BaseField x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            Player actualPlayer = monopoly.GetPlayerInfo(1);
            Player expectedPlayer = new Player("Peter", 5500);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            BaseField actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(1, actualField.OwnedPlayerId);
        }
        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players);
            BaseField x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            x = monopoly.GetFieldByName("Ford");
            monopoly.Renta(2, x);
            Player player1 = monopoly.GetPlayerInfo(1);
            Assert.AreEqual(5750, player1.Cash);
            Player player2 = monopoly.GetPlayerInfo(2);
            Assert.AreEqual(5750, player2.Cash);
        }
    }
}
