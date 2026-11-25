using System;

namespace Denombrements
{
    class Program
    {
        static long ProduitSuite(int debut, int fin)
        {
            long resultat = 1;
            for (int k = debut; k <= fin; k++)
            {
                resultat *= k;
            }
            return resultat;
        }
        static void Main(string[] args)
        {
            int c = 1;
            while (c != 0)
            {
                Console.WriteLine("Permutation ...................... 1");
                Console.WriteLine("Arrangement ...................... 2");
                Console.WriteLine("Combinaison ...................... 3");
                Console.WriteLine("Quitter .......................... 0");
                Console.Write("Choix :                            ");
                c = int.Parse(Console.ReadLine());
                if (c == 0)
                {
                    Environment.Exit(0);
                }
                if (c == 1)
                {
                    Console.Write("nombre total d'éléments à gérer = ");
                    int n = int.Parse(Console.ReadLine());
                    Console.WriteLine(n + "! = " + (ProduitSuite(1, n)));
                }
                else
                {
                    if (c == 2)
                    {
                        Console.Write("nombre total d'éléments à gérer = ");
                        int t = int.Parse(Console.ReadLine());
                        Console.Write("nombre d'éléments dans le sous ensemble = ");
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine("A(" + t + "/" + n + ") = " + (ProduitSuite(t - n + 1, t)));
                    }
                    else
                    {
                        Console.Write("nombre total d'éléments à gérer = ");
                        int t = int.Parse(Console.ReadLine());
                        Console.Write("nombre d'éléments dans le sous ensemble = ");
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine("C(" + t + "/" + n + ") = " + ((ProduitSuite(t - n + 1, t))) / (ProduitSuite(1, n)));
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
