using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_session2
{
    internal class User
    {

        int id;
        string categorie;
        string nom;
        string prenom;
        string courriel;
        string motDePasse;
        string noTelephone;

        public int Id { get => id; set => id = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Courriel { get => courriel; set => courriel = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
        public string NoTelephone { get => noTelephone; set => noTelephone = value; }

        public override string ToString()
        {
            return id + " " + nom + " " + prenom + " " + courriel + " " + motDePasse + " " + noTelephone;
        }
    }
}
