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
    public partial class FormAjouterPort : Form
    {
        public FormAjouterPort()
        {
            InitializeComponent();
        }

        private void btnAjouterPort_Click(object sender, EventArgs e)
        {
            if (tbxNomPort.Text == "")
            {
                MessageBox.Show("Aucun nom de port rentrée !", "Avertissement !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                MySqlConnection maCnx;
                maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                try
                {
                    string requete;
                    maCnx.Open();

                    requete = "INSERT INTO port (nom) VALUES (@NOM)";
                    var maCde = new MySqlCommand(requete, maCnx);
                    maCde.Parameters.AddWithValue("@NOM", tbxNomPort.Text);

                    int confirmationInsertion;
                    maCde.ExecuteScalar();
                    MessageBox.Show("Port ajoutée : " + tbxNomPort.Text, "Insertion effectuée !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (MySqlException error)
                {
                    MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                maCnx.Close();
            }
        }
    }
}
