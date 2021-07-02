using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    class Game : IGame
    {
        private IPlayer playerService;
        private IPlayer playerRest;

        private IPlayer playerWin;
        private IPlayer playerDefeat;

        private int points;
        private const int INITIAL_SCORE = 0;
        private bool finishedGame;

        enum ResultType
        {
            Win = 0,
            Defeat = 1
        }

        public Game(IPlayer playerService, IPlayer playerRest)
        {
            this.playerService = playerService;
            this.playerRest = playerRest;
            Init();
        }

        private void Init()
        {
            this.points = InitialScore();
            this.finishedGame = false;
            this.playerService.ResetCurrentGamePoints();
            this.playerRest.ResetCurrentGamePoints();
            this.playerService.NewGame(this);
            this.playerRest.NewGame(this);
        }

        public double Duration()
        {
            throw new NotImplementedException();
        }

        public void InitializePlayers()
        {
            throw new NotImplementedException();
        }

        public int InitialScore()
        {
            return INITIAL_SCORE;
        }

        public bool IsMatchedPlayers()
        {
            throw new NotImplementedException();
        }

        public IPlayer PlayerDefeat()
        {
            return playerDefeat;
        }

        public IPlayer PlayerVictory()
        {
            return playerWin;
        }

        public IPlayer PlayerWithRest()
        {
            return this.playerRest;
        }

        public IPlayer PlayerWithService()
        {
            return this.playerService;
        }

        public int TotalOfPoints()
        {
            return this.points;
        }

        public void SetFinishedGame(bool status)
        {
            this.finishedGame = status;
        }

        public bool IsFinishedGame()
        {
            return this.finishedGame;
        }


        public void PlayNewPoint()
        {
            var resultPoint = (ResultType)this.playerService.PlayAndResult();

            if (ResultType.Win == resultPoint)
            {
                playerService.AddCurrentGamePoint();
                playerService.AddWinPoint();
                playerRest.AddDefeatPoint();
            }
            else
            {
                playerRest.AddCurrentGamePoint();
                playerRest.AddWinPoint();
                playerService.AddDefeatPoint();
            }
            
            this.points++;
        }

        public void SetPlayerWin(Rule rule, int pointsForWin)
        {
            if (rule.IsCompleteRulesForVictoryGame(playerService, playerRest, pointsForWin))
            {
                if (playerService.GetCurrentGamePoint() > playerRest.GetCurrentGamePoint())
                {
                    playerWin = playerService;
                    playerDefeat = playerRest;
                    playerService.AddGame();
                }
                else if (playerRest.GetCurrentGamePoint() > playerService.GetCurrentGamePoint())
                {
                    playerWin = playerRest;
                    playerDefeat = playerService;
                }
            }
        }
    }
}
