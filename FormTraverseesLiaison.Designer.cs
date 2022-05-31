
namespace Compagnie_ATLANTIK
{
    partial class FormTraverseesLiaison
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSecteurs = new System.Windows.Forms.Label();
            this.lbxSecteurs = new System.Windows.Forms.ListBox();
            this.lblLiaison = new System.Windows.Forms.Label();
            this.cmbLiaison = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateDateJour = new System.Windows.Forms.DateTimePicker();
            this.btnAfficherTraversees = new System.Windows.Forms.Button();
            this.lvAfficherTraversees = new System.Windows.Forms.ListView();
            this.lblTraversee = new System.Windows.Forms.Label();
            this.lblPlacesDisponibles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSecteurs
            // 
            this.lblSecteurs.AutoSize = true;
            this.lblSecteurs.Location = new System.Drawing.Point(13, 13);
            this.lblSecteurs.Name = "lblSecteurs";
            this.lblSecteurs.Size = new System.Drawing.Size(55, 13);
            this.lblSecteurs.TabIndex = 0;
            this.lblSecteurs.Text = "Secteurs :";
            // 
            // lbxSecteurs
            // 
            this.lbxSecteurs.FormattingEnabled = true;
            this.lbxSecteurs.Location = new System.Drawing.Point(16, 42);
            this.lbxSecteurs.Name = "lbxSecteurs";
            this.lbxSecteurs.Size = new System.Drawing.Size(120, 264);
            this.lbxSecteurs.TabIndex = 1;
            this.lbxSecteurs.SelectedIndexChanged += new System.EventHandler(this.lbxSecteurs_SelectedIndexChanged);
            // 
            // lblLiaison
            // 
            this.lblLiaison.AutoSize = true;
            this.lblLiaison.Location = new System.Drawing.Point(16, 338);
            this.lblLiaison.Name = "lblLiaison";
            this.lblLiaison.Size = new System.Drawing.Size(46, 13);
            this.lblLiaison.TabIndex = 2;
            this.lblLiaison.Text = "Liaison :";
            // 
            // cmbLiaison
            // 
            this.cmbLiaison.FormattingEnabled = true;
            this.cmbLiaison.Location = new System.Drawing.Point(19, 374);
            this.cmbLiaison.Name = "cmbLiaison";
            this.cmbLiaison.Size = new System.Drawing.Size(121, 21);
            this.cmbLiaison.TabIndex = 3;
            this.cmbLiaison.SelectedIndexChanged += new System.EventHandler(this.cmbLiaison_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(418, 55);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(128, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date (par défaut du jour) :";
            // 
            // dateDateJour
            // 
            this.dateDateJour.Location = new System.Drawing.Point(569, 49);
            this.dateDateJour.Name = "dateDateJour";
            this.dateDateJour.Size = new System.Drawing.Size(200, 20);
            this.dateDateJour.TabIndex = 5;
            // 
            // btnAfficherTraversees
            // 
            this.btnAfficherTraversees.Location = new System.Drawing.Point(421, 125);
            this.btnAfficherTraversees.Name = "btnAfficherTraversees";
            this.btnAfficherTraversees.Size = new System.Drawing.Size(174, 23);
            this.btnAfficherTraversees.TabIndex = 6;
            this.btnAfficherTraversees.Text = "Afficher les traversées";
            this.btnAfficherTraversees.UseVisualStyleBackColor = true;
            this.btnAfficherTraversees.Click += new System.EventHandler(this.btnAfficherTraversees_Click);
            // 
            // lvAfficherTraversees
            // 
            this.lvAfficherTraversees.HideSelection = false;
            this.lvAfficherTraversees.Location = new System.Drawing.Point(264, 229);
            this.lvAfficherTraversees.Name = "lvAfficherTraversees";
            this.lvAfficherTraversees.Size = new System.Drawing.Size(510, 186);
            this.lvAfficherTraversees.TabIndex = 7;
            this.lvAfficherTraversees.UseCompatibleStateImageBehavior = false;
            // 
            // lblTraversee
            // 
            this.lblTraversee.AutoSize = true;
            this.lblTraversee.Location = new System.Drawing.Point(264, 198);
            this.lblTraversee.Name = "lblTraversee";
            this.lblTraversee.Size = new System.Drawing.Size(55, 13);
            this.lblTraversee.TabIndex = 8;
            this.lblTraversee.Text = "Traversée";
            // 
            // lblPlacesDisponibles
            // 
            this.lblPlacesDisponibles.AutoSize = true;
            this.lblPlacesDisponibles.Location = new System.Drawing.Point(615, 198);
            this.lblPlacesDisponibles.Name = "lblPlacesDisponibles";
            this.lblPlacesDisponibles.Size = new System.Drawing.Size(159, 13);
            this.lblPlacesDisponibles.TabIndex = 9;
            this.lblPlacesDisponibles.Text = "Places disponibles par catégorie";
            // 
            // FormTraverseesLiaison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPlacesDisponibles);
            this.Controls.Add(this.lblTraversee);
            this.Controls.Add(this.lvAfficherTraversees);
            this.Controls.Add(this.btnAfficherTraversees);
            this.Controls.Add(this.dateDateJour);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbLiaison);
            this.Controls.Add(this.lblLiaison);
            this.Controls.Add(this.lbxSecteurs);
            this.Controls.Add(this.lblSecteurs);
            this.Name = "FormTraverseesLiaison";
            this.Text = "Afficher les traversées pour une liaison et une date donnée avec places restantes" +
    " par catégorie";
            this.Load += new System.EventHandler(this.FormTraverseesLiaison_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSecteurs;
        private System.Windows.Forms.ListBox lbxSecteurs;
        private System.Windows.Forms.Label lblLiaison;
        private System.Windows.Forms.ComboBox cmbLiaison;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateDateJour;
        private System.Windows.Forms.Button btnAfficherTraversees;
        private System.Windows.Forms.ListView lvAfficherTraversees;
        private System.Windows.Forms.Label lblTraversee;
        private System.Windows.Forms.Label lblPlacesDisponibles;
    }
}