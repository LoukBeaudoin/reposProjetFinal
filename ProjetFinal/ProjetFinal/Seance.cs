using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Seance
    {

        DateTimeOffset date;
        TimeSpan heure;
        int nbPlaces = 0;
        int note=0;

        public Seance() { }

        public Seance(DateTimeOffset date, TimeSpan heure, int nbPlaces, int note)
        {
            this.date = date;
            this.heure = heure;
            this.nbPlaces = nbPlaces;
            this.note = note;
        }

        public DateTimeOffset Date
        {
            get { return date; }
            set { date = value; }
        }
        public TimeSpan Heure
        {
            get { return heure; }
            set { heure = value; }
        }

        public int NbPlaces
        {
            get { return nbPlaces; }
            set { nbPlaces = value; }
        }

        public int Note
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
