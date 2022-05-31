using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compagnie_ATLANTIK
{
    class Periode
    {
        private int noperiode;
        private string datedebut;
        private string datefin;

        public Periode(int noperiode, string datedebut, string datefin)
        {
            this.noperiode = noperiode;
            this.datedebut = datedebut;
            this.datefin = datefin;
        }

        public int GetNoPeriode()
        {
            return noperiode;
        }

        public string GetDateDebut()
        {
            return datedebut;
        }

        public string GetDateFin()
        {
            return datefin;
        }

        public override string ToString()
        {
            return datedebut + " au " + datefin;
        }
    }
}
