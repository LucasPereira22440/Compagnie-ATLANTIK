using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Compagnie_ATLANTIK
{
    public partial class FormAjouterLiaison : Form
    {
        public FormAjouterLiaison()
        {
            InitializeComponent();
        }

        private void lbxSecteurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FormAjouterLiaison_Load(object sender, EventArgs e)
        {
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requete;
                maCnx.Open();

                requete = "SELECT nom FROM secteur";

                var maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();
                while (jeuEnr.Read())
                {
                    lbxSecteurs.Items.Add(jeuEnr["nom"] + "\t");
                }
            }
            catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (lbxSecteurs.Text == "" | cmbDepart.Text == "" | cmbArrivee.Text == "")
            {
                MessageBox.Show("Assurez-vous d'avoir remplie les champs suivant : Secteurs, Départ, Arrivée.", "Avertissement !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                MySqlConnection maCnx;

                maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                try
                {
                    string requete;
                    maCnx.Open();
                    // FAIRE UNE CLASSE PORT POUR ATTRIBUER l'ID DANS LA BASE DE DONNEES MYSQL !
                    requete = "INSERT INTO liaison (nosecteur, noport_depart, noport_arrivee, distance) VALUES (@NOSECTEUR, @NOPORT_DEPART, @NOPORT_ARRIVEE, @DISTANCE)";
                    var maCde = new MySqlCommand(requete, maCnx);
                    maCde.Parameters.AddWithValue("@NOSECTEUR", lbxSecteurs.Items);
                    maCde.Parameters.AddWithValue("@NOPORT_DEPART", cmbDepart.Items);
                    maCde.Parameters.AddWithValue("@NOPORT_ARRIVEE", cmbArrivee.Items);
                    maCde.Parameters.AddWithValue("@DISTANCE", tbxDistance.Text);
                    int nbLigneAffectees;
                    nbLigneAffectees = maCde.ExecuteNonQuery();
                    MessageBox.Show("Liaison ajoutée : " + nbLigneAffectees.ToString(), "Insertion effectuée !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (MySql)
            }
        }
    }
}
