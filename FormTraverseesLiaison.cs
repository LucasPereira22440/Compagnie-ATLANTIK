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
    public partial class FormTraverseesLiaison : Form
    {
        public FormTraverseesLiaison()
        {
            InitializeComponent();
        }

        // Permet de savoir le nombre de reservation sur une traversée et de sa catégorie précise.
        int getQuantiteEnregistree(int noTraversee, string lettreCategorie)
        {
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requête;
                maCnx.Open();

                requête = "SELECT COUNT(*) FROM traversee, reservation, enregistrer WHERE traversee.notraversee = reservation.notraversee AND reservation.noreservation = enregistrer.noreservation AND traversee.notraversee = @NOTRAVERSEE AND enregistrer.lettrecategorie = @LETTRECATEGORIE";

                var maCde = new MySqlCommand(requête, maCnx);

                maCde.Parameters.AddWithValue("@NOTRAVERSEE", noTraversee);
                maCde.Parameters.AddWithValue("@LETTRECATEGORIE", lettreCategorie);

                Int32 nbQuantiteEnregistree = Convert.ToInt32(maCde.ExecuteScalar());

                maCnx.Close();

                return nbQuantiteEnregistree;

            } catch (MySqlException error)
            {
                // - 1 correspond à l'erreur de l'excution de la méthode.
                maCnx.Close();
                return -1;
            }
        }

        // Permet d'avoir la capaité maximal du bateau en fonction de 'lettreCategorie' avec sa traversee correspondante pour savoir le nombre de place réservée plus tard.
        int getCapaciteMaximale(int noTraversee, string lettreCategorie)
        {
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requête;
                maCnx.Open();

                requête = "SELECT contenir.capacitemax FROM contenir, bateau, traversee WHERE contenir.nobateau = bateau.nobateau AND bateau.nobateau = traversee.nobateau AND contenir.lettrecategorie = @LETTRECATEGORIE AND traversee.notraversee = @NOTRAVERSEE";

                var maCde = new MySqlCommand(requête, maCnx);

                maCde.Parameters.AddWithValue("@NOTRAVERSEE", noTraversee);
                maCde.Parameters.AddWithValue("@LETTRECATEGORIE", lettreCategorie);

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    return (int)(jeuEnr["capacitemax"]);
                }

                maCnx.Close();

                return 0;

            } catch (MySqlException error)
            {
                maCnx.Close();
                return -1;
            }
        }

        // Fonction permettant de lister toute les catégories dans la table 'categorie' afin de rendre la ListView dynamique pour les colonnes : On affiche autant de colonne que de nombre de ligne de la table
        // 'categorie'
        string getLesCategories()
        {
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requête;
                string chaine = "";
                maCnx.Open();

                requête = "SELECT * FROM categorie";
                var maCde = new MySqlCommand(requête, maCnx);
                jeuEnr = maCde.ExecuteReader();
                while (jeuEnr.Read())
                {
                    chaine = chaine + jeuEnr["lettrecategorie"].ToString() + " " + jeuEnr["libelle"].ToString() + "/";
                }
                maCnx.Close();
                return chaine;

            } catch (MySqlException error)
            {
                maCnx.Close();
                string estVide = "";
                return estVide;
            }
        }

        // Fonction permettant de retourner les numéros de bateau, l'heure et les nom de bateau en fonction de la noLiaison et de la dateheuredepart
        string getLesTraverseesBateaux(int noLiaison, string dateTraversee)
        {
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requête;
                string chaine = "";
                maCnx.Open();

                requête = "SELECT traversee.notraversee AS 'N°', traversee.dateheuredepart AS 'Heure', bateau.nom AS 'Nom bateau' FROM traversee, bateau WHERE bateau.nobateau = traversee.nobateau AND traversee.noliaison = @NOLIAISON AND traversee.dateheuredepart LIKE @DATEHEUREDEPART";
                var maCde = new MySqlCommand(requête, maCnx);
                maCde.Parameters.AddWithValue("@NOLIAISON", noLiaison);
                maCde.Parameters.AddWithValue("@DATEHEUREDEPART", "2021-07-10" + "%"); //dateTraversee + "%"
                jeuEnr = maCde.ExecuteReader();
                while (jeuEnr.Read())
                {
                    chaine = chaine + jeuEnr["N°"].ToString() + " " + jeuEnr["Heure"].ToString() + " " + jeuEnr["Nom bateau"].ToString() + "&";
                }
                maCnx.Close();
                return chaine;
            } catch (MySqlException error)
            {
                maCnx.Close();
                return "";
            }
        }
        private void FormTraverseesLiaison_Load(object sender, EventArgs e)
        {
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requête;
                maCnx.Open();

                requête = "SELECT * FROM secteur";

                var maCde = new MySqlCommand(requête, maCnx);

                jeuEnr = maCde.ExecuteReader();
                while (jeuEnr.Read())
                {
                    Secteur unSecteur;
                    unSecteur = new Secteur((int)(jeuEnr["nosecteur"]), jeuEnr["nom"].ToString());
                    lbxSecteurs.Items.Add(unSecteur);
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général dans la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }

        private void cmbLiaison_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lbxSecteurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                cmbLiaison.Items.Clear();
                int nosecteur;
                nosecteur = ((Secteur)(lbxSecteurs.SelectedItem)).GetNoSecteur();

                string requête;
                maCnx.Open();

                requête = "SELECT pd.nom AS 'Port Départ', pa.nom AS 'Port Arrivée', liaison.nosecteur, liaison.noport_depart, liaison.noport_arrivee, liaison.distance, liaison.noliaison FROM port pd, port pa, liaison WHERE pd.noport = liaison.noport_depart AND pa.noport = liaison.noport_arrivee AND liaison.nosecteur = @NOSECTEUR";

                var maCde = new MySqlCommand(requête, maCnx);
                maCde.Parameters.AddWithValue("@NOSECTEUR", nosecteur);

                jeuEnr = maCde.ExecuteReader();
                while (jeuEnr.Read())
                {
                    Liaison uneLiaison;
                    uneLiaison = new Liaison(jeuEnr["Port Départ"].ToString(), jeuEnr["Port Arrivée"].ToString(), (int)(jeuEnr["noliaison"]), (int)(jeuEnr["nosecteur"]), (int)(jeuEnr["noport_depart"]), (int)(jeuEnr["noport_arrivee"]), (double)(jeuEnr["distance"]));
                    cmbLiaison.Items.Add(uneLiaison);
                }
            }
            catch (MySqlException error)
            {
                MessageBox.Show("Erreur général dans la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }

        private void btnAfficherTraversees_Click(object sender, EventArgs e)
        {
            // Quand on clique sur le bouton 'Afficher les traversées' on va afficher les traversées correspondante au secteur et au liaison choisis par l'utilisateur.
            if (lbxSecteurs.Text == "" | cmbLiaison.Text == "")
            {
                // Si l'utilisateur n'a pas choisis de secteur ou de liaison alors on indique qu'il faut qu'il choisit un secteur ou une liaison.
                MessageBox.Show("Aucun secteur ou aucune liaison ont été sélectionner, veuillez choisir un secteur ainsi qu'une liaison pour afficher les traversées.", "Affichage impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                // Si tout est OK, alors on complète l'affichage du tableau !
                MySqlConnection maCnx;
                MySqlDataReader jeuEnr = null;

                maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                try
                {
                    lvAfficherTraversees.Items.Clear();
                    lvAfficherTraversees.Columns.Clear();
                    int noliaison;
                    noliaison = ((Liaison)(cmbLiaison.SelectedItem)).GetNoLiaison();
                    //string requête;
                    //maCnx.Open();

                    //requête = "SELECT traversee.notraversee, bateau.nom, traversee.dateheuredepart FROM secteur, liaison, traversee, bateau WHERE secteur.nosecteur = liaison.noliaison AND liaison.noliaison = traversee.noliaison AND bateau.nobateau = traversee.nobateau AND liaison.noliaison = @NOLIAISON AND traversee.dateheuredepart LIKE @DATEHEUREDEPART";

                    //var maCde = new MySqlCommand(requête, maCnx);
                    //maCde.Parameters.AddWithValue("@NOLIAISON", noliaison);
                    //maCde.Parameters.AddWithValue("@DATEHEUREDEPART", "2021-07-10" + "%"); // 2021-07-10%
                    //maCde.Parameters.AddWithValue("@DATEHEUREDEPART", dateDateJour.Value.Date + "%");

                    //jeuEnr = maCde.ExecuteReader();
                    string colonnePlaceDispo;
                    lvAfficherTraversees.View = View.Details;
                    lvAfficherTraversees.GridLines = true;
                    lvAfficherTraversees.FullRowSelect = true;

                    lvAfficherTraversees.Columns.Add("N°", 50);
                    lvAfficherTraversees.Columns.Add("Heure", 60);
                    lvAfficherTraversees.Columns.Add("Bateau", 60);

                    // Appel de la fonction getLesCategorie() pour lister toutes les categories existantes
                    colonnePlaceDispo = getLesCategories();
                    string[] uneColonnePlaceDispo;
                    uneColonnePlaceDispo = colonnePlaceDispo.Split('/'); // On va séparer les éléments grâce au '/' créer dans la chaine lors de l'appel de la fonction

                    // Permet de rendre le tableau dynamique : on rajoutera autant de colonne que ligne dans la table 'categorie' dans le SGBDR
                    for (int noColonne = 0; noColonne < uneColonnePlaceDispo.Length - 1; noColonne++)
                    {
                        lvAfficherTraversees.Columns.Add(uneColonnePlaceDispo[noColonne], 100);
                    }

                    //var tabITem = new string[3 + uneColonnePlaceDispo.Length]; // Nombre de ligne a insérée.
                    var tabITem = new string[31];
                    ListViewItem unItem;

                    string infoTraversee;
                    infoTraversee = getLesTraverseesBateaux(noliaison, dateDateJour.Value.Date.ToString("d"));
                    string[] caseInfoTraversee;
                    caseInfoTraversee = infoTraversee.Split('&');
                }
                //while (jeuEnr.Read())
                //{
                //string ligne = jeuEnr["dateheuredepart"].ToString();
                //string[] champs;
                //champs = ligne.Split(' ');

                //tabITem[0] = jeuEnr["notraversee"].ToString(); // UTILISER FONCTION GETLESTRAVERSEESBATEAU()
                //tabITem[1] = champs[1]; // UTILISER FONCTION GETLESTRAVERSEESBATEAU()
                //tabITem[2] = jeuEnr["nom"].ToString(); // UTILISER FONCTION GETLESTRAVERSEESBATEAU()
                // DYNAMIQUE
                //int placeReserveeA = getCapaciteMaximale((int)(jeuEnr["notraversee"]), "A") - getQuantiteEnregistree((int)(jeuEnr["notraversee"]), "A");
                //tabITem[3] = placeReserveeA.ToString();
                //int placeReserveeB = getCapaciteMaximale((int)(jeuEnr["notraversee"]), "B") - getQuantiteEnregistree((int)(jeuEnr["notraversee"]), "B");
                //tabITem[4] = placeReserveeB.ToString();
                //int placeReserveeC = getCapaciteMaximale((int)(jeuEnr["notraversee"]), "C") - getQuantiteEnregistree((int)(jeuEnr["notraversee"]), "C");
                //tabITem[5] = placeReserveeC.ToString();

                //unItem = new ListViewItem(tabITem);
                //lvAfficherTraversees.Items.Add(unItem);
                //}
                //}
                catch (MySqlException error)
                {
                    MessageBox.Show("Erreur général dans la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //maCnx.Close();
            }
        }
    }
}
