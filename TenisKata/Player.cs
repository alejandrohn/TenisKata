using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    class Player : IPlayer
    {

        private List<IGame> games;
        private List<IGame> defeatGames;
        private List<ISetTenis> winSets;
        private IGame currentGame;
        private int totalWinPoint;
        private int totalDefeatPoint;
        private string[] resultType;
        private Random rnd;
        private int currentGamesInSet;
        private string namePlayer;


        private Guid idPlayer;
        private int currentGamePoints;

        private const int INIT_POINT = 0;

        public Player(string name)
        {
            this.namePlayer = name;
            Init();
        }

        private void Init()
        {
            this.idPlayer = Guid.NewGuid();
            this.games = new List<IGame>();
            this.winSets = new List<ISetTenis>();
            this.defeatGames = new List<IGame>();
            this.resultType = new string[] { "0", "1" };

            this.totalWinPoint = 0;
            this.totalDefeatPoint = 0;
            this.currentGamePoints = INIT_POINT;
            this.currentGamesInSet = 0;
            rnd = new Random();

            if (string.IsNullOrEmpty(this.namePlayer))
                throw new Exception("Agregue un nombre válido para el jugador");
        }

        public void AddCurrentGamePoint()
        {
            this.currentGamePoints++;
        }

        public int GetCurrentGamePoints()
        {
           return this.currentGamePoints;
        }

        public void ResetCurrentGamePoints()
        {
            this.currentGamePoints = INIT_POINT;
        }

        public void AddGame()
        {
            this.games.Add(this.currentGame);
            this.currentGame = null;
            this.currentGamesInSet++;
        }

        public int GetCurrentGamesInSet()
        {
            return this.currentGamesInSet;
        }

        public void NewSet()
        {
            this.currentGamesInSet = 0;
        }

        public void AddDefeatGame()
        {
            this.defeatGames.Add(this.currentGame);
            this.currentGame = null;
        }

        public void AddDefeatPoint()
        {
            this.totalDefeatPoint++;
        }

        public void AddWinPoint()
        {
            this.totalWinPoint++;
        }

        public void AddWinSet(ISetTenis setTenis)
        {
            winSets.Add(setTenis);
        }

        public List<IGame> GetGames()
        {
            return this.games;
        }

        public Guid GetIdPlayer()
        {
            return idPlayer;
        }

        public int GetLostGames()
        {
           
            return this.defeatGames.Count;
        }

        public int GetLostPoints()
        {
            return totalDefeatPoint;
        }

        public int GetLostSets()
        {
            throw new NotImplementedException();
        }

        public List<ISetTenis> GetSets()
        {
            throw new NotImplementedException();
        }

        public int GetWinGames()
        {
            return this.games.Count;
        }

        public int GetWinPoints()
        {
            return totalWinPoint;
        }

        public int GetWinSets()
        {
            return this.winSets.Count;
        }

        public void InitializeScoreGame()
        {
            throw new NotImplementedException();
        }

        public void NewGame(IGame game)
        {
            this.currentGame = game;
        }

        public int PlayAndResult()
        {
            int rtIndex = rnd.Next(this.resultType.Length);
            return rtIndex;
        }

        public string GetPlayerName()
        {
            return this.namePlayer;
        }

    }
}
