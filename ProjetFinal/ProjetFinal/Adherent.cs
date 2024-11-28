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
        int noIdentification=0;
        string nom="";
        string prenom="";
        string adresse="";
        DateTime dateNaissance = DateTime.Now;

        public Adherent() { }

        public Adherent(int noIdentification, string nom, string prenom, string adresse, DateTime dateNaissance)
        {
            this.noIdentification = noIdentification;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.dateNaissance = dateNaissance;



            //Avec la date : Calculer l’age de la personne.
            /*noIdentification = initiales + année naissance + randomint 3 chiffres 
        (AT-2003-152)*/
            //Min 18 ans
            //Pour chaque : enregistrer la liste des séances d’activité qu’il participe
        }

        public int NoIdentification
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
