using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TenisKata;

namespace UnitTestKataTenis
{
    [TestClass]
    public class TenisKataTests
    {
        [TestMethod]
        public void EqualSumOfPointsTotalAndPlayers()
        {
            Player playerA = new Player("Player1Test");
            Player playerB = new Player("Player2Test");

            Match match = new Match(playerA, playerB);

            match.Start();

            Assert.AreEqual(match.TotalPointsPlayed(), (match.GetPlayer1().GetWinPoints() + match.GetPlayer2().GetWinPoints()));
        }

        [TestMethod]
        public void EqualSumOfSetsPlayers()
        {
            Player playerA = new Player("Player1Test");
            Player playerB = new Player("Player2Test");

            Match match = new Match(playerA, playerB);

            match.Start();

            Assert.AreEqual(match.GetPlayedSets(), (match.GetPlayer1().GetWinSets() + match.GetPlayer2().GetWinSets()));
        }

        [TestMethod]
        public void EqualSumOfGamesPlayers()
        {
            Player playerA = new Player("Player1Test");
            Player playerB = new Player("Player2Test");

            Match match = new Match(playerA, playerB);

            match.Start();

            int totalGames = 0;

            List<ISetTenis> sets = match.GetSets();

            foreach (var set in sets)
                totalGames += set.TotalGamesPlayed();


            Assert.AreEqual(totalGames, (match.GetPlayer1().GetWinGames() + match.GetPlayer2().GetWinGames()));
        }

        [TestMethod]
        public void EqualSetsToWin()
        {
            Player playerA = new Player("Player1Test");
            Player playerB = new Player("Player2Test");

            Match match = new Match(playerA, playerB);

            match.Start();

            int defaultNumberOfWinSets = 2;

            IPlayer winner = match.GetWinPlayer();

            Assert.AreEqual(defaultNumberOfWinSets, winner.GetWinSets());
           
        }

        [TestMethod]
        public void EqualSetsToWinForThree()
        {
            Player playerA = new Player("Player1Test");
            Player playerB = new Player("Player2Test");

            Match match = new Match(playerA, playerB, 1, 6, 3);

            match.Start();

            int defaultNumberOfWinSets = 2;

            IPlayer winner = match.GetWinPlayer();

            Assert.AreNotEqual(defaultNumberOfWinSets, winner.GetWinSets());

            defaultNumberOfWinSets = 3;
            Assert.AreEqual(defaultNumberOfWinSets, winner.GetWinSets());

        }

        [TestMethod]
        public void SmallestThanTotalSets()
        {
            Player playerA = new Player("Player1Test");
            Player playerB = new Player("Player2Test");

            Match match = new Match(playerA, playerB, 1, 6, 3);

            match.Start();
            int maxSets = 5;
            
            Assert.IsTrue((match.GetPlayer1().GetWinSets() + match.GetPlayer2().GetWinSets()) <= maxSets);

        }

        [TestMethod]
        public void StopForPointsLimit()
        {
            Player playerA = new Player("Player1Test");
            Player playerB = new Player("Player2Test");

            int stopNumberOfPoints = 100;
            Match match = new Match(playerA, playerB, 1, 6, 3, 4, stopNumberOfPoints);

            match.Start();
           
            Assert.AreEqual(stopNumberOfPoints, (match.GetPlayer1().GetWinPoints() + match.GetPlayer2().GetWinPoints()));

        }
    }
}
