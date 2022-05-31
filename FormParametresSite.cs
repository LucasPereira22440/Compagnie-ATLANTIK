using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Compagnie_ATLANTIK
{
    public partial class FormParametresSite : Form
    {
        public FormParametresSite()
        {
            InitializeComponent();
        }

        // Création d'une fonction permettant d'appeller la méthode à plusieurs reprise afin d'économiser du code.
        Color ControleSaisie(TextBox tbxInfoSite)
        {
            var objetRegEx = new Regex("^[0-9 .]*$");

            var resultatTest = objetRegEx.Match(tbxInfoSite.Text);
            if (!resultatTest.Success)
            {
                return tbxInfoSite.BackColor = Color.LightPink;
            }
            else
            {
                return tbxInfoSite.BackColor = Color.LightGreen;
            }
        }
        private void FormParametresSite_Load(object sender, EventArgs e)
        {
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requête;
                maCnx.Open();

                requête = "SELECT * FROM parametres";

                var maCde = new MySqlCommand(requête, maCnx);

                jeuEnr = maCde.ExecuteReader();
                while (jeuEnr.Read())
                {
                    tbxSite.Text = jeuEnr["site_pb"].ToString();
                    tbxRang.Text = jeuEnr["rang_pb"].ToString();
                    tbxIdentifiant.Text = jeuEnr["identifiant_pb"].ToString();
                    tbxCleHMAC.Text = jeuEnr["clehmac_pb"].ToString();
                    cbxEnProduction.Checked = (bool)jeuEnr["enproduction"];
                    tbxMelSite.Text = jeuEnr["melsite"].ToString();
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            DialogResult confirmation;
            confirmation = MessageBox.Show("Etes-vous certains de vouloir modifier le site ?", "Modification site web", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == confirmation)
            {
                MySqlConnection maCnx;

                maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                    if (ControleSaisie(tbxSite) == Color.LightGreen & ControleSaisie(tbxRang) == Color.LightGreen & ControleSaisie(tbxIdentifiant) == Color.LightGreen)
                    {
                        try
                        {
                        string requête;
                        maCnx.Open();

                        requête = "UPDATE parametres SET site_pb = @SITE_PB, rang_pb = @RANG_PB, identifiant_pb = @IDENTIFIANT_PB, clehmac_pb = @CLEHMAC_PB, enproduction = @ENPRODUCTION, melsite = @MELSITE";

                        var maCde = new MySqlCommand(requête, maCnx);
                        maCde.Parameters.AddWithValue("@SITE_PB", tbxSite.Text);
                        maCde.Parameters.AddWithValue("@RANG_PB", tbxRang.Text);
                        maCde.Parameters.AddWithValue("@IDENTIFIANT_PB", tbxIdentifiant.Text);
                        maCde.Parameters.AddWithValue("@CLEHMAC_PB", tbxCleHMAC.Text);
                        maCde.Parameters.AddWithValue("@ENPRODUCTION", cbxEnProduction.Checked);
                        maCde.Parameters.AddWithValue("@MELSITE", tbxMelSite.Text);

                        int nbLigneAffectées;
                        nbLigneAffectées = maCde.ExecuteNonQuery();
                        MessageBox.Show("Le site à correctement été modifier : " + nbLigneAffectées.ToString() + " ligne(s) ont été modifier dans la base de données de la table 'paramètres' !", "Modification effectuée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } catch (MySqlException error)
                        {
                            MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    } else
                    {
                    MessageBox.Show("Impossible d'insérer des lettres, uniquement des nombres/chiffres sont tolérées. Aucune insertion effectuée !", "Erreur de type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
            }
        }

        private void tbxSite_TextChanged(object sender, EventArgs e)
        {
            // Appel de la fonction afin d'économiser du code pour le contrôle de saisie
            ControleSaisie(tbxSite);
        }

        private void tbxRang_TextChanged(object sender, EventArgs e)
        {
            // Appel de la fonction afin d'économiser du code pour le contrôle de saisie
            ControleSaisie(tbxRang);
        }

        private void tbxIdentifiant_TextChanged(object sender, EventArgs e)
        {
            // Appel de la fonction afin d'économiser du code pour le contrôle de saisie
            ControleSaisie(tbxIdentifiant);
        }
    }
}
