using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    public class Activite : INotifyPropertyChanged
    {
        string nom ="";
        string type ="";
        double prixOrganisation = 0;
        double prixVente = 0;
        int noteEvaluation = 0;


        
        public Activite(string nom, string type, double coutOrganisation, double prixVente)
        {
            this.nom = nom;
            this.type = type;
            this.prixOrganisation = coutOrganisation;
            this.prixVente = prixVente;
        }

        public Activite(string nom, int noteEvaluation)
        {
            this.nom = nom;
            this.noteEvaluation = noteEvaluation;
        }

        public Activite(string nom, double coutOrganisation, double prixVente, int noteEvaluation)
        {
            this.nom = nom;
            this.prixOrganisation = coutOrganisation;
            this.prixVente = prixVente;
            this.noteEvaluation = noteEvaluation;
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

        public int NoteEvaluation
        {
            get { return noteEvaluation; }
            set 
            {
                if (noteEvaluation != value)
                {
                    noteEvaluation = value;
                    OnPropertyChanged(nameof(NoteEvaluation));
                }
                
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string StringCSV
        {
            get
            {
                return $"{nom};{prixOrganisation};{prixVente}";
            }
        }


        public override string ToString()
        {
            return $"Nom: {Nom}, Type: {Type}, Cout d'organisation: {PrixOrganisation}, Prix de vente: {PrixVente}";
        }
    }
}
