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
    public partial class FormAjouterTraversee : Form
    {
        public FormAjouterTraversee()
        {
            InitializeComponent();
        }

        private void FormAjouterTraversee_Load(object sender, EventArgs e)
        {
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requeteLbxSecteurs;
                maCnx.Open();

                requeteLbxSecteurs = "SELECT nom, nosecteur FROM secteur";
                var maCdeLbxSecteurs = new MySqlCommand(requeteLbxSecteurs, maCnx);

                jeuEnr = maCdeLbxSecteurs.ExecuteReader();
                while (jeuEnr.Read())
                {
                    // Je créer un secteur
                    Secteur unSecteur;
                    unSecteur = new Secteur((int)(jeuEnr["nosecteur"]), jeuEnr["nom"].ToString()); //.ToString car on veut afficher uniquement les noms des  
                    // secteurs dans la ListBox
                    // Après avoir défini mon objet 'unSecteur' je l'applique dans l'ajout de ma ListBox
                    lbxSecteurs.Items.Add((unSecteur));
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
            try
            {
                string requeteCmbNomBateau;
                maCnx.Open();

                requeteCmbNomBateau = "SELECT nobateau, nom FROM bateau";
                var maCdeCmbNomBateau = new MySqlCommand(requeteCmbNomBateau, maCnx);

                jeuEnr = maCdeCmbNomBateau.ExecuteReader();
                while (jeuEnr.Read())
                {
                    // Je créer un bateau
                    Bateau unBateau;
                    unBateau = new Bateau(jeuEnr["nom"].ToString(), (int)(jeuEnr["nobateau"])); //.ToString car on veut afficher le nom des bateaux dans notre ComboBox
                    // J'ajoute le bateau dans notre ComboBox uniquement les noms des bateaux (d'ou le .ToString())
                    cmbNomBateau.Items.Add(unBateau);
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (lbxSecteurs.Text == "" | cmbNomBateau.Text == "" | cmbLiaison.Text == "")
            {
                MessageBox.Show("Assurez-vous de remplir ces champs suivants : Secteurs, Nom bateau et Liaison !", "Avertissement !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                MySqlConnection maCnx;
                maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                DialogResult confirmation;
                confirmation = MessageBox.Show("Etes-vous certains de vouloir ajoutée ceci dans la table 'traversee' ? " + "\nSecteur : " + lbxSecteurs.Text + "\nNom bateau : " + cmbNomBateau.Text + "\nLiaison : " + cmbLiaison.Text + "\nDate et heure départ : " + dateHeureDepart.Value + "\nDate et heure arrivée : " + dateHeureArrivee.Value, "Confirmation insertion !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmation == DialogResult.Yes)
                {
                    try
                    {
                        string requete;
                        maCnx.Open();
                        requete = "INSERT INTO traversee (noliaison, nobateau, dateheuredepart, dateheurearrivee) VALUES (@NOLIAISON, @NOBATEAU, @DATEHEUREDEPART, @DATEHEUREARRIVEE)";
                        var maCde = new MySqlCommand(requete, maCnx);
                        maCde.Parameters.AddWithValue("@NOLIAISON" , ((Liaison)(cmbLiaison.SelectedItem)).GetNoLiaison());
                        maCde.Parameters.AddWithValue("@NOBATEAU", ((Bateau)(cmbNomBateau.SelectedItem)).GetNoBateau()); // OK
                        maCde.Parameters.AddWithValue("@DATEHEUREDEPART", dateHeureDepart.Value); // 14/03/2022 16:27:23
                        maCde.Parameters.AddWithValue("@DATEHEUREARRIVEE", dateHeureArrivee.Value);
                        Int32 nbLignes = Convert.ToInt32(maCde.ExecuteNonQuery());
                        MessageBox.Show("Nombre de ligne insérée dans la table 'traversee' : " + nbLignes.ToString(), "Insertion confirmée !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (MySqlException error)
                    {
                        MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    maCnx.Close();
                }
            }
        }

        private void lbxSecteurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            object noSecteur;
            noSecteur = ((Secteur)(lbxSecteurs.SelectedItem)).GetNoSecteur().ToString();

            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

            try
            {
                cmbLiaison.Items.Clear();
                cmbLiaison.Text = "";
                string requeteLiaison;
                maCnx.Open();
                // FAUT FAIRE UNE JOINTURE (CONFIRMEE PAR LE PROF) ET FAIRE UNE CLASSE SPECIAL POUR VOIR LES RESULTATS DANS LA COMBOLIST
                //VERIFIER LA JOINTURE 
                //SELECT DISTINCT(port.nom), liaison.noport_depart, liaison.noport_arrivee FROM port, liaison WHERE port.nom = liaison.noport_depart AND port.nom = liaison.noport_arrivee AND liaison.nosecteur = 3;
                requeteLiaison = "SELECT pd.nom AS 'port_depart', pa.nom AS 'port_arrivee', noliaison, nosecteur, noport_depart, noport_arrivee, distance FROM liaison, port pd, port pa WHERE pd.noport = liaison.noport_depart AND pa.noport = liaison.noport_arrivee AND nosecteur = @NOSECTEUR";
                var maCdeLiaison = new MySqlCommand(requeteLiaison, maCnx);
                maCdeLiaison.Parameters.AddWithValue("@NOSECTEUR", noSecteur);
                jeuEnr = maCdeLiaison.ExecuteReader();
                while (jeuEnr.Read())
                {
                    Liaison uneLiaison;
                    uneLiaison = new Liaison(jeuEnr["port_depart"].ToString(), jeuEnr["port_arrivee"].ToString(), (int)(jeuEnr["noliaison"]), (int)(jeuEnr["nosecteur"]), (int)(jeuEnr["noport_depart"]), (int)(jeuEnr["noport_arrivee"]), (double)(jeuEnr["distance"]));
                    cmbLiaison.Items.Add(uneLiaison); //.ToString possiblement pas terrible car on doit renseignée un objet et non une chaine de 
                    // caractère mais on cherche a ajoutée uniquement des chaines de caractères dans notre ComboList
                    // FAIRE UNE JOINTURE ENTRE LES PORT ET LIAISON MAIS SUR 2 TABLES SEPAREE GENRE (port pd, port pa) ET FAIRE UNE JOINTURE ENTRE LES DEUX TABLES SUR LES NOPORTDEPART ET ARRIVEE
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }
    }
}
