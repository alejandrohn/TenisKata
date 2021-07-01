using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    interface IPlayer
    {
        public int GetWinGames();

        public int GetLostGames();

        public int GetWinSets();

        public int GetLostSets();

        public int GetWinPoints();

        public int GetLostPoints();

        public string PlayAndResult();

        public void InitializeScoreGame();

        public void AddPoint();

        public void AddGame();

        public void AddSet();

        public List<IGame> GetGames();

        public List<ISetTenis> GetSets();
        public Guid GetIdPlayer();

    }
}
