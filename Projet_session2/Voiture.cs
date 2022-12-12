using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_session2
{
    internal class Voiture
    {
        string immatriculation;
        string marque;
        string couleur;
        int nbPassagers;

        public string Immatriculation { get => immatriculation; set => immatriculation = value; }
        public string Marque { get => marque; set => marque = value; }
        public string Couleur { get => couleur; set => couleur = value; }
        public int NbPassagers { get => nbPassagers; set => nbPassagers = value; }


        public override string ToString()
        {
            return immatriculation + "\n"
                    + marque + "\n"
                    + couleur + "\n"
                    + nbPassagers;
        }
    }
}
