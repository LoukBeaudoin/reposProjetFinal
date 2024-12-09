﻿using System;
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
        double prixOrganisation = 0;
        double prixVente = 0;


        public Activite() { }
        public Activite(string nom, string type, double coutOrganisation, double prixVente)
        {
            this.nom = nom;
            this.type = type;
            this.prixOrganisation = coutOrganisation;
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

        public double PrixOrganisation
        {
            get { return prixOrganisation; }
            set { prixOrganisation = value; }
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
            return $"Nom: {Nom}, Type: {Type}, Cout d'organisation: {PrixOrganisation}, Prix de vente: {PrixVente}";
        }
    }
}
