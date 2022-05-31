using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compagnie_ATLANTIK
{
    class Liaison
    {
        private string nomportdepart;
        private string nomportarrivee;
        private int noliaison;
        private int nosecteur;
        private int noport_depart;
        private int noport_arrivee;
        private double distance;

        public Liaison(string nomportdepart, string nomportarrivee, int noliaison, int nosecteur, int noport_depart, int noport_arrivee, double distance)
        {
            this.nomportdepart = nomportdepart;
            this.nomportarrivee = nomportarrivee;
            this.noliaison = noliaison;
            this.nosecteur = nosecteur;
            this.noport_depart = noport_depart;
            this.noport_arrivee = noport_arrivee;
            this.distance = distance;
        }

        public string GetNomPortDepart()
        {
            return nomportdepart;
        }

        public string GetNomPortArrivee()
        {
            return nomportarrivee;
        }
        public int GetNoLiaison()
        {
            return noliaison;
        }

        public int GetNoSecteur()
        {
            return nosecteur;
        }

        public int GetNoPortDepart()
        {
            return noport_depart;
        }

        public int GetNoPortArrivee()
        {
            return noport_arrivee;
        }

        public double GetDistance()
        {
            return distance;
        }

        public override string ToString()
        {
            return nomportdepart + " - " + nomportarrivee;
        }
    }
}
