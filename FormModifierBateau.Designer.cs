
namespace Compagnie_ATLANTIK
{
    partial class FormModifierBateau
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
            this.lblBateau = new System.Windows.Forms.Label();
            this.cmbBateau = new System.Windows.Forms.ComboBox();
            this.gbxCapacitesMaximales = new System.Windows.Forms.GroupBox();
            this.btnModifier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBateau
            // 
            this.lblBateau.AutoSize = true;
            this.lblBateau.Location = new System.Drawing.Point(13, 13);
            this.lblBateau.Name = "lblBateau";
            this.lblBateau.Size = new System.Drawing.Size(71, 13);
            this.lblBateau.TabIndex = 0;
            this.lblBateau.Text = "Nom bateau :";
            // 
            // cmbBateau
            // 
            this.cmbBateau.FormattingEnabled = true;
            this.cmbBateau.Location = new System.Drawing.Point(122, 10);
            this.cmbBateau.Name = "cmbBateau";
            this.cmbBateau.Size = new System.Drawing.Size(121, 21);
            this.cmbBateau.TabIndex = 1;
            this.cmbBateau.SelectedIndexChanged += new System.EventHandler(this.cmbBateau_SelectedIndexChanged);
            // 
            // gbxCapacitesMaximales
            // 
            this.gbxCapacitesMaximales.Location = new System.Drawing.Point(428, 62);
            this.gbxCapacitesMaximales.Name = "gbxCapacitesMaximales";
            this.gbxCapacitesMaximales.Size = new System.Drawing.Size(303, 206);
            this.gbxCapacitesMaximales.TabIndex = 2;
            this.gbxCapacitesMaximales.TabStop = false;
            this.gbxCapacitesMaximales.Text = "Capacités Maximales";
            this.gbxCapacitesMaximales.Enter += new System.EventHandler(this.gbxCapacitesMaximales_Enter);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(144, 264);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(75, 23);
            this.btnModifier.TabIndex = 3;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // FormModifierBateau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.gbxCapacitesMaximales);
            this.Controls.Add(this.cmbBateau);
            this.Controls.Add(this.lblBateau);
            this.Name = "FormModifierBateau";
            this.Text = "Modifier un bateau";
            this.Load += new System.EventHandler(this.FormModifierBateau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBateau;
        private System.Windows.Forms.ComboBox cmbBateau;
        private System.Windows.Forms.GroupBox gbxCapacitesMaximales;
        private System.Windows.Forms.Button btnModifier;
    }
}