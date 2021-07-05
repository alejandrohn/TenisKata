using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    public class Match : IMatch
    {

        private int winSet;
        private int winMatch;
        private int winPoints;
        private int numberOfPointsForStop;
        private List<IGame> games;
        private List<ISetTenis> sets;
        private IPlayer playerA;
        private IPlayer playerB;
        private int initialService;
        Rule rule;
        private int totalPoints;

        private const string INITIAL_SERVICE_ERROR = "Solamente puede iniciar el servicio jugador A o B";

        private const int PLAYER_SERVE_A = 1;
        private const int PLAYER_SERVE_B = 2;
        public Match(IPlayer playerA, IPlayer playerB, int initialService = PLAYER_SERVE_A, int winSet = 6, int winMatch = 2, int winPoints = 4, int numberOfPointsForStop = 10000)
        {
            this.winSet = winSet;
            this.winMatch = winMatch;
            this.winPoints = winPoints;
            this.numberOfPointsForStop = numberOfPointsForStop;

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
            this.totalPoints = 0;
            if (this.initialService != 1 && this.initialService != 2)
                throw new Exception(INITIAL_SERVICE_ERROR);
        }

        public IPlayer GetPlayer1()
        {
            return this.playerA;
        }

        public IPlayer GetPlayer2()
        {
            return this.playerB;
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

        public int GetPlayedSets()
        {
            return this.sets.Count;
        }

        public bool IsCompleteRulesForGame()
        {
           return rule.IsCompleteRulesForVictoryGame(this.playerA, this.playerB, this.winPoints);
        }

        public bool IsCompleteRulesForVictory()
        {
            return rule.IsCompleteRulesForVictory(this.playerA, this.playerB, this.winMatch, GetTotalPointsMatch(), this.numberOfPointsForStop);
        }

        public bool IsCompleteRulesForVictorySet()
        {
            return rule.IsCompleteRulesForVictorySet(this.playerA, this.playerB, this.winSet);
        }

        public int TotalGamesPlayed()
        {
            throw new NotImplementedException();
        }

        public int TotalPointsPlayed()
        {
            return totalPoints;
        }

        public int TotalSetsPlayed()
        {
            throw new NotImplementedException();
        }

        public IPlayer GetWinPlayer()
        {
            if(IsCompleteRulesForVictory())
            {
                return rule.GetWinner(playerA, playerB, this.winMatch, this.GetTotalPointsMatch(), this.numberOfPointsForStop);
            }

            throw new Exception("Todavía no ha acabado el juego");
        }

        public void Start()
        {
            while (!IsCompleteRulesForVictory()) {
                PlaySet();      
            }
        }

        public void PlaySet()
        {
            SetTenis setTenis = new SetTenis();

            while (!IsCompleteRulesForVictorySet() && (this.totalPoints < this.numberOfPointsForStop))
            {
                IGame game  = PlayGame();
                setTenis.AddGameToSet(game);
            }

            Dictionary<string, IPlayer> result = WinAndDefeatPlayer();
            setTenis.AddDefeatPlayer(result["defeat"]);
            setTenis.AddWinPlayer(result["win"]);
            sets.Add(setTenis);
            SetResultToPlayer(result, setTenis);

            this.playerA.NewSet();
            this.playerB.NewSet();
        }

        public IGame PlayGame()
        {
            Game game = new Game(playerA, playerB);

            if (initialService == PLAYER_SERVE_B)
            {
                game = new Game(playerB, playerA);
                this.initialService = PLAYER_SERVE_A;
            }
            else
                this.initialService = PLAYER_SERVE_B;
            

            while(!game.IsFinishedGame())
            {
                game.PlayNewPoint();
                this.totalPoints++;
                if (StopGameLimitPoint())
                    return game;

                if (this.IsCompleteRulesForGame())
                {
                    game.SetFinishedGame(true);
                    game.SetPlayerWin(rule, this.winPoints);
                    games.Add(game);
                   
                }
            }

            return game;
        
        }

        private int GetTotalPointsMatch()
        {
            return totalPoints;
        }

        private bool StopGameLimitPoint()
        { return this.totalPoints == numberOfPointsForStop; }

        private Dictionary<string, IPlayer> WinAndDefeatPlayer()
        {
            Dictionary<string, IPlayer> result = new Dictionary<string, IPlayer>();
            if(this.playerA.GetCurrentGamesInSet() > this.playerB.GetCurrentGamesInSet())
            {
                result["win"] = playerA;
                result["defeat"] = playerB;
            }
            else
            {
                result["win"] = playerB;
                result["defeat"] = playerA;
            }

            return result;
        }

        private void SetResultToPlayer(Dictionary<string, IPlayer> result, ISetTenis setTenis)
        {
            IPlayer playerWin = result["win"];
            playerWin.AddWinSet(setTenis);
        }
    }
}
