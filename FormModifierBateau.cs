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
    public partial class FormModifierBateau : Form
    {
        public FormModifierBateau()
        {
            InitializeComponent();
        }

        // Fonction permettant de vérifier si le contenue de la TextBox est bien valide pour le SGBDR.
        Color ControleSaisie(TextBox tbxInfoBateau)
        {
            var objetRegex = new Regex("^[0-9]*$");

            var résultatTest = objetRegex.Match(tbxInfoBateau.Text);
            if (!résultatTest.Success)
            {
                return tbxInfoBateau.BackColor = Color.LightPink;
            } else
            {
                return tbxInfoBateau.BackColor = Color.LightGreen;
            }
        }
        private void FormModifierBateau_Load(object sender, EventArgs e)
        {
            // Lors du chargement de la page, on va charger tous les noms des bateaux dans la ListBox   
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requete;
                maCnx.Open();
                requete = "SELECT * FROM bateau";

                var maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();
                while (jeuEnr.Read())
                {
                    Bateau unBateau;
                    unBateau = new Bateau(jeuEnr["nom"].ToString(), (int)(jeuEnr["nobateau"]));
                    cmbBateau.Items.Add(unBateau);
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }

        private void cmbBateau_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Après avoir choisis le bateau, on va devoir prendre les caractéristiques des bateaux et afficher les TextBox ainsi que les labels dynamiquement
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                gbxCapacitesMaximales.Controls.Clear();
                int nobateau;
                nobateau = ((Bateau)(cmbBateau.SelectedItem)).GetNoBateau();
                string requete;
                maCnx.Open();
                requete = "SELECT libelle, capacitemax FROM categorie, contenir, bateau WHERE contenir.nobateau = bateau.nobateau AND categorie.lettrecategorie = contenir.lettrecategorie AND bateau.nobateau = @NOBATEAU";

                var maCde = new MySqlCommand(requete, maCnx);
                maCde.Parameters.AddWithValue("@NOBATEAU", nobateau);

                jeuEnr = maCde.ExecuteReader();
                int i = 0;
                while (jeuEnr.Read())
                {
                    Label lblCapacitesMaximales;
                    lblCapacitesMaximales = new Label();
                    lblCapacitesMaximales.Text = jeuEnr["libelle"].ToString();
                    lblCapacitesMaximales.Location = new Point(15, i * 25);
                    gbxCapacitesMaximales.Controls.Add(lblCapacitesMaximales);

                    // Création des TextBox générer dynamiquement.
                    TextBox tbxCapacitesMaximales;
                    tbxCapacitesMaximales = new TextBox();
                    tbxCapacitesMaximales.Text = jeuEnr["capacitemax"].ToString();
                    tbxCapacitesMaximales.Location = new Point(130, i * 25);
                    gbxCapacitesMaximales.Controls.Add(tbxCapacitesMaximales);

                    i += 2;
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                int nobateau;
                nobateau = ((Bateau)(cmbBateau.SelectedItem)).GetNoBateau();
                //System.NullReferenceException
                if (cmbBateau.Text == "")
                {
                    // Si l'utilisateur ne selectionne aucun bateau, on va renvoyer un message signalant qu'il est impossible de faire la modification car 
                    // on ne peut pas modifier un bateau qu'on ne connait pas
                    MessageBox.Show("Vous n'avez sélectionner aucun bateau, il est impossible d'appliquer des modifications !", "Modification impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Si l'utilisateur à choisis un bateau, on va demander la confirmation à l'utilisateur avant de faire une insertion.
                    DialogResult confirmation;
                    confirmation = MessageBox.Show("Vous confirmez la modification de ce bateau ?", "Modification.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmation == DialogResult.Yes)
                    {
                        // Si l'utilisateur clique sur le bouton 'Oui' alors, on procède à la mise à jour !
                        MySqlConnection maCnx;

                        maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                        try
                        {
                            string requeteA;
                            maCnx.Open();
                            requeteA = "UPDATE contenir SET capacitemax = @CAPACITEMAX WHERE lettrecategorie = A AND nobateau = @NOBATEAU";

                            var maCdeA = new MySqlCommand(requeteA, maCnx);
                            //maCdeA.Parameters.AddWithValue("@CAPACITEMAX", );
                            maCdeA.Parameters.AddWithValue("@NOBATEAU", nobateau);

                            maCdeA.ExecuteNonQuery();
                        }
                        catch (MySqlException error)
                        {
                            MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        maCnx.Close();

                        try
                        {
                            string requeteB;
                            maCnx.Open();
                            requeteB = "UPDATE contenir SET capacitemax = @CAPACITEMAX WHERE lettrecategorie = B AND nobateau = @NOBATEAU";

                            var maCdeB = new MySqlCommand(requeteB, maCnx);
                            // maCdeB.Parameters.AddWithValue("@CAPACITEMAX", );
                            maCdeB.Parameters.AddWithValue("@NOBATEAU", nobateau);

                            maCdeB.ExecuteNonQuery();

                        }
                        catch (MySqlException error)
                        {
                            MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        maCnx.Close();

                        try
                        {
                            string requeteC;
                            maCnx.Open();
                            requeteC = "UPDATE contenir SET capacitemax = @CAPACITEMAX WHERE lettrecategorie = C AND nobateau = @NOBATEAU";

                            var maCdeC = new MySqlCommand(requeteC, maCnx);
                            // maCdeC.Parameters.AddWithValue("@CAPACITEMAX", );
                            maCdeC.Parameters.AddWithValue("@NOBATEAU", nobateau);

                            int nbLigneAffectees;
                            nbLigneAffectees = maCdeC.ExecuteNonQuery();
                            MessageBox.Show("Le bateau à été modifiée avec succès !", "Modification effectuée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (MySqlException error)
                        {
                            MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        maCnx.Close();
                    }
                }
            } catch (System.NullReferenceException error)
            {
                MessageBox.Show("Le nom de bateau tapée n'existe pas dans la base de données ! \nVoici l'erreur : " + "\n" + error.ToString(),"Nom de bateau inexistant !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void gbxCapacitesMaximales_Enter(object sender, EventArgs e)
        {
            //ControleSaisie();
        }
    }
}
