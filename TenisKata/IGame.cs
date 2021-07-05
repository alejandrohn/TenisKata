using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    public interface IGame
    {
        public int TotalOfPoints();

        public double Duration();

        public IPlayer PlayerWithService();

        public IPlayer PlayerWithRest();

        public IPlayer PlayerVictory();

        public IPlayer PlayerDefeat();

        public void InitializePlayers();

        public bool IsMatchedPlayers();

        public int InitialScore();

        public void PlayNewPoint();

      

        public void SetPlayerWin(Rule rule, int pointsForWin);


    }
}
