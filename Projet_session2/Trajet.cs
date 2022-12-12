using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_session2
{
    internal class Trajet
    {
        int noTrajet;
        string heureDepart;
        string heureArrivee;
        string villeDepart;
        string villeArrivee;
        string date;
        string arret;
        int montant;
        string vehicule;
        int nbrPlace;

        public int NoTrajet { get => noTrajet; set => noTrajet = value; }
        public string HeureDepart { get => heureDepart; set => heureDepart = value; }
        public string HeureArrivee { get => heureArrivee; set => heureArrivee = value; }
        public string VilleDepart { get => villeDepart; set => villeDepart = value; }
        public string VilleArrivee { get => villeArrivee; set => villeArrivee = value; }
        public string Date { get => date; set => date = value; }
        public string Arret { get => arret; set => arret = value; }
        public int Montant { get => montant; set => montant = value; }
        public string Vehicule { get => vehicule; set => vehicule = value; }
        public int NbrPlace { get => nbrPlace; set => nbrPlace = value; }

        public override string ToString()
        {
            return noTrajet + " "
                + heureDepart + " "
                + heureArrivee + " "
                + villeDepart + " "
                + villeArrivee + " "
                + date + " "
                + arret + " " + montant +" "+vehicule+ " "+ nbrPlace;
        }
    }
}
