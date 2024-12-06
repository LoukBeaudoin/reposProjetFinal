using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Seance
    {

        DateTime date;
        string heure = "";
        int nbPlaces = 0;
        double note=0;

        public Seance() { }

        public Seance(DateTime date, string heure, int nbPlaces, double note)
        {
            this.date = date;
            this.heure = heure;
            this.nbPlaces = nbPlaces;
            this.note = note;
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Heure
        {
            get { return heure; }
            set { heure = value; }
        }

        public int NbPlaces
        {
            get { return nbPlaces; }
            set { nbPlaces = value; }
        }

        public double Note
        {
            get { return note; }
            set { note = value; }
        }

        public override string ToString()
        {
            return $"Date: {Date}, Heure: {Heure}, Nb de places: {NbPlaces}, Note(/5): {Note}";
        }

    }
}
