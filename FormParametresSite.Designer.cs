
namespace Compagnie_ATLANTIK
{
    partial class FormParametresSite
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
            this.lblSite = new System.Windows.Forms.Label();
            this.lblRang = new System.Windows.Forms.Label();
            this.lblIdentifiant = new System.Windows.Forms.Label();
            this.lblCleHMAC = new System.Windows.Forms.Label();
            this.gbxParametresSite = new System.Windows.Forms.GroupBox();
            this.tbxCleHMAC = new System.Windows.Forms.RichTextBox();
            this.tbxIdentifiant = new System.Windows.Forms.TextBox();
            this.tbxRang = new System.Windows.Forms.TextBox();
            this.tbxSite = new System.Windows.Forms.TextBox();
            this.btnModifier = new System.Windows.Forms.Button();
            this.cbxEnProduction = new System.Windows.Forms.CheckBox();
            this.lblMelSite = new System.Windows.Forms.Label();
            this.tbxMelSite = new System.Windows.Forms.TextBox();
            this.gbxParametresSite.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(31, 50);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(31, 13);
            this.lblSite.TabIndex = 0;
            this.lblSite.Text = "Site :";
            // 
            // lblRang
            // 
            this.lblRang.AutoSize = true;
            this.lblRang.Location = new System.Drawing.Point(31, 91);
            this.lblRang.Name = "lblRang";
            this.lblRang.Size = new System.Drawing.Size(39, 13);
            this.lblRang.TabIndex = 1;
            this.lblRang.Text = "Rang :";
            // 
            // lblIdentifiant
            // 
            this.lblIdentifiant.AutoSize = true;
            this.lblIdentifiant.Location = new System.Drawing.Point(31, 133);
            this.lblIdentifiant.Name = "lblIdentifiant";
            this.lblIdentifiant.Size = new System.Drawing.Size(59, 13);
            this.lblIdentifiant.TabIndex = 2;
            this.lblIdentifiant.Text = "Identifiant :";
            // 
            // lblCleHMAC
            // 
            this.lblCleHMAC.AutoSize = true;
            this.lblCleHMAC.Location = new System.Drawing.Point(31, 178);
            this.lblCleHMAC.Name = "lblCleHMAC";
            this.lblCleHMAC.Size = new System.Drawing.Size(62, 13);
            this.lblCleHMAC.TabIndex = 3;
            this.lblCleHMAC.Text = "Clé HMAC :";
            // 
            // gbxParametresSite
            // 
            this.gbxParametresSite.Controls.Add(this.tbxCleHMAC);
            this.gbxParametresSite.Controls.Add(this.tbxIdentifiant);
            this.gbxParametresSite.Controls.Add(this.tbxRang);
            this.gbxParametresSite.Controls.Add(this.tbxSite);
            this.gbxParametresSite.Controls.Add(this.lblSite);
            this.gbxParametresSite.Controls.Add(this.lblCleHMAC);
            this.gbxParametresSite.Controls.Add(this.lblRang);
            this.gbxParametresSite.Controls.Add(this.lblIdentifiant);
            this.gbxParametresSite.Location = new System.Drawing.Point(56, 12);
            this.gbxParametresSite.Name = "gbxParametresSite";
            this.gbxParametresSite.Size = new System.Drawing.Size(292, 326);
            this.gbxParametresSite.TabIndex = 4;
            this.gbxParametresSite.TabStop = false;
            this.gbxParametresSite.Text = "Identifiant PayBox";
            // 
            // tbxCleHMAC
            // 
            this.tbxCleHMAC.Location = new System.Drawing.Point(98, 175);
            this.tbxCleHMAC.Name = "tbxCleHMAC";
            this.tbxCleHMAC.Size = new System.Drawing.Size(152, 138);
            this.tbxCleHMAC.TabIndex = 5;
            this.tbxCleHMAC.Text = "";
            // 
            // tbxIdentifiant
            // 
            this.tbxIdentifiant.Location = new System.Drawing.Point(98, 133);
            this.tbxIdentifiant.Name = "tbxIdentifiant";
            this.tbxIdentifiant.Size = new System.Drawing.Size(100, 20);
            this.tbxIdentifiant.TabIndex = 6;
            this.tbxIdentifiant.TextChanged += new System.EventHandler(this.tbxIdentifiant_TextChanged);
            // 
            // tbxRang
            // 
            this.tbxRang.Location = new System.Drawing.Point(98, 91);
            this.tbxRang.Name = "tbxRang";
            this.tbxRang.Size = new System.Drawing.Size(100, 20);
            this.tbxRang.TabIndex = 5;
            this.tbxRang.TextChanged += new System.EventHandler(this.tbxRang_TextChanged);
            // 
            // tbxSite
            // 
            this.tbxSite.Location = new System.Drawing.Point(98, 50);
            this.tbxSite.Name = "tbxSite";
            this.tbxSite.Size = new System.Drawing.Size(100, 20);
            this.tbxSite.TabIndex = 4;
            this.tbxSite.TextChanged += new System.EventHandler(this.tbxSite_TextChanged);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(231, 415);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(75, 23);
            this.btnModifier.TabIndex = 7;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // cbxEnProduction
            // 
            this.cbxEnProduction.AutoSize = true;
            this.cbxEnProduction.Location = new System.Drawing.Point(258, 353);
            this.cbxEnProduction.Name = "cbxEnProduction";
            this.cbxEnProduction.Size = new System.Drawing.Size(92, 17);
            this.cbxEnProduction.TabIndex = 9;
            this.cbxEnProduction.Text = "En production";
            this.cbxEnProduction.UseVisualStyleBackColor = true;
            // 
            // lblMelSite
            // 
            this.lblMelSite.AutoSize = true;
            this.lblMelSite.Location = new System.Drawing.Point(162, 380);
            this.lblMelSite.Name = "lblMelSite";
            this.lblMelSite.Size = new System.Drawing.Size(49, 13);
            this.lblMelSite.TabIndex = 10;
            this.lblMelSite.Text = "Mél site :";
            // 
            // tbxMelSite
            // 
            this.tbxMelSite.Location = new System.Drawing.Point(231, 377);
            this.tbxMelSite.Name = "tbxMelSite";
            this.tbxMelSite.Size = new System.Drawing.Size(117, 20);
            this.tbxMelSite.TabIndex = 11;
            // 
            // FormParametresSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 450);
            this.Controls.Add(this.tbxMelSite);
            this.Controls.Add(this.lblMelSite);
            this.Controls.Add(this.cbxEnProduction);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.gbxParametresSite);
            this.Name = "FormParametresSite";
            this.Text = "Modifier les paramètres du site";
            this.Load += new System.EventHandler(this.FormParametresSite_Load);
            this.gbxParametresSite.ResumeLayout(false);
            this.gbxParametresSite.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.Label lblRang;
        private System.Windows.Forms.Label lblIdentifiant;
        private System.Windows.Forms.Label lblCleHMAC;
        private System.Windows.Forms.GroupBox gbxParametresSite;
        private System.Windows.Forms.RichTextBox tbxCleHMAC;
        private System.Windows.Forms.TextBox tbxIdentifiant;
        private System.Windows.Forms.TextBox tbxRang;
        private System.Windows.Forms.TextBox tbxSite;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.CheckBox cbxEnProduction;
        private System.Windows.Forms.Label lblMelSite;
        private System.Windows.Forms.TextBox tbxMelSite;
    }
}