
namespace Compagnie_ATLANTIK
{
    partial class FormDetailReservation
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
            this.lblNomPrenom = new System.Windows.Forms.Label();
            this.cmbNomPrenom = new System.Windows.Forms.ComboBox();
            this.lvDetailReservation = new System.Windows.Forms.ListView();
            this.gbxReservation = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lblNomPrenom
            // 
            this.lblNomPrenom.AutoSize = true;
            this.lblNomPrenom.Location = new System.Drawing.Point(12, 32);
            this.lblNomPrenom.Name = "lblNomPrenom";
            this.lblNomPrenom.Size = new System.Drawing.Size(77, 13);
            this.lblNomPrenom.TabIndex = 0;
            this.lblNomPrenom.Text = "Nom, Prénom :";
            // 
            // cmbNomPrenom
            // 
            this.cmbNomPrenom.FormattingEnabled = true;
            this.cmbNomPrenom.Location = new System.Drawing.Point(106, 29);
            this.cmbNomPrenom.Name = "cmbNomPrenom";
            this.cmbNomPrenom.Size = new System.Drawing.Size(121, 21);
            this.cmbNomPrenom.TabIndex = 1;
            this.cmbNomPrenom.SelectedIndexChanged += new System.EventHandler(this.cmbNomPrenom_SelectedIndexChanged);
            // 
            // lvDetailReservation
            // 
            this.lvDetailReservation.HideSelection = false;
            this.lvDetailReservation.Location = new System.Drawing.Point(341, 29);
            this.lvDetailReservation.Name = "lvDetailReservation";
            this.lvDetailReservation.Size = new System.Drawing.Size(447, 146);
            this.lvDetailReservation.TabIndex = 2;
            this.lvDetailReservation.UseCompatibleStateImageBehavior = false;
            this.lvDetailReservation.SelectedIndexChanged += new System.EventHandler(this.lvDetailReservation_SelectedIndexChanged);
            // 
            // gbxReservation
            // 
            this.gbxReservation.Location = new System.Drawing.Point(341, 201);
            this.gbxReservation.Name = "gbxReservation";
            this.gbxReservation.Size = new System.Drawing.Size(200, 221);
            this.gbxReservation.TabIndex = 3;
            this.gbxReservation.TabStop = false;
            this.gbxReservation.Text = "Réservation";
            // 
            // FormDetailReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbxReservation);
            this.Controls.Add(this.lvDetailReservation);
            this.Controls.Add(this.cmbNomPrenom);
            this.Controls.Add(this.lblNomPrenom);
            this.Name = "FormDetailReservation";
            this.Text = "Détail de réservation";
            this.Load += new System.EventHandler(this.FormDetailReservation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomPrenom;
        private System.Windows.Forms.ComboBox cmbNomPrenom;
        private System.Windows.Forms.ListView lvDetailReservation;
        private System.Windows.Forms.GroupBox gbxReservation;
    }
}