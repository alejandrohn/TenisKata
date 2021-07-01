using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    interface IRule
    {
        public bool IsCompleteRulesForVictoryGame(IPlayer playerServe, IPlayer playerRest);

        public bool IsCompleteRulesForVictorySet(IPlayer playerServe, IPlayer playerRest);

        public bool IsCompleteRulesForVictory(IPlayer playerServe, IPlayer playerRest);
    }
}
