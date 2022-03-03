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
    public partial class FormAjouterSecteur : Form
    {
        public FormAjouterSecteur()
        {
            InitializeComponent();
        }

        private void btnAjouterSecteur_Click(object sender, EventArgs e)
        {
            if (tbxNomSecteur.Text == "")
            {
                MessageBox.Show("Aucun nom de secteur rentrée !", "Avertissement !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                MySqlConnection maCnx;
                maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                try
                {
                    string requete;
                    maCnx.Open();

                    requete = "INSERT INTO secteur (nom) VALUES (@NOM)";
                    var maCde = new MySqlCommand(requete, maCnx);
                    maCde.Parameters.AddWithValue("@NOM", tbxNomSecteur.Text);
                    maCde.ExecuteScalar();
                    MessageBox.Show("Secteur ajoutée : " + tbxNomSecteur.Text, "Insertion effectuée !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                } catch (MySqlException error)
                {
                    MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbxNomSecteur.Clear();
                }
                maCnx.Close();
            }
        }

        private void tbxNomSecteur_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
