using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Adherent
    {
        string noIdentification="";
        string nom="";
        string prenom="";
        string adresse="";
        DateTime dateNaissance = DateTime.Now;
        DateTime date = DateTime.Now;

        public Adherent() { }

        public Adherent(string noIdentification, string nom, string prenom, string adresse, DateTime dateNaissance)
        {
            this.noIdentification = noIdString(nom, prenom, dateNaissance);
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.dateNaissance = dateNaissance;



           
            /*noIdentification = initiales + année naissance + randomint 3 chiffres 
        (AT-2003-152)*/
            //Min 18 ans
            //Pour chaque : enregistrer la liste des séances d’activité qu’il participe
        }

        public string noIdString(string nom, string prenom, DateTime dateNaissance)
        {
            string initiales = prenom.Substring(0,1) + nom.Substring(0,1);
            int annéeNaissance = dateNaissance.Year;
            Random random = new Random();
            int randomDigits = random.Next(1, 1000);
            string formattedRandom = randomDigits.ToString("D3");

            return $"{initiales}-{annéeNaissance}-{formattedRandom}";
        }

        public double calculAge() 
        {
            TimeSpan nbJours = date - dateNaissance;
            double age = (nbJours.Days) / 365.25;
            return age; 
        }


        public string NoIdentification
        {
            get { return noIdentification; }
            set { noIdentification = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public DateTime DateNaissance
        {
            get { return dateNaissance; }
            set { dateNaissance = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string WriteCsv()
        {
            return $"{noIdentification};{nom};{prenom};{adresse};{dateNaissance}";
        }

        public override string ToString()
        {
            return $"Num. d'identification : {noIdentification}, Nom : {nom}, Prénom : {prenom}, Adresse : {adresse}, Date de naissance : {dateNaissance}";
        }
    }
}
