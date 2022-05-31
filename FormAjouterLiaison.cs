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
    public partial class FormAjouterLiaison : Form
    {
        public FormAjouterLiaison()
        {
            InitializeComponent();
        }

        Color ControleSaisie(TextBox tbxInfoLiaison)
        {
            var objetRegEx = new Regex("^[0-9 .]*$");

            var resultatTest = objetRegEx.Match(tbxInfoLiaison.Text);
            if (!resultatTest.Success)
            {
                return tbxInfoLiaison.BackColor = Color.LightPink;
            }
            else
            {
               return tbxInfoLiaison.BackColor = Color.LightGreen;
            }
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
                string requeteListeSecteur;
                maCnx.Open();

                requeteListeSecteur = "SELECT nosecteur, nom FROM secteur";

                var maCdeListeSecteur = new MySqlCommand(requeteListeSecteur, maCnx);

                jeuEnr = maCdeListeSecteur.ExecuteReader();
                while (jeuEnr.Read())
                {
                    // Création d'un secteur
                    Secteur unSecteur;
                    unSecteur = new Secteur((int)(jeuEnr["nosecteur"]), jeuEnr["nom"].ToString());
                    // Affichage du secteur dans la ListBox, on affiche l'objet 'unSecteur' qui est égal à la ligne précédente.
                    lbxSecteurs.Items.Add(unSecteur);
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            maCnx.Close();
            try
            {
                maCnx.Open();

                string requeteListePort;

                requeteListePort = "SELECT * FROM port";

                var maCdeListePort = new MySqlCommand(requeteListePort, maCnx);

                jeuEnr = maCdeListePort.ExecuteReader();
                while (jeuEnr.Read())
                {
                    // Création d'un port.
                    Port unPortDepart;
                    unPortDepart = new Port((int)(jeuEnr["noport"]), jeuEnr["nom"].ToString()); // .ToString() car c'est le nom qui va apparaitre dans la
                    // ComboBox.
                    // Ajout d'un port dans une ComboBox qui sera égal à unPortDépart.
                    cmbDepart.Items.Add(unPortDepart);
                    Port unPortArrivee;
                    // Création d'un port d'arrivée.
                    unPortArrivee = new Port((int)(jeuEnr["noport"]), jeuEnr["nom"].ToString());//.ToString() car c'est le nom qui va apparaitre dans la
                    // ComboBox.
                    //Ajout d'un port d'arrivée dans une ComboBox qui sera égal à unPortArrivée
                    cmbArrivee.Items.Add(unPortArrivee);
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            maCnx.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (lbxSecteurs.Text == "" | cmbDepart.Text == "" | cmbArrivee.Text == "" | tbxDistance.Text == "")
            {
                MessageBox.Show("Assurez-vous d'avoir remplie les champs suivant : Secteurs, Départ, Arrivée et Distance.", "Avertissement !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                DialogResult confirmation;
                confirmation = MessageBox.Show("Etes-vous certains d'ajouter ces éléments suivant dans la base de données ? " + "\nSecteurs : " + lbxSecteurs.Text + "\nDépart : " + cmbDepart.Text + "\nArrivée : " + cmbArrivee.Text + "\nDistance : " + tbxDistance.Text, "Confirmation !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmation == DialogResult.Yes)
                {
                    if (ControleSaisie(tbxDistance) == Color.LightGreen)
                    {
                        MySqlConnection maCnx;

                        maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                        try
                        {
                            string requete;
                            maCnx.Open();
                            requete = "INSERT INTO liaison (nosecteur, noport_depart, noport_arrivee, distance) VALUES (@NOSECTEUR, @NOPORT_DEPART, @NOPORT_ARRIVEE, @DISTANCE)";
                            var maCde = new MySqlCommand(requete, maCnx);
                            maCde.Parameters.AddWithValue("@NOSECTEUR", ((Secteur)(lbxSecteurs.SelectedItem)).GetNoSecteur());
                            maCde.Parameters.AddWithValue("@NOPORT_DEPART", ((Port)(cmbDepart.SelectedItem)).GetNoPort());
                            maCde.Parameters.AddWithValue("@NOPORT_ARRIVEE", ((Port)(cmbArrivee.SelectedItem)).GetNoPort());
                            maCde.Parameters.AddWithValue("@DISTANCE", tbxDistance.Text);
                            int nbLigneAffectees;
                            nbLigneAffectees = maCde.ExecuteNonQuery();
                            MessageBox.Show("Liaison ajoutée : " + nbLigneAffectees.ToString(), "Insertion effectuée !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        } catch (MySqlException error)
                        {
                            MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        maCnx.Close();
                    } else
                    {
                        MessageBox.Show("La distance n'est pas exprimée en nombre/chiffre : Pas d'insertion possible", "Problème de type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void cmbDepart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxDistance_TextChanged(object sender, EventArgs e)
        {
            ControleSaisie(tbxDistance);
        }
    }
}
