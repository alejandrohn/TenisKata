using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    interface IMatch
    {
        public int GetNumberOfSetsForWinMatch();

        public int GetNumberOfGamesForWinSet();

        public int GetNumberOfPointsForWinGame();

        public bool IsCompleteRulesForVictory();

        public bool IsCompleteRulesForVictorySet();

        public bool IsCompleteRulesForGame();

        public int TotalPointsPlayed();

        public int TotalSetsPlayed();

        public int TotalGamesPlayed();

        public List<ISetTenis> GetSets();

        public void Start();

        public void PlaySet();

        public IGame PlayGame();

        public IPlayer GetPlayer1();

        public IPlayer GetPlayer2();

        public int GetPlayedSets();

        public IPlayer GetWinPlayer();
    }
}
