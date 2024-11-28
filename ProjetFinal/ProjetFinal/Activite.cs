using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class Activite
    {
        string nom ="";
        string type ="S";


        public Activite() { }
        public Activite(string nom, string type) 
        {
            this.nom = nom;
            this.type = type;

        }
    }
}
