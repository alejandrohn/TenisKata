using System;
using System.Collections.Generic;
using System.Text;

namespace TenisKata
{
    public class Stadistics
    {
        private IMatch match;
        private const int START_NUMBER_SET = 1;
        
        public Stadistics(IMatch match)
        {
            this.match = match;
        }

        public void PrintJugadorGanador()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(string.Format("Jugador ganador: {0}", match.GetWinPlayer().GetPlayerName()));
            Console.WriteLine("----------------------");
        }

        public void PrintStadisticsPlayer1()
        {
            PrintStadistics(match.GetPlayer1());
        }

        public void PrintStadisticsPlayer2()
        {
            PrintStadistics(match.GetPlayer2());
        }

        public void PrintStadisticsSets()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(string.Format("Número de sets jugados: {0}", match.GetPlayedSets()));
            Console.WriteLine("----------------------");
            Console.WriteLine(string.Format("Número de puntos jugados: {0}", match.TotalPointsPlayed()));

            int index = START_NUMBER_SET;
            foreach (var set in match.GetSets())
            {
                
                Console.WriteLine("       ---------------");
                Console.WriteLine(string.Format("Puntos jugados en {0} es {1}", index, set.TotalPointsPlayed()));
                Console.WriteLine("       ---------------");
                index++;
            }
        }

        private void PrintStadistics(IPlayer player)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(string.Format("Nombre del jugador: {0}", player.GetPlayerName()));
            Console.WriteLine("----------------------");
            Console.WriteLine(string.Format("Número de puntos ganados: {0}", player.GetWinPoints()));
            Console.WriteLine("----------------------");
            Console.WriteLine(string.Format("Número de games ganados: {0}", player.GetWinGames()));
            Console.WriteLine("----------------------");
            Console.WriteLine(string.Format("Número de sets ganados: {0}", player.GetWinSets()));
            Console.WriteLine("----------------------");
        }


    }
}
