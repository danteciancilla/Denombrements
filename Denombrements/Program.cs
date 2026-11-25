using System;

namespace Denombrements
{
    class Program
    {
        const int PERMUTATION = 1;
        const int ARRANGEMENT = 2;
        const int COMBINAISON = 3;
        const int QUITTER = 0;
        const int VALEUR_MAX = 20;
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
                    int nbElements = Saisie("nombre total d'éléments à gérer", 0, valeurMax);
                    Console.WriteLine(nbElements + "! = " + (ProduitSuite(1, nbElements)));
                }
                else if (choix == ARRANGEMENT)
                {
                    int nbElements = Saisie("nombre total d'éléments à gérer", 0, valeurMax);
                    int sousEnsemble = Saisie("nombre d'éléments dans le sous ensemble", 0, nbElements);
                    Console.WriteLine("A(" + nbElements + "/" + sousEnsemble + ") = " + (ProduitSuite(nbElements - sousEnsemble + 1, nbElements)));
                }
                else if (choix == COMBINAISON)
                {
                    int nbElements = Saisie("nombre total d'éléments à gérer", 0, valeurMax);
                    int sousEnsemble = Saisie("nombre d'éléments dans le sous ensemble", 0, nbElements);
                    Console.WriteLine("C(" + nbElements + "/" + sousEnsemble + ") = " + (ProduitSuite(nbElements - sousEnsemble + 1, nbElements) / ProduitSuite(1, sousEnsemble)));
                }
            }
            Console.ReadLine();
        }
    }
}
