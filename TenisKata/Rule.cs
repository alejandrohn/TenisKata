using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    class Rule : IRule
    {
        public bool IsCompleteRulesForVictory(IPlayer playerServe, IPlayer playerRest, int SetsForWin)
        {
            return false;
        }

        public bool IsCompleteRulesForVictoryGame(IPlayer playerServe, IPlayer playerRest, int PointsForWin)
        {
            if (playerServe.GetCurrentGamePoint() == PointsForWin && playerRest.GetCurrentGamePoint() == (PointsForWin - 2))
                return true;

            if (playerRest.GetCurrentGamePoint() == PointsForWin && playerServe.GetCurrentGamePoint() == (PointsForWin - 2))
                return true;

            if ((playerServe.GetCurrentGamePoint() - playerRest.GetCurrentGamePoint()) == 2)
                return true;

            if ((playerRest.GetCurrentGamePoint() - playerServe.GetCurrentGamePoint()) == 2)
                return true;

            return false;
        }

        public bool IsCompleteRulesForVictorySet(IPlayer playerServe, IPlayer playerRest, int GamesForWin)
        {
            return false;
        }
    }
}
