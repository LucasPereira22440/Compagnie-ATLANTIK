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
    public partial class FormDetailReservation : Form
    {
        public FormDetailReservation()
        {
            InitializeComponent();
        }

        private void FormDetailReservation_Load(object sender, EventArgs e)
        {
            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requete;
                maCnx.Open();

                requete = "SELECT * FROM client";
                var maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();
                while (jeuEnr.Read())
                {
                    Client unClient;
                    unClient = new Client((int)(jeuEnr["noclient"]), jeuEnr["nom"].ToString(), jeuEnr["prenom"].ToString(), jeuEnr["adresse"].ToString(), (int)(jeuEnr["codepostal"]), jeuEnr["ville"].ToString(), jeuEnr["telephonefixe"].ToString(), jeuEnr["telephonemobile"].ToString(), jeuEnr["mel"].ToString(), jeuEnr["motdepasse"].ToString());
                    cmbNomPrenom.Items.Add(unClient);
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();

            lvDetailReservation.View = View.Details;
            lvDetailReservation.GridLines = true;
            lvDetailReservation.FullRowSelect = true;

            lvDetailReservation.Columns.Add("n° Réservation", 90);
            lvDetailReservation.Columns.Add("Liaison", 110);
            lvDetailReservation.Columns.Add("n° Traversée", 90);
            lvDetailReservation.Columns.Add("Date départ", 164);
        }

        private void cmbNomPrenom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si je sélectionne un client, alors je vais devoir remplir la ListView correspondant au client adéquat.

            //int noclient;
            //noclient = ((Client)(cmbNomPrenom.SelectedItem)).GetNoClient();

            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                // Pour éviter les doublons lorsqu'on choisit le même client, on obtiendra qu'une seule sortie sur l'affichage de la ListView
                lvDetailReservation.Items.Clear();
                //string requete;
                //maCnx.Open();

                // Ici, on souhaite afficher toutes les réservations effectuée par notre client dans la ListView.
                //requete = "SELECT DISTINCT(pd.nom) AS 'Port Départ', pa.nom AS 'Port Arrivée', dateheuredepart, dateheure, noreservation, reservation.notraversee, noclient, montanttotal, paye, modereglement FROM reservation, liaison, traversee, port pa, port pd WHERE reservation.notraversee = traversee.noliaison AND traversee.noliaison = liaison.noliaison AND pd.noport = liaison.noport_depart AND pa.noport = liaison.noport_arrivee AND reservation.notraversee = traversee.notraversee AND reservation.noclient = @NOCLIENT";
                //var maCde = new MySqlCommand(requete, maCnx);
                //maCde.Parameters.AddWithValue("@NOCLIENT", noclient);

                //jeuEnr = maCde.ExecuteReader();
                string requete;
                maCnx.Open();

                // Ici, on souhaite afficher toutes les réservations effectuée par notre client dans la ListView.
                requete = "SELECT reservation.noreservation AS 'n° Réservation', pd.nom AS 'Port Départ', pa.nom AS 'Port Arrivée', reservation.notraversee AS 'n° Traversée', traversee.dateheuredepart AS 'Date Départ', reservation.noclient, reservation.dateheure, reservation.montanttotal, reservation.paye, reservation.modereglement FROM reservation, port pd, port pa, liaison, traversee WHERE pd.noport = liaison.noport_depart AND pa.noport = liaison.noport_arrivee AND liaison.noliaison = @NOLIAISON AND reservation.noreservation = @NORESERVATION AND traversee.notraversee = @NOTRAVERSEE;";
                var maCde = new MySqlCommand(requete, maCnx);
                maCde.Parameters.AddWithValue("@NOLIAISON", "");
                maCde.Parameters.AddWithValue("@NORESERVATION", "");
                maCde.Parameters.AddWithValue("@NOTRAVERSEE", "");

                jeuEnr = maCde.ExecuteReader();

                var tabItem = new string[4];
                ListViewItem unItem;
                while (jeuEnr.Read())
                {
                    Reservation uneReservation;
                    uneReservation = new Reservation((int)(jeuEnr["n° Réservation"]), (int)(jeuEnr["n° Traversée"]), (int)(jeuEnr["noclient"]), (DateTime)(jeuEnr["dateheure"]), (double)(jeuEnr["montanttotal"]), (bool)(jeuEnr["paye"]), jeuEnr["modereglement"].ToString());
                    tabItem[0] = uneReservation.GetNoReservation().ToString();
                    //tabItem[1] = uneReservation.ToString(); // A MODIFIER
                    tabItem[1] = jeuEnr["Port Départ"].ToString() + " - " + jeuEnr["Port Arrivée"].ToString();
                    tabItem[2] = uneReservation.GetNoTraversee().ToString();
                    string dateheuredepart = jeuEnr["Date Départ"].ToString();
                    string[] date;
                    date = dateheuredepart.Split(' ');
                    tabItem[3] = date[0] + " à " + date[1];
                    unItem = new ListViewItem(tabItem);
                    lvDetailReservation.Items.Add(unItem);
                }
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }

        private void lvDetailReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Quand je choisis un détail pour une réservation d'un client, je vais afficher les détails correspondants
            int noreservation = 1;
            //noreservation = ((Reservation)(lvDetailReservation.SelectedItems)).GetNoReservation();

            MySqlConnection maCnx;
            MySqlDataReader jeuEnr = null;

            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                gbxReservation.Controls.Clear();
                string requête;
                maCnx.Open();

                requête = "SELECT type.libelle, enregistrer.quantite, reservation.montanttotal, reservation.paye, reservation.modereglement FROM enregistrer, type, reservation WHERE type.notype = enregistrer.notype AND type.lettrecategorie = enregistrer.lettrecategorie AND enregistrer.noreservation = reservation.noreservation AND reservation.noreservation = @NORESERVATION";

                var maCde = new MySqlCommand(requête, maCnx);
                maCde.Parameters.AddWithValue("@NORESERVATION", noreservation);
                jeuEnr = maCde.ExecuteReader();
                int i = 0;
                while (jeuEnr.Read())
                {
                    Label lblReservationInfo;
                    lblReservationInfo = new Label();
                    lblReservationInfo.Text = jeuEnr["libelle"].ToString();
                    lblReservationInfo.Location = new Point(0, i * 25);
                    gbxReservation.Controls.Add(lblReservationInfo);

                    Label lblReservationNombre;
                    lblReservationNombre = new Label();
                    lblReservationNombre.Text = " : " + jeuEnr["quantite"].ToString();
                    lblReservationNombre.Location = new Point(100, i * 25);
                    gbxReservation.Controls.Add(lblReservationNombre);

                    i += 1;
                }

                Label lblReservationMontantNombre;
                lblReservationMontantNombre = new Label();
                lblReservationMontantNombre.Text = jeuEnr["montanttotal"].ToString() + " euros";
                lblReservationMontantNombre.Location = new Point(100, i * 25);
                gbxReservation.Controls.Add(lblReservationMontantNombre);

                Label lblReservationMontantInfo;
                lblReservationMontantInfo = new Label();
                lblReservationMontantInfo.Text = "Montant total : ";
                lblReservationMontantInfo.Location = new Point(0, i * 25);
                gbxReservation.Controls.Add(lblReservationMontantInfo);

                i += 1;

                if ((bool)(jeuEnr["paye"]) == true)
                {
                    Label lblPaye;
                    lblPaye = new Label();
                    lblPaye.Text = "Réglé" + " " + jeuEnr["modereglement"].ToString();
                    lblPaye.Location = new Point(0, i * 25);
                    gbxReservation.Controls.Add(lblPaye);
                }
                
            } catch (MySqlException error)
            {
                MessageBox.Show("Erreur général de la base de données, voici l'erreur : " + error.ToString(), "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            maCnx.Close();
        }
    }
}
