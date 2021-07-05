using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    public interface ISetTenis
    {
        public IPlayer PlayerVictory();

        public IPlayer PlayerDefeat();

        public int TotalPointsPlayed();

        public int TotalGamesPlayed();

        public List<IGame> GetGames();

        public void AddDefeatPlayer(IPlayer player);

        public void AddWinPlayer(IPlayer player);
    }
}
