using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    class Rule : IRule
    {
        private const int DIFERENCE_POINTS_FOR_WIN = 2;

        public bool IsCompleteRulesForVictory(IPlayer playerServe, IPlayer playerRest, int SetsForWin)
        {
            return false;
        }

        public bool IsCompleteRulesForVictoryGame(IPlayer playerServe, IPlayer playerRest, int PointsForWin)
        {
            if (playerServe.GetCurrentGamePoints() == PointsForWin && playerRest.GetCurrentGamePoints() == (PointsForWin - DIFERENCE_POINTS_FOR_WIN))
                return true;

            if (playerRest.GetCurrentGamePoints() == PointsForWin && playerServe.GetCurrentGamePoints() == (PointsForWin - DIFERENCE_POINTS_FOR_WIN))
                return true;

            if (playerServe.GetCurrentGamePoints() > PointsForWin || playerRest.GetCurrentGamePoints() > PointsForWin)
            {
                if (Math.Abs(playerServe.GetCurrentGamePoints() - playerRest.GetCurrentGamePoints()) == DIFERENCE_POINTS_FOR_WIN)
                    return true;
            }

            return false;
        }

        public bool IsCompleteRulesForVictorySet(IPlayer playerServe, IPlayer playerRest, int GamesForWin)
        {
            return false;
        }
    }
}
