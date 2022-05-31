using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compagnie_ATLANTIK
{
    class Bateau
    {
        private int noBateau;
        private string nom;

        public Bateau(string nom, int noBateau)
        {
            this.noBateau = noBateau;
            this.nom = nom;
        }

        public int GetNoBateau()
        {
            return noBateau;
        }
        public string GetNomBateau()
        {
            return nom;
        }

        public override string ToString()
        {
            return nom;
        }
    }
}
