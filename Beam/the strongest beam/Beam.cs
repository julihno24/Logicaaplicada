namespace the_strongest_beam
{
    public class Beam
    {
        private readonly string _structure;

        public Beam(string structure)
        {
            _structure = (structure ?? string.Empty).Trim().Replace("\u00A0", "");
        }

        private int GetBaseResistance()
        {
            if (string.IsNullOrEmpty(_structure)) return -1;

            return _structure[0] switch
            {
                '%' => 10,
                '&' => 30,
                '#' => 90,
                _ => -1
            };
        }

        public bool IsValidStructure()
        {
            if (string.IsNullOrEmpty(_structure)) return false;
            if (GetBaseResistance() == -1) return false;
            for (int i = 1; i < _structure.Length; i++)
            {
                char current = _structure[i];
                if (current != '=' && current != '*') return false;
                if (current == '*' && _structure[i - 1] == '*') return false;
            }

            return true;
        }

        public bool SupportsWeight()
        {
            int baseResistance = GetBaseResistance();
            int totalWeight = 0;
            int runnerCounter = 0;

            for (int i = 1; i < _structure.Length; i++)
            {
                char current = _structure[i];

                if (current == '=')
                {
                    runnerCounter++;
                    totalWeight += 1;
                }
                else if (current == '*')
                {
                    totalWeight += 1; 
                    runnerCounter = 0; 
                }
            }

            return totalWeight <= baseResistance;
        }
    }
}