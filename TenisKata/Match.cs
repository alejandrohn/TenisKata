using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    class Match : IMatch
    {

        private int winSet;
        private int winMatch;
        private int winPoints;
        private List<IGame> games;
        private List<ISetTenis> sets;
        private IPlayer playerA;
        private IPlayer playerB;
        private int initialService;
        Rule rule;

        private const string INITIAL_SERVICE_ERROR = "Solamente puede iniciar el servicio jugador A o B";
        public Match(IPlayer playerA, IPlayer playerB, int initialService = 1, int winSet = 6, int winMatch = 2, int winPoints = 4)
        {
            this.winSet = winSet;
            this.winMatch = winMatch;
            this.winPoints = winPoints;

            this.playerA = playerA;
            this.playerB = playerB;

            this.initialService = initialService;

            Init();
        }

        private void Init()
        {
            this.sets = new List<ISetTenis>();
            this.games = new List<IGame>();
            this.rule = new Rule();
            if (this.initialService != 1 && this.initialService != 2)
                throw new Exception(INITIAL_SERVICE_ERROR);
        }
        public int GetNumberOfGamesForWinSet()
        {
            return this.winSet;
        }

        public int GetNumberOfPointsForWinGame()
        {
            return winPoints;
        }

        public int GetNumberOfSetsForWinMatch()
        {
            return this.winMatch;
        }

        public List<ISetTenis> GetSets()
        {
            return this.sets;
        }

        public bool IsCompleteRulesForGame()
        {
            throw new NotImplementedException();
        }

        public bool IsCompleteRulesForVictory()
        {
            throw new NotImplementedException();
        }

        public bool IsCompleteRulesForVictorySet()
        {
            throw new NotImplementedException();
        }

        public int TotalGamesPlayed()
        {
            throw new NotImplementedException();
        }

        public int TotalPointsPlayed()
        {
            throw new NotImplementedException();
        }

        public int TotalSetsPlayed()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            while (!IsCompleteRulesForVictory()) {
                PlaySet();      
            }
        }

        public void PlaySet()
        {
            while (!IsCompleteRulesForVictorySet())
            {
                PlayGame();
            }
        }

        public void PlayGame()
        {
            Game game = new Game(playerA, playerB);

            if (initialService == 2)
            { 
                game = new Game(playerB, playerA);
                this.initialService = 1;
            }

            while(game.IsFinishedGame())
            {
                game.PlayNewPoint();
                if (rule.IsCompleteRulesForVictoryGame(this.playerA, this.playerB, this.winPoints))
                {
                    game.SetFinishedGame(true);
                    game.SetPlayerWin(rule, this.winPoints);
                    games.Add(game);
                   
                }
            }
        
        }


    }
}
