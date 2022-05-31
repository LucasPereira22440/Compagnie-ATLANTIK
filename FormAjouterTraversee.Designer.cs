
namespace Compagnie_ATLANTIK
{
    partial class FormAjouterTraversee
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
            this.lblNomBateau = new System.Windows.Forms.Label();
            this.cmbNomBateau = new System.Windows.Forms.ComboBox();
            this.lblLiaison = new System.Windows.Forms.Label();
            this.cmbLiaison = new System.Windows.Forms.ComboBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.dateHeureDepart = new System.Windows.Forms.DateTimePicker();
            this.dateHeureArrivee = new System.Windows.Forms.DateTimePicker();
            this.lblHeureDepart = new System.Windows.Forms.Label();
            this.lblHeureArrivee = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSecteurs
            // 
            this.lblSecteurs.AutoSize = true;
            this.lblSecteurs.Location = new System.Drawing.Point(37, 51);
            this.lblSecteurs.Name = "lblSecteurs";
            this.lblSecteurs.Size = new System.Drawing.Size(55, 13);
            this.lblSecteurs.TabIndex = 0;
            this.lblSecteurs.Text = "Secteurs :";
            // 
            // lbxSecteurs
            // 
            this.lbxSecteurs.FormattingEnabled = true;
            this.lbxSecteurs.Location = new System.Drawing.Point(40, 84);
            this.lbxSecteurs.Name = "lbxSecteurs";
            this.lbxSecteurs.Size = new System.Drawing.Size(120, 225);
            this.lbxSecteurs.TabIndex = 1;
            this.lbxSecteurs.SelectedIndexChanged += new System.EventHandler(this.lbxSecteurs_SelectedIndexChanged);
            // 
            // lblNomBateau
            // 
            this.lblNomBateau.AutoSize = true;
            this.lblNomBateau.Location = new System.Drawing.Point(306, 51);
            this.lblNomBateau.Name = "lblNomBateau";
            this.lblNomBateau.Size = new System.Drawing.Size(71, 13);
            this.lblNomBateau.TabIndex = 2;
            this.lblNomBateau.Text = "Nom bateau :";
            // 
            // cmbNomBateau
            // 
            this.cmbNomBateau.FormattingEnabled = true;
            this.cmbNomBateau.Location = new System.Drawing.Point(404, 48);
            this.cmbNomBateau.Name = "cmbNomBateau";
            this.cmbNomBateau.Size = new System.Drawing.Size(121, 21);
            this.cmbNomBateau.TabIndex = 3;
            // 
            // lblLiaison
            // 
            this.lblLiaison.AutoSize = true;
            this.lblLiaison.Location = new System.Drawing.Point(40, 345);
            this.lblLiaison.Name = "lblLiaison";
            this.lblLiaison.Size = new System.Drawing.Size(46, 13);
            this.lblLiaison.TabIndex = 4;
            this.lblLiaison.Text = "Liaison :";
            // 
            // cmbLiaison
            // 
            this.cmbLiaison.FormattingEnabled = true;
            this.cmbLiaison.Location = new System.Drawing.Point(43, 373);
            this.cmbLiaison.Name = "cmbLiaison";
            this.cmbLiaison.Size = new System.Drawing.Size(121, 21);
            this.cmbLiaison.TabIndex = 5;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(423, 391);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 23);
            this.btnAjouter.TabIndex = 6;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // dateHeureDepart
            // 
            this.dateHeureDepart.Location = new System.Drawing.Point(423, 158);
            this.dateHeureDepart.Name = "dateHeureDepart";
            this.dateHeureDepart.Size = new System.Drawing.Size(200, 20);
            this.dateHeureDepart.TabIndex = 7;
            // 
            // dateHeureArrivee
            // 
            this.dateHeureArrivee.Location = new System.Drawing.Point(423, 241);
            this.dateHeureArrivee.Name = "dateHeureArrivee";
            this.dateHeureArrivee.Size = new System.Drawing.Size(200, 20);
            this.dateHeureArrivee.TabIndex = 8;
            // 
            // lblHeureDepart
            // 
            this.lblHeureDepart.AutoSize = true;
            this.lblHeureDepart.Location = new System.Drawing.Point(289, 164);
            this.lblHeureDepart.Name = "lblHeureDepart";
            this.lblHeureDepart.Size = new System.Drawing.Size(111, 13);
            this.lblHeureDepart.TabIndex = 9;
            this.lblHeureDepart.Text = "Date et heure départ :";
            // 
            // lblHeureArrivee
            // 
            this.lblHeureArrivee.AutoSize = true;
            this.lblHeureArrivee.Location = new System.Drawing.Point(287, 247);
            this.lblHeureArrivee.Name = "lblHeureArrivee";
            this.lblHeureArrivee.Size = new System.Drawing.Size(113, 13);
            this.lblHeureArrivee.TabIndex = 10;
            this.lblHeureArrivee.Text = "Date et heure arrivée :";
            // 
            // FormAjouterTraversee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblHeureArrivee);
            this.Controls.Add(this.lblHeureDepart);
            this.Controls.Add(this.dateHeureArrivee);
            this.Controls.Add(this.dateHeureDepart);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.cmbLiaison);
            this.Controls.Add(this.lblLiaison);
            this.Controls.Add(this.cmbNomBateau);
            this.Controls.Add(this.lblNomBateau);
            this.Controls.Add(this.lbxSecteurs);
            this.Controls.Add(this.lblSecteurs);
            this.Name = "FormAjouterTraversee";
            this.Text = "Ajouter une traversée";
            this.Load += new System.EventHandler(this.FormAjouterTraversee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSecteurs;
        private System.Windows.Forms.ListBox lbxSecteurs;
        private System.Windows.Forms.Label lblNomBateau;
        private System.Windows.Forms.ComboBox cmbNomBateau;
        private System.Windows.Forms.Label lblLiaison;
        private System.Windows.Forms.ComboBox cmbLiaison;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.DateTimePicker dateHeureDepart;
        private System.Windows.Forms.DateTimePicker dateHeureArrivee;
        private System.Windows.Forms.Label lblHeureDepart;
        private System.Windows.Forms.Label lblHeureArrivee;
    }
}