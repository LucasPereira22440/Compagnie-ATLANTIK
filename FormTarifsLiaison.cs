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

namespace Compagnie_ATLANTIK
{
    public partial class FormTarifsLiaison : Form
    {
        public FormTarifsLiaison()
        {
            InitializeComponent();
        }

        private void FormTarifsLiaison_Load(object sender, EventArgs e)
        {
            // Quand on arrive sur la page, on charge les secteurs ainsi que les Labels et TextBox nécessaire dynamiquement.
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requeteSecteur;
                maCnx.Open();

                requeteSecteur = "SELECT * FROM secteur";

                var maCdeSecteur = new MySqlCommand(requeteSecteur, maCnx);

                jeuEnr = maCdeSecteur.ExecuteReader();
                while (jeuEnr.Read())
                {
                    Secteur unSecteur;
                    unSecteur = new Secteur((int)(jeuEnr["nosecteur"]), jeuEnr["nom"].ToString());
                    lbxSecteurs.Items.Add(unSecteur);
                }
                
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();

            try
            {
                string requeteTarif;
                maCnx.Open();

                requeteTarif = "SELECT * FROM type";

                var maCdeTarif = new MySqlCommand(requeteTarif, maCnx);

                jeuEnr = maCdeTarif.ExecuteReader();
                int i = 1;

                Label lblCategorieType;
                lblCategorieType = new Label();
                lblCategorieType.Text = "Catégorie - Type";
                lblCategorieType.Location = new Point(30, 1 * 25);
                gbxTarifs.Controls.Add(lblCategorieType);

                Label lblTarif;
                lblTarif = new Label();
                lblTarif.Text = "Tarif";
                lblTarif.Location = new Point(150, 1 * 25);
                gbxTarifs.Controls.Add(lblTarif);

                while (jeuEnr.Read())
                {
                    Label lblInfoTarif;
                    lblInfoTarif = new Label();
                    lblInfoTarif.Text = jeuEnr["lettrecategorie"].ToString() + jeuEnr["notype"].ToString() + " - " + jeuEnr["libelle"].ToString() + " :";
                    lblInfoTarif.Location = new Point(30, i * 25);
                    gbxTarifs.Controls.Add(lblInfoTarif);

                    TextBox tbxInfoTarif;
                    tbxInfoTarif = new TextBox();
                    tbxInfoTarif.Location = new Point(150, i * 25);
                    gbxTarifs.Controls.Add(tbxInfoTarif);

                    i += 1;
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la bse de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
            
        }

        private void lbxSecteurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Après avoir choisis un secteur, on prépare notre programme pour qu'on puisse choisir une Liaison par rapport au Secteurs sélectionner.
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                cmbLiaison.Items.Clear();

                int nosecteur;
                nosecteur = ((Secteur)(lbxSecteurs.SelectedItem)).GetNoSecteur();

                string requete;
                maCnx.Open();

                requete = "SELECT pd.nom AS 'Port Départ', pa.nom AS 'Port Arrivée', noliaison, nosecteur, noport_depart, noport_arrivee, distance FROM liaison, port pd, port pa WHERE pd.noport = liaison.noport_depart AND pa.noport = liaison.noport_arrivee AND nosecteur = @NOSECTEUR ";

                var maCde = new MySqlCommand(requete, maCnx);
                maCde.Parameters.AddWithValue("@NOSECTEUR", nosecteur);

                jeuEnr = maCde.ExecuteReader();
                while (jeuEnr.Read())
                {
                    Liaison uneLiaison;
                    uneLiaison = new Liaison(jeuEnr["Port Départ"].ToString(), jeuEnr["Port Arrivée"].ToString(), (int)(jeuEnr["noliaison"]), (int)(jeuEnr["nosecteur"]), (int)(jeuEnr["noport_depart"]), (int)(jeuEnr["noport_arrivee"]), (double)(jeuEnr["distance"]));
                    cmbLiaison.Items.Add(uneLiaison);
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Si on appuie sur le bouton 'Ajouter', on va vérifier qu'on possède les entrées requise pour pouvoir compléter les données dans le SGBDR
            if (lbxSecteurs.Text == "" | cmbLiaison.Text == "" | cmbPeriode.Text == "")
            {
                // Si il y'a pas de secteur de choisis ou de liaison choisis, alors on invertit l'utilisateur qu'on ne possède pas suffisammenent d'information pour faire une insertion
                MessageBox.Show("Vous n'avez pas sélectionnez de liaison ou pas de secteur, veuillez remplir ces champs suivants : " + "\n- Liaison" + "\n- Secteur" + "\n- Période", "Champs nom remplie !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                // Si tout est bon, on fait une confirmation pour que l'utilisateur confirme l'insertion et par conséquent, l'ajout de données.
                DialogResult confirmation;
                confirmation = MessageBox.Show("Etes-vous certains d'ajouter les champs suivants dans la base de données ?", "Confirmer insertion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DialogResult.Yes == confirmation)
                {
                    MySqlConnection maCnx;

                    maCnx = new MySqlConnection("server=localhost;user=root;databse=atlantik;port=3306;password=");
                    try
                    {
                        int noperiode;
                        noperiode = ((Periode)(cmbLiaison.SelectedItem)).GetNoPeriode();

                        int noliaison;
                        noliaison = ((Liaison)(cmbLiaison.SelectedItem)).GetNoLiaison();

                        string requete;
                        maCnx.Open();

                        requete = "INSERT INTO tarifer VALUES (@NOPERIODE, @LETTRECATEGORIE, @NOTYPE, @NOLIAISON, @TARIF)";

                        var maCde = new MySqlCommand(requete, maCnx);
                        maCde.Parameters.AddWithValue("@NOPERIODE", noperiode);
                        //maCde.Parameters.AddWithValue("@LETTRECATEGORIE", );
                        //maCde.Parameters.AddWithValue("@NOTYPE" ,);
                        maCde.Parameters.AddWithValue("@NOLIAISON", noliaison);
                        //maCde.Parameters.AddWithValue("@TARIF", );

                        int nbLigneAffectees;
                        nbLigneAffectees = maCde.ExecuteNonQuery();
                        MessageBox.Show("Insertion effectuée dans la table 'tarifier' de la base de deonnées " + "\nNombre de ligne insérée : " + nbLigneAffectees.ToString(), "Insertion effectuée", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    } catch (MySqlException error)
                    {
                        MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    maCnx.Close();
                }
            }
        }

        private void cmbLiaison_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Après avoir selectionner une Liaison on va préparer notre programme pour qu'il nous donne la bonne période en fonction de la Liaison choisis.
            int noliaison;
            noliaison = ((Liaison)(cmbLiaison.SelectedItem)).GetNoLiaison();

            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                cmbPeriode.Items.Clear();
                string requête;
                maCnx.Open();

                requête = "SELECT DISTINCT(periode.noperiode), datedebut, datefin FROM periode, tarifer, liaison WHERE periode.noperiode = tarifer.noperiode AND tarifer.noliaison = liaison.noliaison AND liaison.noliaison = @NOLIAISON";

                var maCde = new MySqlCommand(requête, maCnx);
                maCde.Parameters.AddWithValue("@NOLIAISON", noliaison);

                jeuEnr = maCde.ExecuteReader();
                while (jeuEnr.Read())
                {
                    Periode unePeriode;
                    string[] datedebut;
                    datedebut = jeuEnr["datedebut"].ToString().Split(' ');

                    string[] datefin;
                    datefin = jeuEnr["datefin"].ToString().Split(' ');

                    unePeriode = new Periode(Convert.ToInt32(jeuEnr["noperiode"]), datedebut[0], datefin[0]);
                    cmbPeriode.Items.Add(unePeriode);
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }
    }
}