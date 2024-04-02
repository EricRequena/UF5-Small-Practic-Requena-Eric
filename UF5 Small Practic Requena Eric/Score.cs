using System;
using System.Text.RegularExpressions;

namespace M03.UF5._AC1._Tipus_avançats_de_dades_en_C__Requena_Eric
{
    public class Score : IComparable<Score>
    {
        private string player;
        private string mission;
        private int scoring;

        public Score(string player, string mission, int scoring)
        {
            this.Player = player;
            this.Mission = mission;
            this.Scoring = scoring;
        }

        public string Player
        {
            get { return player; }
            set
            {
                if (Regex.IsMatch(value.Trim(), @"^[A-Za-z]+$"))
                {
                    player = value;
                }
                else
                {
                    Console.WriteLine("Player name must contain only alphabetic characters");
                }
            }
        }

        public string Mission
        {
            get { return mission; }
            set
            {

                if (Regex.IsMatch(value.Trim(), @"^(Alpha|Beta|Gamma|Delta|Epsilon|Zeta|Eta|Theta|Iota|Kappa|Lambda|Mu|Nu|Xi|Omicron|Pi|Rho|Sigma|Tau|Upsilon|Phi|Chi|Psi|Omega)-[0-9]{3}$"))
                {
                    mission = value;
                }
                else
                {
                    Console.WriteLine("Mission name must contain the prefix Delta- followed by a 3 digit number");
                }
            }
        }

        public int Scoring
        {
            get { return scoring; }
            set
            {
                if (value >= 0 && value <= 500)
                {
                    scoring = value;
                }
                else
                {
                    Console.WriteLine("Score must be between 0 and 500");
                }
            }
        }

        public int CompareTo(Score? other)
        {
            if (other == null) return 1;
            return -Scoring.CompareTo(other.Scoring);
        }

        public override string ToString()
        {
            return "Player: " + Player + "\nMission: " + Mission + "\nScore: " + Scoring;
        }

    }
}