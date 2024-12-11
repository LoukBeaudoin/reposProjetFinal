using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    public class Adherent : INotifyPropertyChanged
    {
        string noIdentification = "";
        string nom = "";
        string prenom = "";
        string adresse = "";
        DateTimeOffset dateNaissance;
        DateTime date = DateTime.Now;
        int age = 0;

        public Adherent() { }

        public Adherent(string nom, string prenom, string adresse, DateTimeOffset dateNaissance)
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

        public Adherent(string noIdentification)
        {
            this.noIdentification = noIdentification;
        }
        public Adherent(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public Adherent(string nom, string prenom, string noIdentification, string adresse, DateTimeOffset dateNaissance, int age)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.noIdentification = noIdentification;
            this.adresse = adresse;
            this.dateNaissance = dateNaissance;
            this.age = age;
        }
        public string noIdString(string nom, string prenom, DateTimeOffset dateNaissance)
        {
            string initiales = prenom.Substring(0, 1) + nom.Substring(0, 1);
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
            set
            {
                if (noIdentification != value)
                {
                    noIdentification = value;
                    OnPropertyChanged(nameof(noIdentification));
                }
            }
        }
        public string Nom
        {
            get { return nom; }
            set
            {
                if (nom != value)
                {
                    nom = value;
                    OnPropertyChanged(nameof(Nom));
                }
            }
        }
        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (prenom != value)
                {
                    prenom = value;
                    OnPropertyChanged(nameof(Prenom));

                }
            }
        }
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public DateTimeOffset DateNaissance
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

        public string StringCSV
        {
            get
            {
                return $"{noIdentification};{nom};{prenom};{adresse};{dateNaissance};{age}";
            }
        }

        public override string ToString()
        {
            return $"Num. d'identification : {noIdentification}, Nom : {nom}, Prénom : {prenom}, Adresse : {adresse}, Date de naissance : {dateNaissance}";
        }

        public static Adherent CurrentAdherent { get; set; }
    }
}
