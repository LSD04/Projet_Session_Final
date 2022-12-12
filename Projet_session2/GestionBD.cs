using Microsoft.UI.Xaml.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Google.Protobuf.Collections;

namespace Projet_session2
{
   
    internal class GestionBD
    {
        internal static ObservableCollection<string> choixVille = new ObservableCollection<string>()
        {
        "Louiseville", "Trois-Rivières","Bastican"
        };

        private MySqlConnection con;
        ObservableCollection<SPT> tableSPT;
        ObservableCollection<Trajet> tableTrajet;
        ObservableCollection<Voiture> tableVoiture;
        ObservableCollection<TP> tableTP;
        ObservableCollection<User> tableUser;
        static GestionBD gestionBD = null;
        Frame mainFrame;

        int id;
        string nom, prenom, categorie;
        bool connnecte = false;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom;  }
        public string Prenom { get => prenom;  }
        public bool Connnecte { get => connnecte;  }
        public Frame MainFrame { get => mainFrame; }
        public string Categorie { get => categorie; }

        public GestionBD()
        {
            //this.con = new MySqlConnection("Server=cours.ceget3r.info;Database=session;Uid=2140149;Pwd=2140149;");
            this.con = new MySqlConnection("Server=localhost;Database=covoiturage;Uid=root;Pwd=root");
            tableSPT = new ObservableCollection<SPT>();
            tableTrajet = new ObservableCollection<Trajet>();
            tableVoiture = new ObservableCollection<Voiture>();
            tableTP = new ObservableCollection<TP>();
            tableUser = new ObservableCollection<User>();
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        //Connexion
        public bool IsValid(string username, string password)
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            con.Open();
            commande.CommandText = "SELECT id, nom, prenom, categorie FROM user WHERE courriel = @username AND motDePasse = @password;";
            commande.Parameters.AddWithValue("@username", username);
            commande.Parameters.AddWithValue("@password", password);

            MySqlDataReader r = commande.ExecuteReader();

            if (r.Read())
            {
                nom = r[1].ToString();
                categorie = r[3].ToString();
                connnecte = true;
                con.Close();
                
                return true;
            }
            else
            {
                connnecte = false;
                con.Close();
                return false;
            }



        }

        //Afficher les données de la table trajet

        public ObservableCollection<Trajet> getTrajet()
        {
            tableTrajet.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from trajet where date >= curdate()";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                Trajet c = new Trajet()
                {
                    NoTrajet = r.GetInt32("noTrajet"),
                    HeureDepart = r.GetString("heureDepart"),
                    HeureArrivee = r.GetString("heureArrivee"),
                    VilleDepart = r.GetString("villeDepart"),
                    VilleArrivee = r.GetString("villeArrivee"),
                    Date = r.GetString("date"),
                    Arret = r.GetString("arret"),
                    Montant = r.GetInt32("montant"),
                    Vehicule = r.GetString("vehicule"),
                    NbrPlace = r.GetInt32("nbrPlace")
                };
                tableTrajet.Add(c);
            }
            r.Close();
            con.Close();

