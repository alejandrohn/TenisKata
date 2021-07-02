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
            if (playerServe.GetCurrentGamePoint() == PointsForWin && playerRest.GetCurrentGamePoint() == (PointsForWin - DIFERENCE_POINTS_FOR_WIN))
                return true;

            if (playerRest.GetCurrentGamePoint() == PointsForWin && playerServe.GetCurrentGamePoint() == (PointsForWin - DIFERENCE_POINTS_FOR_WIN))
                return true;

            if (playerServe.GetCurrentGamePoint() > PointsForWin || playerRest.GetCurrentGamePoint() > PointsForWin)
            {
                if (Math.Abs(playerServe.GetCurrentGamePoint() - playerRest.GetCurrentGamePoint()) == DIFERENCE_POINTS_FOR_WIN)
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
