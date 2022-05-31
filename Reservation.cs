using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compagnie_ATLANTIK
{
    class Reservation
    {
        private int noreservation;
        private int notraversee;
        private int noclient;
        private DateTime dateheure;
        private double montanttotal;
        private bool paye;
        private string modereglement;

        public Reservation(int noreservation, int notraversee, int noclient, DateTime dateheure, double montanttotal, bool paye, string modereglement)
        {
            this.noreservation = noreservation;
            this.notraversee = notraversee;
            this.noclient = noclient;
            this.dateheure = dateheure;
            this.montanttotal = montanttotal;
            this.paye = paye;
            this.modereglement = modereglement;
        }

        public int GetNoReservation()
        {
            return noreservation;
        }

        public int GetNoTraversee()
        {
            return notraversee;
        }

        public int GetNoClient()
        {
            return noclient;
        }

        public DateTime GetDateHeure()
        {
            return dateheure;
        }

        public double GetMontantTotal()
        {
            return montanttotal;
        }

        public bool GetPaye()
        {
            return paye;
        }

        public string GetModeReglement()
        {
            return modereglement;
        }
    }
}
