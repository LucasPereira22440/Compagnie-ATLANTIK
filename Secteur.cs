using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compagnie_ATLANTIK
{
    class Secteur
    {
        private int nosecteur;
        private string nom;

        public Secteur(int nosecteur, string nom)
        {
            this.nosecteur = nosecteur;
            this.nom = nom;
        }

        public int GetNoSecteur()
        {
            return nosecteur;
        }

        public string GetNom()
        {
            return nom;
        }

        public override string ToString()
        {
            // Ce qui va s'afficher dans la ListBox
            return nom;
        }
    }
}