            return tableTrajet;
        }

        //Historique
        public ObservableCollection<Trajet> historique()
        {
            tableTrajet.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from trajet where date < curdate()";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                Trajet c = new Trajet()
                {
                    NoTrajet = r.GetInt32("noTrajet"),
                    HeureDepart = r.GetString("heureDepart"),
                    HeureArrivee = r.GetString("heureArrivee"),
                    VilleDepart = r.GetString("villeDepart"),
                    VilleArrivee = r.GetString("villeArrivee"),
                    Date = r.GetString("date"),
                    Arret = r.GetString("arret"),
                    Montant = r.GetInt32("montant"),
                    Vehicule = r.GetString("vehicule"),
                    NbrPlace = r.GetInt32("nbrPlace")
                };
                tableTrajet.Add(c);
            }
            r.Close();
            con.Close();

            return tableTrajet;
        }

        //Creer un trajet

        public void ajouter_trajet(Trajet p)
        {
            int noTrajet = p.NoTrajet;
            string heureDepart = p.HeureDepart; 
            string heureArrivee = p.HeureArrivee;
            string villeDepart = p.VilleDepart;
            string villeArrivee = p.VilleArrivee;
            string date = p.Date;
            string arret = p.Arret;
            int montant = p.Montant;
            string vehicule = p.Vehicule;
            int nbrPlace = p.NbrPlace;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Insert into trajet (heureDepart, heureArrivee, villeDepart, villeArrivee, date, arret, montant, vehicule, nbrPlace) values (@heuredepart,@heureArrivee, @villeDepart,@villeArrivee,@date, @arret,@montant,@vehicule,@nbrPlace)";
                commande.Parameters.AddWithValue("@noTrajet", noTrajet);
                commande.Parameters.AddWithValue("@heureDepart", heureDepart);
                commande.Parameters.AddWithValue("@heureArrivee", heureArrivee);
                commande.Parameters.AddWithValue("@villeDepart", villeDepart);
                commande.Parameters.AddWithValue("@villeArrivee", villeArrivee);
                commande.Parameters.AddWithValue("@date", date);
                commande.Parameters.AddWithValue("@arret", arret);
                commande.Parameters.AddWithValue("@montant", montant);
                commande.Parameters.AddWithValue("@vehicule", vehicule);
                commande.Parameters.AddWithValue("@nbrPlace", nbrPlace);


                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

        // Ajouter villes admin

        public ObservableCollection<string> AfficherVille()
        {
            return choixVille;
        }

        public ObservableCollection<string> AjouterVille(string ville)
        {
            choixVille.Add(ville);
            return choixVille;
        }


        //creer un compte
        public void insererUser(User c)
        {
            string categorie = c.Categorie;
            string nom = c.Nom;
            string prenom = c.Prenom;
            string courriel = c.Courriel;
            string motDePasse = c.MotDePasse;
            string noTelephone = c.NoTelephone;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into user (categorie, nom, prenom, courriel, motDePasse, noTelephone) values(@categorie, @nom, @prenom, @courriel, @motDePasse, @noTelephone) ";

                commande.Parameters.AddWithValue("@categorie", categorie);
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);
                commande.Parameters.AddWithValue("@courriel", courriel);
                commande.Parameters.AddWithValue("@motDePasse", motDePasse);
                commande.Parameters.AddWithValue("@noTelephone", noTelephone);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        //Rechercher un trajet selon la période
        public ObservableCollection<Trajet> rechercher_Projet(String date1, String date2)
        {
            try
            {
                tableTrajet.Clear();



                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from trajet where date between '" + date1 + "' and '" + date2 +"'" ;



                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {

                    tableTrajet.Add(new Trajet()
                    {
                        NoTrajet = r.GetInt32("noTrajet"),
                        HeureDepart = r.GetString("heureDepart"),
                        HeureArrivee = r.GetString("heureArrivee"),
                        VilleDepart = r.GetString("villeDepart"),
                        VilleArrivee = r.GetString("villeArrivee"),
                        Date = r.GetString("date"),
                        Arret = r.GetString("arret"),
                        Montant = r.GetInt32("montant"),
                        Vehicule = r.GetString("vehicule"),
                        NbrPlace = r.GetInt32("nbrPlace")
                    });

                }

                r.Close();
                con.Close();
                return tableTrajet;

            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                return null;
            }

        }

        public ObservableCollection<Trajet> rechercheT(String debut, String heure)
        {
            try
            {
                tableTrajet.Clear();

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "Select * from trajet Where date = '" + debut + "' and heureArrivee = '" + heure + "' ";

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {

                    Trajet c = new Trajet()
                    {
                        NoTrajet = r.GetInt32("noTrajet"),
                        HeureDepart = r.GetString("heureDepart"),
                        HeureArrivee = r.GetString("heureArrivee"),
                        VilleDepart = r.GetString("villeDepart"),
                        VilleArrivee = r.GetString("villeArrivee"),
                        Date = r.GetString("date"),
                        Arret = r.GetString("arret"),
                        Montant = r.GetInt32("montant"),
                        Vehicule = r.GetString("vehicule"),
                    };
                    tableTrajet.Add(c);
                }
                r.Close();
                con.Close();

                return tableTrajet;
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                return null;
            }


        }

    }
}
