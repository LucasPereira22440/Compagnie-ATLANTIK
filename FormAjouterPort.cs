using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Compagnie_ATLANTIK
{
    public partial class FormAjouterPort : Form
    {
        public FormAjouterPort()
        {
            InitializeComponent();
        }

        // Fonction retournant les bon types selon le type à insérer dans la base de données, elle gère la vérification de caractère.
        Color ControleSaisie(TextBox tbxNomPort)
        {
            var objetRegEx = new Regex("^[a-zA-Zéèêëçàâôù ûïî -]*$");

            var resultatTest = objetRegEx.Match(tbxNomPort.Text);
            if (!resultatTest.Success)
            {
                return tbxNomPort.BackColor = Color.LightPink;
            } else
            {
                return tbxNomPort.BackColor = Color.LightGreen;
            }
        }
        private void btnAjouterPort_Click(object sender, EventArgs e)
        {
            if (tbxNomPort.Text == "")
            {
                MessageBox.Show("Aucun nom de port rentrée !", "Avertissement !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                DialogResult confirmation;
                confirmation = MessageBox.Show("Etes-vous certains de vouloir ajouter ce port : " + tbxNomPort.Text + " dans la base de données ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmation == DialogResult.Yes)
                {
                    if (ControleSaisie(tbxNomPort) == Color.LightGreen)
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

                            int nbLigneAffectees;
                            nbLigneAffectees = maCde.ExecuteNonQuery();
                            MessageBox.Show("Port ajoutée : " + nbLigneAffectees.ToString(), "Insertion effectuée !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbxNomPort.Clear();
                        }
                        catch (MySqlException error)
                        {
                            MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        maCnx.Close();
                    } else
                    {
                        MessageBox.Show("Un nom de port doit contenir des lettres pas uniquement des chiffres/nombres : Pas d'insertion possible !", "Problème de type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void tbxNomPort_TextChanged(object sender, EventArgs e)
        {
            ControleSaisie(tbxNomPort);
        }
    }
}
