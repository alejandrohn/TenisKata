using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    class SetTenis : ISetTenis
    {
        private List<IGame> games;
        private IPlayer playerA;
        private IPlayer playerB;

        public SetTenis()
        {
            this.games = new List<IGame>();
        }

        public List<IGame> GetGames()
        {
            return this.games;
        }

        public void AddGameToSet(IGame game)
        {
            this.games.Add(game);
        }

        public IPlayer PlayerDefeat()
        {
            return this.playerA;
        }

        public IPlayer PlayerVictory()
        {
            return this.playerB;
        }

        public int TotalGamesPlayed()
        {
            return this.games.Count;
        }

        public int TotalPointsPlayed()
        {
            int totalPointsSet = 0;
           foreach(var game in games)
            {
                totalPointsSet += game.TotalOfPoints();
            }

            return totalPointsSet;
        }

        public void AddDefeatPlayer(IPlayer player)
        {
            this.playerA = player;
}
        public void AddWinPlayer(IPlayer player)
        {
            this.playerB = player;
        }
    }
}
