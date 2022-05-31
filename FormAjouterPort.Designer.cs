
namespace Compagnie_ATLANTIK
{
    partial class FormAjouterPort
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
            this.lblNomPort = new System.Windows.Forms.Label();
            this.tbxNomPort = new System.Windows.Forms.TextBox();
            this.btnAjouterPort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNomPort
            // 
            this.lblNomPort.AutoSize = true;
            this.lblNomPort.Location = new System.Drawing.Point(31, 39);
            this.lblNomPort.Name = "lblNomPort";
            this.lblNomPort.Size = new System.Drawing.Size(56, 13);
            this.lblNomPort.TabIndex = 0;
            this.lblNomPort.Text = "Nom port :";
            // 
            // tbxNomPort
            // 
            this.tbxNomPort.Location = new System.Drawing.Point(110, 36);
            this.tbxNomPort.Name = "tbxNomPort";
            this.tbxNomPort.Size = new System.Drawing.Size(100, 20);
            this.tbxNomPort.TabIndex = 1;
            this.tbxNomPort.TextChanged += new System.EventHandler(this.tbxNomPort_TextChanged);
            // 
            // btnAjouterPort
            // 
            this.btnAjouterPort.Location = new System.Drawing.Point(121, 83);
            this.btnAjouterPort.Name = "btnAjouterPort";
            this.btnAjouterPort.Size = new System.Drawing.Size(75, 23);
            this.btnAjouterPort.TabIndex = 2;
            this.btnAjouterPort.Text = "Ajouter";
            this.btnAjouterPort.UseVisualStyleBackColor = true;
            this.btnAjouterPort.Click += new System.EventHandler(this.btnAjouterPort_Click);
            // 
            // FormAjouterPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 126);
            this.Controls.Add(this.btnAjouterPort);
            this.Controls.Add(this.tbxNomPort);
            this.Controls.Add(this.lblNomPort);
            this.Name = "FormAjouterPort";
            this.Text = "Ajouter un port";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomPort;
        private System.Windows.Forms.TextBox tbxNomPort;
        private System.Windows.Forms.Button btnAjouterPort;
    }
}