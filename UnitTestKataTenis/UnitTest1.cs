using Microsoft.VisualStudio.TestTools.UnitTesting;
using TenisKata;

namespace UnitTestKataTenis
{
    [TestClass]
    public class TenisKataTests
    {
        [TestMethod]
        public void FinishWinPlayer()
        {
            Player playerA = new Player("Player1");
            Player playerB = new Player("Player2");

            Match match = new Match(playerA, playerB);

            match.Start();
        }
    }
}
