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
    public partial class FormAjouterBateau : Form
    {

        // Fonction permettant d'aller chercher l'ID du bateau venant d'être ajoutée
        int GetIDBateau()
        {
            MySqlConnection maCnx;
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requeteID;
                maCnx.Open();
                requeteID = "SELECT MAX(nobateau) FROM bateau";
                var maCdeID = new MySqlCommand(requeteID, maCnx);
                Int32 nbID = Convert.ToInt32(maCdeID.ExecuteScalar());
                maCnx.Close();
                return nbID;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + e.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maCnx.Close();
                return 0;
            }
        }

        // Création d'une fonction permettant d'appeller la méthode à plusieurs reprise afin d'économiser du code.
        Color ControleSaisieInfoBateau(TextBox tbxinfoBateau)
        {
            var objetRegEx = new Regex("^[0-9]*$");
            var resultatTest = objetRegEx.Match(tbxinfoBateau.Text);
            if (!resultatTest.Success)
            {
                return tbxinfoBateau.BackColor = Color.LightPink;
            } else
            {
                return tbxinfoBateau.BackColor = Color.LightGreen;
            }
        }

        // Fonction permettant de filtrer les chiffres/nombres de la TextBox uniquement pour les noms des bateaux.
        Color ControleSaisieNomBateau(TextBox tbxNomBateau)
        {
            var objetRegEx = new Regex("^[a-zA-Zéèêëçàâôù ûïî ']*$");
            var resultatTest = objetRegEx.Match(tbxNomBateau.Text);
            if (!resultatTest.Success)
            {
                return tbxNomBateau.BackColor = Color.LightPink;
            } else
            {
                return tbxNomBateau.BackColor = Color.LightGreen;
            }
        }


        public FormAjouterBateau()
        {
            InitializeComponent();
        }

        private void FormAjouterBateau_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAjouterBateau_Click(object sender, EventArgs e)
        {
            if (tbxNomBateau.Text == "" | tbxAPassager.Text == "" | tbxBVehiculeInferieur.Text == "" | tbxCVehiculeSuperieur.Text == "")
            {
                MessageBox.Show("Assurez-vous d'avoir remplie les champs suivant : Nom bateau, A (Passager), B (Véhicule inférieur à 2m et C (Véhicule supérieur à 2m).", "Avertissement !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                DialogResult confirmation;
                confirmation = MessageBox.Show("Etes-vous certains d'ajouter cette élément suivants dans la table 'bateau' ?" + "\nNom bateau : " + tbxNomBateau.Text + "\n" + "\nDe plus, ces informations seront ajouter dans la table 'contenir', vous confirmez ?" + "\nPassager : " + tbxAPassager.Text + "\nVéhi.inf.2m : " + tbxBVehiculeInferieur.Text + "\nVehi.sup.2m : " + tbxCVehiculeSuperieur.Text, "Confirmation ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmation == DialogResult.Yes)
                {
                    if (ControleSaisieInfoBateau(tbxAPassager) == Color.LightGreen & ControleSaisieInfoBateau(tbxBVehiculeInferieur) == Color.LightGreen & ControleSaisieInfoBateau(tbxCVehiculeSuperieur) == Color.LightGreen & ControleSaisieNomBateau(tbxNomBateau) == Color.LightGreen)
                    {
                        MySqlConnection maCnx;
                        maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

                        try
                        {
                            // Au début, on insère un bateau dans la base de données.
                            string requeteBateau;
                            maCnx.Open();
                            requeteBateau = "INSERT INTO bateau (nom) VALUES (@NOM)";
                            var maCdeBateau = new MySqlCommand(requeteBateau, maCnx);
                            maCdeBateau.Parameters.AddWithValue("@NOM", tbxNomBateau.Text);
                            maCdeBateau.ExecuteNonQuery();
                        }
                        catch (MySqlException error)
                        {
                            MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        maCnx.Close();

                        try
                        {
                            // Ensuite, on insère les données concernant le nombre de passager à bord pour le navire
                            maCnx.Open();
                            string requeteContenirA;
                            requeteContenirA = "INSERT INTO contenir VALUES ('A', @NOBATEAU, @CAPACITEMAX)";
                            var maCdeContenirA = new MySqlCommand(requeteContenirA, maCnx);
                            maCdeContenirA.Parameters.AddWithValue("@NOBATEAU", GetIDBateau());
                            maCdeContenirA.Parameters.AddWithValue("@CAPACITEMAX", tbxAPassager.Text);
                            maCdeContenirA.ExecuteNonQuery();
                        }
                        catch (MySqlException error)
                        {
                            MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        maCnx.Close();
                        try
                        {
                            // Puis on insère les données concernant le nombre de véhicule que peut supporter le navire inférieur à 2m 
                            maCnx.Open();
                            string requeteContenirB;
                            requeteContenirB = "INSERT INTO contenir VALUES ('B', @NOBATEAU, @CAPACITEMAX)";
                            var maCdeContenirB = new MySqlCommand(requeteContenirB, maCnx);
                            maCdeContenirB.Parameters.AddWithValue("@NOBATEAU", GetIDBateau());
                            maCdeContenirB.Parameters.AddWithValue("@CAPACITEMAX", tbxBVehiculeInferieur.Text);
                            maCdeContenirB.ExecuteNonQuery();
                        }
                        catch (MySqlException error)
                        {
                            MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        maCnx.Close();


                        try
                        {
                            // Enfin, on insère les données concernant le nombre de véhicule que peut supporter le navire supérieur à 2m
                            maCnx.Open();
                            string requeteContenirC;
                            requeteContenirC = "INSERT INTO contenir VALUES ('C', @NOBATEAU, @CAPACITEMAX)";
                            var maCdeContenirC = new MySqlCommand(requeteContenirC, maCnx);
                            maCdeContenirC.Parameters.AddWithValue("@NOBATEAU", GetIDBateau());
                            maCdeContenirC.Parameters.AddWithValue("@CAPACITEMAX", tbxCVehiculeSuperieur.Text);
                            int nbLigneAffectées;
                            nbLigneAffectées = maCdeContenirC.ExecuteNonQuery();
                            MessageBox.Show("Votre bateau a été ajoutée avec succès ! \nNombre de bateau insérée : " + nbLigneAffectées.ToString(), "Insertion efféctuée !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (MySqlException error)
                        {
                            MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        maCnx.Close();
                    } else
                    {
                        MessageBox.Show("Les caractéristiques du bateau doivent être en nombre/chiffre et le nom du bateau doit contenir des lettres : Insertion non effectuée !", "Problème de type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void tbxAPassager_TextChanged(object sender, EventArgs e)
        {
            // Appel de la fonction 'ControleSaisieInfoBateau' permettant de gérer les controles de saisies dans les TextBox
            ControleSaisieInfoBateau(tbxAPassager);
        }

        private void tbxBVehiculeInferieur_TextChanged(object sender, EventArgs e)
        {
            // Appel de la fonction 'ControleSaisieInfoBateau' permettant de gérer les controles de saisies dans les TextBox
            ControleSaisieInfoBateau(tbxBVehiculeInferieur);
        }

        private void tbxCVehiculeSuperieur_TextChanged(object sender, EventArgs e)
        {
            // Appel de la fonction 'ControleSaisieInfoBateau' permettant de gérer les controles de saisies dans les TextBox
            ControleSaisieInfoBateau(tbxCVehiculeSuperieur);
        }

        private void tbxNomBateau_TextChanged(object sender, EventArgs e)
        {
            // Appel de la fonction 'ControleSaisieNomBateau' permettant de gérer les controles de saisies dans les TextBox
            ControleSaisieNomBateau(tbxNomBateau);
        }
    }
}
