using System;

namespace Denombrements
{
    class Program
    {
        const int PERMUTATION = 1;
        const int ARRANGEMENT = 2;
        const int COMBINAISON = 3;
        const int QUITTER = 0;
        const int valeurMax = 20;
        static long ProduitSuite(int debut, int fin)
        {
            long resultat = 1;
            for (int k = debut; k <= fin; k++)
            {
                resultat *= k;
            }
            return resultat;
        }
        static int Saisie(string message, int min, int max)
        {
            int reponse = 1;
            do
            {
                try
                {
                    Console.Write(message + " --> ");
                    reponse = int.Parse(Console.ReadLine());
                    if (reponse < min || reponse > max)
                    {
                        Console.WriteLine("Erreur de saisie : choisissez un nombre supérieur ou égal à " + min + " et inférieur ou égal à " + max + ".");
                    }
                }
                catch
                {
                    Console.WriteLine("Erreur de saisie : choisissez un nombre.");
                    reponse = min - 1;
                }
            } while (reponse < min || reponse > max);
            return reponse;
        }
        static void Main(string[] args)
        {
            int choix = 1;
            while (choix != QUITTER)
            {
                Console.WriteLine("Permutation ...................... " + PERMUTATION);
                Console.WriteLine("Arrangement ...................... " + ARRANGEMENT);
                Console.WriteLine("Combinaison ...................... " + COMBINAISON);
                Console.WriteLine("Quitter .......................... " + QUITTER);
                choix = Saisie("Choix", QUITTER, COMBINAISON);
                if (choix == PERMUTATION)
                {
                    int n = Saisie("nombre total d'éléments à gérer", 0, valeurMax);
                    Console.WriteLine(n + "! = " + (ProduitSuite(1, n)));
                }
                else if (choix == ARRANGEMENT)
                {
                    int t = Saisie("nombre total d'éléments à gérer", 0, valeurMax);
                    int n = Saisie("nombre d'éléments dans le sous ensemble", 0, t);
                    Console.WriteLine("A(" + t + "/" + n + ") = " + (ProduitSuite(t - n + 1, t)));
                }
                else if (choix == COMBINAISON)
                {
                    int t = Saisie("nombre total d'éléments à gérer", 0, valeurMax);
                    int n = Saisie("nombre d'éléments dans le sous ensemble", 0, t);
                    Console.WriteLine("C(" + t + "/" + n + ") = " + (ProduitSuite(t - n + 1, t) / ProduitSuite(1, n)));
                }
            }
            Console.ReadLine();
        }
    }
}
