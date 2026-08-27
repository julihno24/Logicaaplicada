using System;
namespace the_strongest_beam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la viga: ");
            string input = Console.ReadLine();

            Beam beam = new Beam(input);
            if (!beam.IsValidStructure())
            {
                Console.WriteLine("La viga está mal construida!");
            }
            else if (beam.SupportsWeight())
            {
                Console.WriteLine("La viga soporta el peso!");
            }
            else
            {
                Console.WriteLine("La viga NO soporta el peso!");
            }
        }
    }
}