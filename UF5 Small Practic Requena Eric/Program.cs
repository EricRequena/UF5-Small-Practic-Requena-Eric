using System;
using M03.UF5._AC1._Tipus_avançats_de_dades_en_C__Requena_Eric;

namespace UF5
{
    public class Program
    {
        public static void Main()
        {
            const int MAX_SCORES = 10;

            List<Score> scores = new List<Score>();
            
            for (int i = 0; i < MAX_SCORES; i++)
            {
                Console.WriteLine("Enter player name: ");
                string player = Console.ReadLine();
                Console.WriteLine("Enter mission name: ");
                string mission = Console.ReadLine();
                Console.WriteLine("Enter score: ");
                int score = Convert.ToInt32(Console.ReadLine());
                Score s = new Score(player, mission, score);
                if (s.Player == null || s.Mission == null || !(score >= 0 && score <= 500))
                {
                    i--;
                }
                else
                {   
                     scores.Add(s);
                }
            }/*
            scores.Add(new Score("Laura", "Delta-001", 120));
            scores.Add(new Score("Hugo", "Delta-002", 150));
            scores.Add(new Score("Laura", "Delta-001", 135));
            scores.Add(new Score("Tomas", "Delta-001", 200));
            scores.Add(new Score("Laura", "Delta-002", 175));*/
            
            List<Score> uniqueScores = GenerateUniqueScores(scores);
            uniqueScores.Sort();
            foreach (Score s in uniqueScores)
            {
                Console.WriteLine(s);
            }
        }

        public static List<Score> GenerateUniqueScores(List<Score> scores)
        {
            // En la lista de scores, agrupamos por jugador y misión, y seleccionamos el máximo score de cada mision
            var uniqueScores = from s in scores 
                               group s by new { s.Player, s.Mission } into g
                               select new Score(g.Key.Player, g.Key.Mission, g.Max(x => x.Scoring));
            return uniqueScores.ToList();

        }
    }
}