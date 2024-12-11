using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{

    internal class Authentification : INotifyPropertyChanged
    {

        private static Authentification instance = null;

        public static Authentification getInstance()
        {
            if (instance == null)
                instance = new Authentification();

            return instance;
        }

        public bool _connecter;
        public bool _session;
        public bool Connecter 
        {
            get { return _connecter; } 
            set
            {
                if (_connecter != value)
                {
                    _connecter = value;
                    OnPropertyChanged(nameof(Connecter));
                }
            }


        }

        private Authentification()
        {
            Connecter = false;
        }

        public bool Session
        {
            get { return _session; }
            set
            {
                if (_session != value)
                {
                    _session = value;
                    OnPropertyChanged(nameof(Session));
                }
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
