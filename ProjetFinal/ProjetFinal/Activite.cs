using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Activite : INotifyPropertyChanged
    {
        string nom ="";
        string type ="";
        double coutOrganisation = 0;
        double prixVente = 0;


        public Activite() { }
        public Activite(string nom, string type, double coutOrganisation, double prixVente)
        {
            this.nom = nom;
            this.type = type;
            this.coutOrganisation = coutOrganisation;
            this.prixVente = prixVente;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Type
        {
            get { return type; }
            set {  type = value; }
        }

        public double CoutOrganisation
        {
            get { return coutOrganisation; }
            set { coutOrganisation = value; }
        }

        public double PrixVente
        {
            get { return prixVente; }
            set { prixVente = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public override string ToString()
        {
            return $"Nom: {Nom}, Type: {Type}, Cout d'organisation: {CoutOrganisation}, Prix de vente: {PrixVente}";
        }
    }
}
