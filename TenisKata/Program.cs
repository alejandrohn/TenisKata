using System;

namespace TenisKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PlayMatch();
        }

        static void PlayMatch()
        {
            Player playerA = new Player("Player1");
            Player playerB = new Player("Player2");

            Match match = new Match(playerA, playerB);

            match.Start();
           
            Stadistics stadistics = new Stadistics(match);

            stadistics.PrintJugadorGanador();
            stadistics.PrintStadisticsPlayer1();
            stadistics.PrintStadisticsPlayer2();
            stadistics.PrintStadisticsSets();

            Console.ReadLine();

        }
    }
}
