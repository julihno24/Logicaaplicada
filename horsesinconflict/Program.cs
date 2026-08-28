using System;
using System.Collections.Generic;
using System.Linq;

namespace horsesinconflict
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese ubicación de los caballos: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) return;

            string[] rawKnights = input.Split(',');
            List<Knigh> knights = rawKnights.Select(k => new Knigh(k)).ToList();

            foreach (var current in knights)
            {
                List<string> conflicts = new List<string>();
                var otherKnights = knights.AsEnumerable().Reverse();

                foreach (var other in otherKnights)
                {
                    if (current != other && current.Attacks(other))
                    {
                        conflicts.Add($"Conflicto con {other.FormattedPosition}");
                    }
                }

                if (conflicts.Count > 0)
                {
                    Console.WriteLine($"Analizando Caballo en {current.FormattedPosition} => {string.Join("\t\t", conflicts)}");
                }
                else
                {
                    Console.WriteLine($"Analizando Caballo en {current.FormattedPosition} =>");
                }
            }
        }
    }
}