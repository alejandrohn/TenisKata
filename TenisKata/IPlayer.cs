using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    public interface IPlayer
    {
        public int GetWinGames();

        public int GetLostGames();

        public int GetWinSets();

        public int GetLostSets();

        public int GetWinPoints();

        public int GetLostPoints();

        public int PlayAndResult();

        public void InitializeScoreGame();

        public void AddDefeatPoint();
        public void AddWinPoint();

        public void AddGame();

        public void AddWinSet(ISetTenis setTenis);

        public List<IGame> GetGames();

        public List<ISetTenis> GetSets();
        public Guid GetIdPlayer();

        public void NewGame(IGame game);

        public void AddCurrentGamePoint();

        public void ResetCurrentGamePoints();

        public int GetCurrentGamePoints();

        public void AddDefeatGame();

        public int GetCurrentGamesInSet();

        public void NewSet();

        public string GetPlayerName();
       
    }
}
