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
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2024_420335ri_eq3;Uid=2387284;Pwd=2387284;");
            //liste = new ObservableCollection<ObjetProduit>();
        }

        public static SingletonBD getInstance()
        {
            if (instance == null)
                instance = new SingletonBD();

            return instance;
        }
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

        //Nombre total d'adhérent
        public int getTotalAdherent()
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT count(noIdentification) as total from adherents";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            int totalAdherent = 0;
            if (r.Read())
            {
                totalAdherent = Convert.ToInt32(r["total"].ToString());

            }

            r.Close();
            con.Close();
            return totalAdherent;

        }

        //Nombre total d'activité
        public int getTotalActivite()
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT count(nom) as total from activites";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            int totalActivite = 0;
            if (r.Read())
            {
                totalActivite = Convert.ToInt32(r["total"].ToString());

            }

            r.Close();
            con.Close();
            return totalActivite;
         
        }


        //Nombre d'adhérents par activités(séance)
        public Dictionary<string, int> getNbAdherentActivite()
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            //commande.CommandText = "SELECT nom, COUNT(*) as total FROM adherent GROUP BY activite";
            commande.CommandText = "select a.nom,count(*) as total from seances\r\nINNER JOIN a2024_420335ri_eq3.activites a on seances.idActivite = a.idActivite\r\ngroup by seances.idActivite";
            Dictionary<string, int> adherentActivite = new Dictionary<string, int>();
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                string activites = r["nom"].ToString();
                int totalAdherent = Convert.ToInt32(r["total"].ToString());
                adherentActivite[activites] = totalAdherent;
            }

            r.Close();
            con.Close();
            return adherentActivite;

        }


        //L'adhérent avec le plus de séance
        public string getAdherentMaxSeance()
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT\r\nnoIdentificationAdherent\r\nFROM inscription\r\nGROUP BY noIdentificationAdherent\r\nORDER BY COUNT(*) DESC\r\nLIMIT 1";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            string noId = "";
            if (r.Read())
            {
                noId = r["noIdentificationAdherent"].ToString();

            }

            r.Close();
            con.Close();
            return noId;

        }

        //Age Moyen des Adhérents
        public int getAgeMoyenAdherent()
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT ROUND(AVG(age)) as moyenne FROM adherents";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            int ageMoyen = 0;
            if (r.Read())
            {
                ageMoyen = Convert.ToInt32(r["moyenne"].ToString());

            }

            r.Close();
            con.Close();
            return ageMoyen;

        }

        //Note Moyenne Activité
        public Dictionary<string, int> getNoteMoyenneActivites()
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT nom, ROUND(AVG(noteAppreciation)) as moyenne FROM inscription\r\nINNER JOIN a2024_420335ri_eq3.seances s on inscription.idSeance = s.idSeances\r\nINNER JOIN a2024_420335ri_eq3.activites a on s.idActivite = a.idActivite\r\nGROUP BY nom";
            Dictionary<string, int> activiteNote = new Dictionary<string, int>();
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                string activites = r["nom"].ToString();
                int noteMoyenne = Convert.ToInt32(r["moyenne"].ToString());
                activiteNote[activites] = noteMoyenne;
            }

            r.Close();
            con.Close();
            return activiteNote;

        }

        //Total inscription
        public int getTotalInscription()
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT COUNT(noIdentificationAdherent) AS total FROM inscription";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            int totalInscription = 0;
            if (r.Read())
            {
                totalInscription = Convert.ToInt32(r["total"].ToString());

            }

            r.Close();
            con.Close();
            return totalInscription;

        }


    }
}
