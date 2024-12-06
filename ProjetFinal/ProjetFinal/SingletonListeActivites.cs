using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class SingletonListeActivites
    {
        public ObservableCollection<Activite> liste { get; set; }
        static SingletonListeActivites instance = null;

        private SingletonListeActivites() 
        {
            liste = new ObservableCollection<Activite>();
        }
        public static SingletonListeActivites GetInstance()
        {
            if (instance == null)
                instance = new SingletonListeActivites();

            return instance;
        }


        public ObservableCollection<Activite> GetListeActivite()
        {
            return liste;
        }
        public ObservableCollection<Activite> Liste
        {
            get { return liste; }
        }
        public Activite GetActivite(int position)
        {
            return liste[position];
        }

        public void Ajouter(Activite produit)
        {
            liste.Add(produit);
        }

        public void Modifier(int position, Activite produit)
        {
            liste[position] = produit;
        }
        public void Supprimer(int position)
        {
            liste.RemoveAt(position);
        }
    }
}
