using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    public interface IRule
    {
        public bool IsCompleteRulesForVictoryGame(IPlayer playerServe, IPlayer playerRest, int PointsForWin);

        public bool IsCompleteRulesForVictorySet(IPlayer playerServe, IPlayer playerRest, int GamesForWin);

        public bool IsCompleteRulesForVictory(IPlayer playerServe, IPlayer playerRest, int setsForWin, int totalPointsMatch, int point_for_stop);

        public IPlayer GetWinner(IPlayer playerServe, IPlayer playerRest, int setsForWin, int totalPointsMatch, int point_for_stop);
    }
}
