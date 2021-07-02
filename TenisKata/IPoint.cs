using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    interface IPoint
    {
        public bool isGamePoint();

        public int GetPointValue();

        public void SetWinPlayer(IPlayer player);

        public void SetDefeatPlayer(IPlayer player);

        public IPlayer GetWinPlayer();

        public IPlayer GetDefeatPlayer();

    }
}
