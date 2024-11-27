using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;

namespace ProjetFinal
{
    class SingletonBD
    {
        MySqlConnection con;
        static SingletonBD instance = null;
        public SingletonBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=420345ri_gr00002_2387284-louka-beaudoin;Uid=2387284;Pwd=2387284;");
            //liste = new ObservableCollection<ObjetProduit>();
        }

        public static SingletonBD getInstance()
        {
            if (instance == null)
                instance = new SingletonBD();

            return instance;
        }

        //va avoir besoin de un pour administrateur parcourir la bd et regarder si est dedans 

        //Get activité reste a modifier avec casse et colonne
        public void getActivite()
        {
            //liste.Clear();


            //MySqlCommand commande = new MySqlCommand();
            //commande.Connection = con;
            //commande.CommandText = "Select * from produits";
            //con.Open();
            //MySqlDataReader r = commande.ExecuteReader();

            //while (r.Read())
            //{
            //    string nom = r["nom"].ToString();
            //    double prix = Convert.ToDouble(r["prix"]);
            //    string categorie = r["categorie"].ToString();

            //    ObjetProduit texte = new ObjetProduit(nom, prix, categorie);

            //    liste.Add(texte);
            //}


            //r.Close();
            //con.Close();


        }

        //Get seance reste a modifier avec lcasse et colonne
        public void getSeances()
        {
            //liste.Clear();


            //MySqlCommand commande = new MySqlCommand();
            //commande.Connection = con;
            //commande.CommandText = "Select * from produits";
            //con.Open();
            //MySqlDataReader r = commande.ExecuteReader();

            //while (r.Read())
            //{
            //    string nom = r["nom"].ToString();
            //    double prix = Convert.ToDouble(r["prix"]);
            //    string categorie = r["categorie"].ToString();

            //    ObjetProduit texte = new ObjetProduit(nom, prix, categorie);

            //    liste.Add(texte);
            //}


            //r.Close();
            //con.Close();


        }

        //get total d'adhérent juste besoin de modifier pour adherent
        public int getTotalAdherent()
        {
            //MySqlCommand commande = new MySqlCommand();
            //commande.Connection = con;
            //commande.CommandText = "SELECT count(nom) as total from produits";
            //con.Open();
            //MySqlDataReader r = commande.ExecuteReader();
            //int totalproduit = 0;
            //if (r.Read())
            //{
            //    totalproduit = Convert.ToInt32(r["total"].ToString());

            //}

            //r.Close();
            //con.Close();
            //return totalproduit;
            return 1;


        }

        //get total d'activité juste besoin de modifier pour activite
        public int getTotalActivite()
        {
            //MySqlCommand commande = new MySqlCommand();
            //commande.Connection = con;
            //commande.CommandText = "SELECT count(nom) as total from produits";
            //con.Open();
            //MySqlDataReader r = commande.ExecuteReader();
            //int totalproduit = 0;
            //if (r.Read())
            //{
            //    totalproduit = Convert.ToInt32(r["total"].ToString());

            //}

            //r.Close();
            //con.Close();
            //return totalproduit;
            return 1;
            


        }


        //reste juste a modifier pour adherent et activite la ses produit et categorie
        public Dictionary<string, int> getNbAdherentActivite()
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT categorie, COUNT(*) as total FROM produits GROUP BY categorie";
            Dictionary<string, int> produitCategorie = new Dictionary<string, int>();
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                string categorie = r["categorie"].ToString();
                int totalproduit = Convert.ToInt32(r["total"].ToString());
                produitCategorie[categorie] = totalproduit;
            }

            r.Close();
            con.Close();
            return produitCategorie;

        }



    }
}
