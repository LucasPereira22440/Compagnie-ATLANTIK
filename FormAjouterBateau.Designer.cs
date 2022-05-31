
namespace Compagnie_ATLANTIK
{
    partial class FormAjouterBateau
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
            this.lblNomBateau = new System.Windows.Forms.Label();
            this.tbxNomBateau = new System.Windows.Forms.TextBox();
            this.btnAjouterBateau = new System.Windows.Forms.Button();
            this.gbxCapacitesMaximales = new System.Windows.Forms.GroupBox();
            this.tbxAPassager = new System.Windows.Forms.TextBox();
            this.tbxCVehiculeSuperieur = new System.Windows.Forms.TextBox();
            this.tbxBVehiculeInferieur = new System.Windows.Forms.TextBox();
            this.lblCVehiculeSuperieur = new System.Windows.Forms.Label();
            this.lblBVehiculeInferieur = new System.Windows.Forms.Label();
            this.lblAPassager = new System.Windows.Forms.Label();
            this.gbxCapacitesMaximales.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNomBateau
            // 
            this.lblNomBateau.AutoSize = true;
            this.lblNomBateau.Location = new System.Drawing.Point(69, 30);
            this.lblNomBateau.Name = "lblNomBateau";
            this.lblNomBateau.Size = new System.Drawing.Size(71, 13);
            this.lblNomBateau.TabIndex = 0;
            this.lblNomBateau.Text = "Nom bateau :";
            // 
            // tbxNomBateau
            // 
            this.tbxNomBateau.Location = new System.Drawing.Point(172, 27);
            this.tbxNomBateau.Name = "tbxNomBateau";
            this.tbxNomBateau.Size = new System.Drawing.Size(100, 20);
            this.tbxNomBateau.TabIndex = 1;
            this.tbxNomBateau.TextChanged += new System.EventHandler(this.tbxNomBateau_TextChanged);
            // 
            // btnAjouterBateau
            // 
            this.btnAjouterBateau.Location = new System.Drawing.Point(172, 203);
            this.btnAjouterBateau.Name = "btnAjouterBateau";
            this.btnAjouterBateau.Size = new System.Drawing.Size(100, 23);
            this.btnAjouterBateau.TabIndex = 2;
            this.btnAjouterBateau.Text = "Ajouter";
            this.btnAjouterBateau.UseVisualStyleBackColor = true;
            this.btnAjouterBateau.Click += new System.EventHandler(this.btnAjouterBateau_Click);
            // 
            // gbxCapacitesMaximales
            // 
            this.gbxCapacitesMaximales.Controls.Add(this.tbxAPassager);
            this.gbxCapacitesMaximales.Controls.Add(this.tbxCVehiculeSuperieur);
            this.gbxCapacitesMaximales.Controls.Add(this.tbxBVehiculeInferieur);
            this.gbxCapacitesMaximales.Controls.Add(this.lblCVehiculeSuperieur);
            this.gbxCapacitesMaximales.Controls.Add(this.lblBVehiculeInferieur);
            this.gbxCapacitesMaximales.Controls.Add(this.lblAPassager);
            this.gbxCapacitesMaximales.Location = new System.Drawing.Point(392, 30);
            this.gbxCapacitesMaximales.Name = "gbxCapacitesMaximales";
            this.gbxCapacitesMaximales.Size = new System.Drawing.Size(200, 196);
            this.gbxCapacitesMaximales.TabIndex = 3;
            this.gbxCapacitesMaximales.TabStop = false;
            this.gbxCapacitesMaximales.Text = "Capacités Maximales";
            // 
            // tbxAPassager
            // 
            this.tbxAPassager.Location = new System.Drawing.Point(95, 35);
            this.tbxAPassager.Name = "tbxAPassager";
            this.tbxAPassager.Size = new System.Drawing.Size(100, 20);
            this.tbxAPassager.TabIndex = 6;
            this.tbxAPassager.TextChanged += new System.EventHandler(this.tbxAPassager_TextChanged);
            // 
            // tbxCVehiculeSuperieur
            // 
            this.tbxCVehiculeSuperieur.Location = new System.Drawing.Point(95, 113);
            this.tbxCVehiculeSuperieur.Name = "tbxCVehiculeSuperieur";
            this.tbxCVehiculeSuperieur.Size = new System.Drawing.Size(100, 20);
            this.tbxCVehiculeSuperieur.TabIndex = 5;
            this.tbxCVehiculeSuperieur.TextChanged += new System.EventHandler(this.tbxCVehiculeSuperieur_TextChanged);
            // 
            // tbxBVehiculeInferieur
            // 
            this.tbxBVehiculeInferieur.Location = new System.Drawing.Point(95, 78);
            this.tbxBVehiculeInferieur.Name = "tbxBVehiculeInferieur";
            this.tbxBVehiculeInferieur.Size = new System.Drawing.Size(100, 20);
            this.tbxBVehiculeInferieur.TabIndex = 4;
            this.tbxBVehiculeInferieur.TextChanged += new System.EventHandler(this.tbxBVehiculeInferieur_TextChanged);
            // 
            // lblCVehiculeSuperieur
            // 
            this.lblCVehiculeSuperieur.AutoSize = true;
            this.lblCVehiculeSuperieur.Location = new System.Drawing.Point(2, 120);
            this.lblCVehiculeSuperieur.Name = "lblCVehiculeSuperieur";
            this.lblCVehiculeSuperieur.Size = new System.Drawing.Size(87, 13);
            this.lblCVehiculeSuperieur.TabIndex = 2;
            this.lblCVehiculeSuperieur.Text = "C (Véhi.sup.2m) :";
            // 
            // lblBVehiculeInferieur
            // 
            this.lblBVehiculeInferieur.AutoSize = true;
            this.lblBVehiculeInferieur.Location = new System.Drawing.Point(2, 81);
            this.lblBVehiculeInferieur.Name = "lblBVehiculeInferieur";
            this.lblBVehiculeInferieur.Size = new System.Drawing.Size(81, 13);
            this.lblBVehiculeInferieur.TabIndex = 1;
            this.lblBVehiculeInferieur.Text = "B (Véhi.inf.2m) :";
            // 
            // lblAPassager
            // 
            this.lblAPassager.AutoSize = true;
            this.lblAPassager.Location = new System.Drawing.Point(2, 38);
            this.lblAPassager.Name = "lblAPassager";
            this.lblAPassager.Size = new System.Drawing.Size(73, 13);
            this.lblAPassager.TabIndex = 0;
            this.lblAPassager.Text = "A (Passager) :";
            // 
            // FormAjouterBateau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbxCapacitesMaximales);
            this.Controls.Add(this.btnAjouterBateau);
            this.Controls.Add(this.tbxNomBateau);
            this.Controls.Add(this.lblNomBateau);
            this.Name = "FormAjouterBateau";
            this.Text = "Ajouter un bateau";
            this.Load += new System.EventHandler(this.FormAjouterBateau_Load);
            this.gbxCapacitesMaximales.ResumeLayout(false);
            this.gbxCapacitesMaximales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomBateau;
        private System.Windows.Forms.TextBox tbxNomBateau;
        private System.Windows.Forms.Button btnAjouterBateau;
        private System.Windows.Forms.GroupBox gbxCapacitesMaximales;
        private System.Windows.Forms.TextBox tbxCVehiculeSuperieur;
        private System.Windows.Forms.TextBox tbxBVehiculeInferieur;
        private System.Windows.Forms.Label lblCVehiculeSuperieur;
        private System.Windows.Forms.Label lblBVehiculeInferieur;
        private System.Windows.Forms.Label lblAPassager;
        private System.Windows.Forms.TextBox tbxAPassager;
    }
}