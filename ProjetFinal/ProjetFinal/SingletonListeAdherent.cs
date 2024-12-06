using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class SingletonListeAdherent
    {
        public ObservableCollection<Adherent> liste { get; set; }
        static SingletonListeAdherent instance = null;

        private SingletonListeAdherent()
        {
            liste = new ObservableCollection<Adherent>();
        }
        public static SingletonListeAdherent GetInstance()
        {
            if (instance == null)
                instance = new SingletonListeAdherent();

            return instance;
        }


        public ObservableCollection<Adherent> GetListeActivite()
        {
            return liste;
        }
        public ObservableCollection<Adherent> Liste
        {
            get { return liste; }
        }
        public Adherent GetActivite(int position)
        {
            return liste[position];
        }

        public void Ajouter(Adherent produit)
        {
            liste.Add(produit);
        }

        public void Modifier(int position, Adherent produit)
        {
            liste[position] = produit;
        }
        public void Supprimer(int position)
        {
            liste.RemoveAt(position);
        }
    }
}
