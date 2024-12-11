using MySql.Data.MySqlClient;
using Mysqlx.Expr;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;

namespace ProjetFinal
{
    class SingletonBD
    {
        ObservableCollection<Activite> liste;
        ObservableCollection<Adherent> listeAdherent;
        MySqlConnection con;
        static SingletonBD instance = null;
        int idActivite = 15;
        int idSeances = 15;

        public ObservableCollection<Activite> Liste { get => liste; }
        public ObservableCollection<Adherent> ListeAdherent { get => listeAdherent; }
        public SingletonBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2024_420335ri_eq3;Uid=2387284;Pwd=2387284;");
            liste = new ObservableCollection<Activite>();
            listeAdherent = new ObservableCollection<Adherent>();
        }

        public static SingletonBD getInstance()
        {
            if (instance == null)
                instance = new SingletonBD();

            return instance;
        }

        public void getActiviteAccueil()
        {
            //liste.Clear();


            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT nom,coutOrganisation,prixDeVente, ROUND(AVG(noteAppreciation)) as moyenne FROM inscription\r\nINNER JOIN a2024_420335ri_eq3.seances s on inscription.idSeance = s.idSeances\r\nINNER JOIN a2024_420335ri_eq3.activites a on s.idActivite = a.idActivite\r\nGROUP BY nom;";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                string nom = r["nom"].ToString();
                double coutOrganisation = Convert.ToDouble(r["coutOrganisation"]);
                double prixDeVente = Convert.ToDouble(r["prixDeVente"]);
                int noteEvaluation = Convert.ToInt32(r["moyenne"]);

                Activite texte = new Activite(nom,coutOrganisation,prixDeVente, noteEvaluation);

                liste.Add(texte);
            }


            r.Close();
            con.Close();


        }

        //Liste adherent Page accueil
        public void getAdherentAccueil()
        {
            //liste.Clear();


            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT nom, prenom,noIdentification,adresse,dateNaissance,age FROM adherents";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                string nom = r["nom"].ToString();
                string prenom = r["prenom"].ToString();
                string noIdentification = r["noIdentification"].ToString();
                string adresse = r["adresse"].ToString();
                string dateNaissance = r["dateNaissance"].ToString();
                DateTimeOffset dateNaissanceFinal = Convert.ToDateTime(dateNaissance);
                int age = Convert.ToInt32(r["age"]);

                Adherent texte = new Adherent(nom, prenom, noIdentification, adresse, dateNaissanceFinal, age);

                listeAdherent.Add(texte);
            }


            r.Close();
            con.Close();


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

        //Authentification administrateur
        public bool Connexion(string Nom, string Mdp) 
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            con.Open();
            commande.CommandText = "SELECT * FROM administrateurs where nomUtilisateur = @Nom AND motDePasse = @Mdp";
            commande.Parameters.AddWithValue("@Nom",Nom);
            commande.Parameters.AddWithValue("@Mdp", Mdp);
            MySqlDataReader r = commande.ExecuteReader();
            Boolean authentification = false;
            if (r.Read() == true)
            {
                authentification = true;
            }
            else
            {
                authentification = false;
            }

            r.Close();
            con.Close();
            return authentification;
        }


        //Identifiant Connecter
        public string getIdentifiantSession(string Identifiant)
        {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                con.Open();
                commande.CommandText = "SELECT noIdentification FROM adherents where noIdentification = @Identifiant";
                commande.Parameters.AddWithValue("@Identifiant", Identifiant);
                MySqlDataReader r = commande.ExecuteReader();
                string ididentifiant = "";
                if (r.Read() == true)
                {
                    ididentifiant = r["noIdentification"].ToString();
                }

                r.Close();
                con.Close();
            return ididentifiant;

        }

        //Ajouter Activite
        public void AjouterActivite(string nom,double coutOrganisation, double prixdeVente,int idAdmin,int idCategorie )
        {
            int coutOrganisationInt = Convert.ToInt32(coutOrganisation);
            int prixDeVenteInt = Convert.ToInt32(prixdeVente);
            ++idActivite;

            MySqlCommand commandeInsert = new MySqlCommand();
            commandeInsert.Connection = con;
            commandeInsert.CommandText = "insert into activites(idActivite,nom,coutOrganisation,prixDeVente,IdAdmin,IdCategorie) values(@idActivite,@nom, @coutOrganisation, @prixDeVente,@idAdmin,@idCategorie) ";
            commandeInsert.Parameters.AddWithValue("@idActivite", idActivite);
            commandeInsert.Parameters.AddWithValue("@nom", nom);
            commandeInsert.Parameters.AddWithValue("@coutOrganisation", coutOrganisationInt);
            commandeInsert.Parameters.AddWithValue("@prixDeVente", prixDeVenteInt);
            commandeInsert.Parameters.AddWithValue("@idAdmin", idAdmin);
            commandeInsert.Parameters.AddWithValue("@idCategorie", idCategorie);

            con.Open();
            commandeInsert.ExecuteNonQuery();

            con.Close();

        }


        //Ajout adherent
        public void AjouterAdherent(string nom, string prenom, string adresse, DateTime dateNaissance, double age,int idAdmin)
        {

            
            int ageInt = Convert.ToInt32(Math.Round(age));
            MySqlCommand commandeInsert = new MySqlCommand();
            commandeInsert.Connection = con;
            commandeInsert.CommandText = "insert into adherents(nom,prenom,adresse,dateNaissance,age,idAdmin) values(@nom, @prenom, @adresse,@dateNaissance,@age,@idAdmin) ";
            commandeInsert.Parameters.AddWithValue("@nom", nom);
            commandeInsert.Parameters.AddWithValue("@prenom", prenom);
            commandeInsert.Parameters.AddWithValue("@adresse", adresse);
            commandeInsert.Parameters.AddWithValue("@dateNaissance", dateNaissance);
            commandeInsert.Parameters.AddWithValue("@age", ageInt);
            commandeInsert.Parameters.AddWithValue("@idAdmin", idAdmin);

            con.Open();
            commandeInsert.ExecuteNonQuery();

            con.Close();

        }


        public void AjouterSeance(DateTime dateOrganisation,int nbPlaceDispo,int idActivite)
        {

            ++idSeances;
            MySqlCommand commandeInsert = new MySqlCommand();
            commandeInsert.Connection = con;
            commandeInsert.CommandText = "insert into seances(idSeances,dateOrganisation,nbPlaceDispo,idActivite) values(@idSeances, @dateOrganisation, @nbPlaceDispo, @idActivite) ";
            commandeInsert.Parameters.AddWithValue("@idSeances", idSeances);
            commandeInsert.Parameters.AddWithValue("@dateOrganisation", dateOrganisation);
            commandeInsert.Parameters.AddWithValue("@nbPlaceDispo", nbPlaceDispo);
            commandeInsert.Parameters.AddWithValue("@idActivite", idActivite);


            con.Open();
            commandeInsert.ExecuteNonQuery();

            con.Close();

        }


    }
}
