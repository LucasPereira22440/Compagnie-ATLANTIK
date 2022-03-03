
namespace Compagnie_ATLANTIK
{
    partial class FormAccueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.mmAccueil = new System.Windows.Forms.MenuStrip();
            this.miAjouter = new System.Windows.Forms.ToolStripMenuItem();
            this.miAjouterSecteur = new System.Windows.Forms.ToolStripMenuItem();
            this.miAjouterPort = new System.Windows.Forms.ToolStripMenuItem();
            this.miAjouterLiaison = new System.Windows.Forms.ToolStripMenuItem();
            this.miAjouterTarifs = new System.Windows.Forms.ToolStripMenuItem();
            this.miAjouterBateau = new System.Windows.Forms.ToolStripMenuItem();
            this.miAjouterTraversee = new System.Windows.Forms.ToolStripMenuItem();
            this.miModifier = new System.Windows.Forms.ToolStripMenuItem();
            this.miModifierBateau = new System.Windows.Forms.ToolStripMenuItem();
            this.miModifierParametres = new System.Windows.Forms.ToolStripMenuItem();
            this.miAfficher = new System.Windows.Forms.ToolStripMenuItem();
            this.miAfficherTraversees = new System.Windows.Forms.ToolStripMenuItem();
            this.miAfficherReservation = new System.Windows.Forms.ToolStripMenuItem();
            this.miAPropos = new System.Windows.Forms.ToolStripMenuItem();
            this.mmAccueil.SuspendLayout();
            this.SuspendLayout();
            // 
            // mmAccueil
            // 
            this.mmAccueil.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAjouter,
            this.miModifier,
            this.miAfficher,
            this.miAPropos});
            this.mmAccueil.Location = new System.Drawing.Point(0, 0);
            this.mmAccueil.Name = "mmAccueil";
            this.mmAccueil.Size = new System.Drawing.Size(800, 24);
            this.mmAccueil.TabIndex = 0;
            this.mmAccueil.Text = "Menu Accueil";
            // 
            // miAjouter
            // 
            this.miAjouter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAjouterSecteur,
            this.miAjouterPort,
            this.miAjouterLiaison,
            this.miAjouterTarifs,
            this.miAjouterBateau,
            this.miAjouterTraversee});
            this.miAjouter.Name = "miAjouter";
            this.miAjouter.Size = new System.Drawing.Size(58, 20);
            this.miAjouter.Text = "Ajouter";
            // 
            // miAjouterSecteur
            // 
            this.miAjouterSecteur.Name = "miAjouterSecteur";
            this.miAjouterSecteur.Size = new System.Drawing.Size(287, 22);
            this.miAjouterSecteur.Text = "Un secteur";
            this.miAjouterSecteur.Click += new System.EventHandler(this.miAjouterSecteur_Click);
            // 
            // miAjouterPort
            // 
            this.miAjouterPort.Name = "miAjouterPort";
            this.miAjouterPort.Size = new System.Drawing.Size(287, 22);
            this.miAjouterPort.Text = "Un port";
            this.miAjouterPort.Click += new System.EventHandler(this.miAjouterPort_Click);
            // 
            // miAjouterLiaison
            // 
            this.miAjouterLiaison.Name = "miAjouterLiaison";
            this.miAjouterLiaison.Size = new System.Drawing.Size(287, 22);
            this.miAjouterLiaison.Text = "Une liaison";
            this.miAjouterLiaison.Click += new System.EventHandler(this.miAjouterLiaison_Click);
            // 
            // miAjouterTarifs
            // 
            this.miAjouterTarifs.Name = "miAjouterTarifs";
            this.miAjouterTarifs.Size = new System.Drawing.Size(287, 22);
            this.miAjouterTarifs.Text = "Les tarifs pour une liaison et une période";
            // 
            // miAjouterBateau
            // 
            this.miAjouterBateau.Name = "miAjouterBateau";
            this.miAjouterBateau.Size = new System.Drawing.Size(287, 22);
            this.miAjouterBateau.Text = "Un bateau";
            // 
            // miAjouterTraversee
            // 
            this.miAjouterTraversee.Name = "miAjouterTraversee";
            this.miAjouterTraversee.Size = new System.Drawing.Size(287, 22);
            this.miAjouterTraversee.Text = "Une traversée";
            // 
            // miModifier
            // 
            this.miModifier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miModifierBateau,
            this.miModifierParametres});
            this.miModifier.Name = "miModifier";
            this.miModifier.Size = new System.Drawing.Size(64, 20);
            this.miModifier.Text = "Modifier";
            // 
            // miModifierBateau
            // 
            this.miModifierBateau.Name = "miModifierBateau";
            this.miModifierBateau.Size = new System.Drawing.Size(191, 22);
            this.miModifierBateau.Text = "Un bateau";
            // 
            // miModifierParametres
            // 
            this.miModifierParametres.Name = "miModifierParametres";
            this.miModifierParametres.Size = new System.Drawing.Size(191, 22);
            this.miModifierParametres.Text = "Les paramètres du site";
            // 
            // miAfficher
            // 
            this.miAfficher.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAfficherTraversees,
            this.miAfficherReservation});
            this.miAfficher.Name = "miAfficher";
            this.miAfficher.Size = new System.Drawing.Size(61, 20);
            this.miAfficher.Text = "Afficher";
            // 
            // miAfficherTraversees
            // 
            this.miAfficherTraversees.Name = "miAfficherTraversees";
            this.miAfficherTraversees.Size = new System.Drawing.Size(519, 22);
            this.miAfficherTraversees.Text = "Les traversées pour une liaison et une date donnée avec place restantes par catég" +
    "orie";
            // 
            // miAfficherReservation
            // 
            this.miAfficherReservation.Name = "miAfficherReservation";
            this.miAfficherReservation.Size = new System.Drawing.Size(519, 22);
            this.miAfficherReservation.Text = "Les détails d\'une réservation pour un client";
            // 
            // miAPropos
            // 
            this.miAPropos.Name = "miAPropos";
            this.miAPropos.Size = new System.Drawing.Size(67, 20);
            this.miAPropos.Text = "A Propos";
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mmAccueil);
            this.MainMenuStrip = this.mmAccueil;
            this.Name = "FormAccueil";
            this.Text = "Atlantik - Accueil";
            this.Load += new System.EventHandler(this.FormAccueil_Load);
            this.mmAccueil.ResumeLayout(false);
            this.mmAccueil.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mmAccueil;
        private System.Windows.Forms.ToolStripMenuItem miAjouter;
        private System.Windows.Forms.ToolStripMenuItem miAjouterSecteur;
        private System.Windows.Forms.ToolStripMenuItem miAjouterPort;
        private System.Windows.Forms.ToolStripMenuItem miAjouterLiaison;
        private System.Windows.Forms.ToolStripMenuItem miAjouterTarifs;
        private System.Windows.Forms.ToolStripMenuItem miAjouterBateau;
        private System.Windows.Forms.ToolStripMenuItem miAjouterTraversee;
        private System.Windows.Forms.ToolStripMenuItem miModifier;
        private System.Windows.Forms.ToolStripMenuItem miModifierBateau;
        private System.Windows.Forms.ToolStripMenuItem miModifierParametres;
        private System.Windows.Forms.ToolStripMenuItem miAfficher;
        private System.Windows.Forms.ToolStripMenuItem miAfficherTraversees;
        private System.Windows.Forms.ToolStripMenuItem miAfficherReservation;
        private System.Windows.Forms.ToolStripMenuItem miAPropos;
    }
}

