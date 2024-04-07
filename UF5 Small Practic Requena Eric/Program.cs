using System;
using System.Collections.Generic;
using System.Linq;
using M03.UF5._AC1._Tipus_avançats_de_dades_en_C__Requena_Eric;

namespace UF5
{
    public class Program
    {
        public static void Main()
        {
            const int MAX_SCORES =10;

            List<Score> scores = new List<Score>();

            for (int i = 0; i < MAX_SCORES; i++)
            {
                Console.WriteLine("Enter player name: ");
                string player = Console.ReadLine();
                Console.WriteLine("Enter mission name: ");
                string mission = Console.ReadLine();
                Console.WriteLine("Enter score: ");
                int score;
                if (int.TryParse(Console.ReadLine(), out score)) // Utilizamos TryParse para manejar entradas no válidas
                {
                    if (score >= 0 && score <= 500) // Verificamos si la puntuación está dentro del rango válido
                    {
                        Score s = new Score(player, mission, score);
                        scores.Add(s);
                    }
                    else
                    {
                        Console.WriteLine("Score must be between 0 and 500");
                        i--; // Volvemos a solicitar la puntuación para el mismo jugador y misión
                    }
                }
                else
                {
                    Console.WriteLine("Invalid score. Please enter a valid number.");
                    i--; // Volvemos a solicitar la puntuación para el mismo jugador y misión
                }
            }

            List<Score> uniqueScores = GenerateUniqueScores(scores);
            uniqueScores.Sort();
            foreach (Score s in uniqueScores)
            {
                Console.WriteLine(s);
            }
        }

        public static List<Score> GenerateUniqueScores(List<Score> scores)
        {
            // Agrupamos por jugador y misión, y seleccionamos el máximo score de cada misión
            var uniqueScores = scores.GroupBy(s => new { s.Player, s.Mission })
                                     .Select(g => g.OrderByDescending(s => s.Scoring).First())
                                     .ToList();
            return uniqueScores;
        }
    }
}
