using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compagnie_ATLANTIK
{
    class Client
    {
        private int noclient;
        private string nom;
        private string prenom;
        private string adresse;
        private int codepostal;
        private string ville;
        private string telephonefixe;
        private string telephonemobile;
        private string mel;
        private string motdepasse;

        public Client(int noclient, string nom, string prenom, string adresse, int codepostal, string ville, string telephonefixe, string telephonemobile, string mel, string motdepasse)
        {
            this.noclient = noclient;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.codepostal = codepostal;
            this.ville = ville;
            this.telephonefixe = telephonefixe;
            this.telephonemobile = telephonemobile;
            this.mel = mel;
            this.motdepasse = motdepasse;
        }

        public int GetNoClient()
        {
            return noclient;
        }

        public string GetNom()
        {
            return nom;
        }

        public string GetPrenom()
        {
            return prenom;
        }

        public string GetAdresse()
        {
            return adresse;
        }

        public int GetCodePostal()
        {
            return codepostal;        
        }

        public string GetVille()
        {
            return ville;
        }

        public string GetTelephoneFixe()
        {
            return telephonefixe;
        }

        public string GetMel()
        {
            return mel;        
        }

        public string GetMotDePasse()
        {
            return motdepasse;
        }

        public override string ToString()
        {
            return nom + ", " + prenom;
        }
    }
}
