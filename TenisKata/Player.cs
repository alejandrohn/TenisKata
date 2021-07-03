using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    class Player : IPlayer
    {

        private List<IGame> games;
        private List<ISetTenis> sets;
        private IGame currentGame;
        private int totalWinPoint;
        private int totalDefeatPoint;
        private string[] resultType;
        private Random rnd;

        private Guid idPlayer;
        private int currentGamePoints;

        private const int INIT_POINT = 0;

        public Player()
        {
            Init();
        }

        private void Init()
        {
            this.idPlayer = Guid.NewGuid();
            this.games = new List<IGame>();
            this.sets = new List<ISetTenis>();
            this.resultType = new string[] { "0", "1" };

            this.totalWinPoint = 0;
            this.totalDefeatPoint = 0;
            this.currentGamePoints = INIT_POINT;
            rnd = new Random();
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
        }

        public void AddDefeatPoint()
        {
            this.totalDefeatPoint++;
        }

        public void AddWinPoint()
        {
            this.totalWinPoint++;
        }

        public void AddSet()
        {
            throw new NotImplementedException();
        }

        public List<IGame> GetGames()
        {
            throw new NotImplementedException();
        }

        public Guid GetIdPlayer()
        {
            throw new NotImplementedException();
        }

        public int GetLostGames()
        {
            throw new NotImplementedException();
        }

        public int GetLostPoints()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public int GetWinPoints()
        {
            throw new NotImplementedException();
        }

        public int GetWinSets()
        {
            throw new NotImplementedException();
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

    }
}
