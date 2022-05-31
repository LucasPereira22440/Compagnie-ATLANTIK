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
    public partial class FormAjouterSecteur : Form
    {
        public FormAjouterSecteur()
        {
            InitializeComponent();
        }

        Color ControleSaisie(TextBox tbxNomSecteur)
        {
            var objetRegEx = new Regex("^[a-zA-Zéèêëçàâôù ûïî]*$");

            var resultatTest = objetRegEx.Match(tbxNomSecteur.Text);
            if (!resultatTest.Success)
            {
                return tbxNomSecteur.BackColor = Color.LightPink;
            } else
            {
                return tbxNomSecteur.BackColor = Color.LightGreen;
            }
        }
        private void btnAjouterSecteur_Click(object sender, EventArgs e)
        {
            if (tbxNomSecteur.Text == "")
            {
                MessageBox.Show("Aucun nom de secteur rentrée !", "Avertissement !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                DialogResult confirmation;
                confirmation = MessageBox.Show("Etes-vous certains de vouloir ajouter ce secteur : " + tbxNomSecteur.Text + " dans la base de données ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmation == DialogResult.Yes)
                {
                    if (ControleSaisie(tbxNomSecteur) == Color.LightGreen)
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
                            int nbLigneAffectees;
                            nbLigneAffectees = maCde.ExecuteNonQuery();
                            MessageBox.Show("Secteur ajoutée : " + nbLigneAffectees.ToString(), "Insertion effectuée !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (MySqlException error)
                        {
                            MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbxNomSecteur.Clear();
                        }
                        maCnx.Close();
                    } else
                    {
                        MessageBox.Show("Un nom de secteur doit contenir des lettres et pas uniquement des chiffres/nombres : Pas d'insertion possible !", "Problème de type !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void tbxNomSecteur_TextChanged(object sender, EventArgs e)
        {
            ControleSaisie(tbxNomSecteur);
        }

        private void FormAjouterSecteur_Load(object sender, EventArgs e)
        {

        }
    }
}
