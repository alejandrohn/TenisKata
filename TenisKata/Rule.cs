using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    public class Rule : IRule
    {
        private const int DIFERENCE_POINTS_FOR_WIN = 2;
        private const int DIFERENCE_GAMES_FOR_WIN_SET = 2;
        private const int VICTORY_FOR_POINTS = 10000;

        public bool IsCompleteRulesForVictory(IPlayer playerServe, IPlayer playerRest, int setsForWin, int totalPointsMatch, int point_for_stop = VICTORY_FOR_POINTS)
        {
            if (playerServe.GetWinSets() == setsForWin || playerRest.GetWinSets() == setsForWin)
                return true;
            if (totalPointsMatch == point_for_stop)
                return true;

            return false;
        }

        public bool IsCompleteRulesForVictoryGame(IPlayer playerServe, IPlayer playerRest, int pointsForWin)
        {
            if (playerServe.GetCurrentGamePoints() == pointsForWin && playerRest.GetCurrentGamePoints() <= (pointsForWin - DIFERENCE_POINTS_FOR_WIN))
                return true;

            if (playerRest.GetCurrentGamePoints() == pointsForWin && playerServe.GetCurrentGamePoints() <= (pointsForWin - DIFERENCE_POINTS_FOR_WIN))
                return true;

            if (playerServe.GetCurrentGamePoints() > pointsForWin || playerRest.GetCurrentGamePoints() > pointsForWin)
            {
                if (Math.Abs(playerServe.GetCurrentGamePoints() - playerRest.GetCurrentGamePoints()) == DIFERENCE_POINTS_FOR_WIN)
                    return true;
            }

            return false;
        }

        public bool IsCompleteRulesForVictorySet(IPlayer playerServe, IPlayer playerRest, int gamesForWin)
        {
            if ((playerServe.GetCurrentGamesInSet() == gamesForWin || playerRest.GetCurrentGamesInSet() == gamesForWin) &&
                Math.Abs(playerRest.GetCurrentGamesInSet() - playerServe.GetCurrentGamesInSet()) >= DIFERENCE_GAMES_FOR_WIN_SET)
                return true;

            if ((playerServe.GetCurrentGamesInSet() > gamesForWin || playerRest.GetCurrentGamesInSet() > gamesForWin) &&
                Math.Abs(playerRest.GetCurrentGamesInSet() - playerServe.GetCurrentGamesInSet()) == DIFERENCE_GAMES_FOR_WIN_SET)
                return true;

            return false;
        }

        public IPlayer GetWinner(IPlayer playerServe, IPlayer playerRest, int setsForWin, int totalPointsMatch, int point_for_stop = VICTORY_FOR_POINTS)
        {
            if (playerServe.GetWinSets() == setsForWin)
                return playerServe;

            if (playerRest.GetWinSets() == setsForWin)
                return playerRest;

            if(totalPointsMatch >= point_for_stop)
            {
                if (playerServe.GetWinGames() > playerRest.GetWinGames())
                    return playerServe;
                else if (playerRest.GetWinGames() > playerServe.GetWinGames())
                    return playerRest;
                else
                {
                    if (playerServe.GetWinPoints() > playerRest.GetWinPoints())
                        return playerServe;
                    else if (playerRest.GetWinPoints() > playerServe.GetWinPoints())
                        return playerRest;

                    throw new Exception("No hay criterio de desempate");
                }

            }
            else
            {
                throw new Exception("Invocación errónea, no hay ganador todavía");
            }
        }
    }
}
