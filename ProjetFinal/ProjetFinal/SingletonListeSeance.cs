using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class SingletonListeSeance
    {
        public ObservableCollection<Seance> liste { get; set; }
        static SingletonListeSeance instance = null;

        private SingletonListeSeance()
        {
            liste = new ObservableCollection<Seance>();
        }
        public static SingletonListeSeance GetInstance()
        {
            if (instance == null)
                instance = new SingletonListeSeance();

            return instance;
        }


        public ObservableCollection<Seance> GetListeSeance()
        {
            return liste;
        }
        public ObservableCollection<Seance> Liste
        {
            get { return liste; }
        }
        public Seance GetActivite(int position)
        {
            return liste[position];
        }

        public void Ajouter(Seance produit)
        {
            liste.Add(produit);
        }

        public void Modifier(int position, Seance produit)
        {
            liste[position] = produit;
        }
        public void Supprimer(int position)
        {
            liste.RemoveAt(position);
        }
    }
}
