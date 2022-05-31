using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compagnie_ATLANTIK
{
    public partial class FormAccueil : Form
    {
        public FormAccueil()
        {
            InitializeComponent();
        }

        private void FormAccueil_Load(object sender, EventArgs e)
        {
            
        }

        private void miAjouterSecteur_Click(object sender, EventArgs e)
        {
            FormAjouterSecteur formAjouterSecteur = new FormAjouterSecteur();
            formAjouterSecteur.ShowDialog();
        }

        private void miAjouterPort_Click(object sender, EventArgs e)
        {
            FormAjouterPort formAjouterPort = new FormAjouterPort();
            formAjouterPort.ShowDialog();
        }

        private void miAjouterLiaison_Click(object sender, EventArgs e)
        {
            FormAjouterLiaison formAjouterLiaison = new FormAjouterLiaison();
            formAjouterLiaison.ShowDialog();
        }

        private void miAjouterBateau_Click(object sender, EventArgs e)
        {
            FormAjouterBateau formAjouterBateau = new FormAjouterBateau();
            formAjouterBateau.ShowDialog();
        }

        private void miModifierParametres_Click(object sender, EventArgs e)
        {
            FormParametresSite formParametresSite = new FormParametresSite();
            formParametresSite.ShowDialog();
        }

        private void miAfficherReservation_Click(object sender, EventArgs e)
        {
            FormDetailReservation formDetailReservation = new FormDetailReservation();
            formDetailReservation.ShowDialog();
        }

        private void miAjouterTraversee_Click(object sender, EventArgs e)
        {
            FormAjouterTraversee formAjouterTraversee = new FormAjouterTraversee();
            formAjouterTraversee.ShowDialog();
        }

        private void miModifierBateau_Click(object sender, EventArgs e)
        {
            FormModifierBateau formModifierBateau = new FormModifierBateau();
            formModifierBateau.ShowDialog();
        }

        private void miAfficherTraversees_Click(object sender, EventArgs e)
        {
            FormTraverseesLiaison formTraverseesLiaison = new FormTraverseesLiaison();
            formTraverseesLiaison.ShowDialog();
        }

        private void miAjouterTarifs_Click(object sender, EventArgs e)
        {
            FormTarifsLiaison formTarifsLiaison = new FormTarifsLiaison();
            formTarifsLiaison.ShowDialog();
        }
    }
}
