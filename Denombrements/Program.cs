using System;

namespace Denombrements
{
    /// <summary>
    /// Application de calculs de dénombrement : permutation, arrangement et combinaison.
    /// </summary>
    class Program
    {
        // valeurs des choix du menu
        const int PERMUTATION = 1;
        const int ARRANGEMENT = 2;
        const int COMBINAISON = 3;
        const int QUITTER = 0;
        // valeur maximale autorisée pour le nombre total d'éléments
        const int VALEUR_MAX = 20;

        /// <summary>
        /// Calcule le produit des entiers consécutifs de debut à fin (exemple : de 4 à 6, 4 * 5 * 6).
        /// </summary>
        /// <param name="debut">premier entier de la suite</param>
        /// <param name="fin">dernier entier de la suite</param>
        /// <returns>produit des entiers de debut à fin (1 si debut est supérieur à fin)</returns>
        static long ProduitSuite(int debut, int fin)
        {
            long resultat = 1;
            for (int k = debut; k <= fin; k++)
            {
                resultat *= k;
            }
            return resultat;
        }

        /// <summary>
        /// Saisie d'un entier avec contrôle : redemande la saisie, avec un message d'erreur,
        /// tant que la valeur n'est pas un nombre ou qu'elle est hors des limites.
        /// </summary>
        /// <param name="message">question affichée à l'utilisateur</param>
        /// <param name="min">valeur minimale acceptée</param>
        /// <param name="max">valeur maximale acceptée</param>
        /// <returns>entier saisi, compris entre min et max</returns>
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

        /// <summary>
        /// Programme principal : affiche le menu, puis réalise le calcul choisi
        /// (permutation, arrangement ou combinaison) jusqu'à ce que l'utilisateur quitte.
        /// </summary>
        /// <param name="args">arguments de la ligne de commande (non utilisés)</param>
        static void Main(string[] args)
        {
            int choix = 1;
            while (choix != QUITTER)
            {
                // affichage du menu et saisie du choix
                Console.WriteLine("Permutation ...................... " + PERMUTATION);
                Console.WriteLine("Arrangement ...................... " + ARRANGEMENT);
                Console.WriteLine("Combinaison ...................... " + COMBINAISON);
                Console.WriteLine("Quitter .......................... " + QUITTER);
                choix = Saisie("Choix", QUITTER, COMBINAISON);
                // saisie des valeurs et calcul selon le choix
                if (choix == PERMUTATION)
                {
                    int nbElements = Saisie("nombre total d'éléments à gérer", 0, VALEUR_MAX);
                    Console.WriteLine(nbElements + "! = " + ProduitSuite(1, nbElements));
                }
                else if (choix == ARRANGEMENT)
                {
                    int nbElements = Saisie("nombre total d'éléments à gérer", 0, VALEUR_MAX);
                    int sousEnsemble = Saisie("nombre d'éléments dans le sous ensemble", 0, nbElements);
                    Console.WriteLine("A(" + nbElements + "/" + sousEnsemble + ") = " + ProduitSuite(nbElements - sousEnsemble + 1, nbElements));
                }
                else if (choix == COMBINAISON)
                {
                    int nbElements = Saisie("nombre total d'éléments à gérer", 0, VALEUR_MAX);
                    int sousEnsemble = Saisie("nombre d'éléments dans le sous ensemble", 0, nbElements);
                    Console.WriteLine("C(" + nbElements + "/" + sousEnsemble + ") = " + (ProduitSuite(nbElements - sousEnsemble + 1, nbElements) / ProduitSuite(1, sousEnsemble)));
                }
            }
            Console.ReadLine();
        }
    }
}