using System;

namespace horsesinconflict
{
    public class Knigh
    {
        public string RawPosition { get; }
        public int File { get; }
        public int Rank { get; }

        public Knigh(string position)
        {
            RawPosition = position.Trim().ToUpper();
            if (RawPosition.Length >= 2)
            {
                if (char.IsLetter(RawPosition[0]))
                {
                    File = RawPosition[0] - 'A' + 1;
                    Rank = int.Parse(RawPosition[1].ToString());
                }
                else
                {
                    Rank = int.Parse(RawPosition[0].ToString());
                    File = RawPosition[1] - 'A' + 1;
                }
            }
        }
        public string FormattedPosition => $"{Rank}{(char)('A' + File - 1)}";

        public bool Attacks(Knigh other)
        {
            int deltaFile = Math.Abs(File - other.File);
            int deltaRank = Math.Abs(Rank - other.Rank);

            return (deltaFile == 1 && deltaRank == 2) || (deltaFile == 2 && deltaRank == 1);
        }
    }
}