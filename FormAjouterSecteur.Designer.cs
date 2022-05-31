
namespace Compagnie_ATLANTIK
{
    partial class FormAjouterSecteur
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
            this.lblNomSecteur = new System.Windows.Forms.Label();
            this.tbxNomSecteur = new System.Windows.Forms.TextBox();
            this.btnAjouterSecteur = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNomSecteur
            // 
            this.lblNomSecteur.AutoSize = true;
            this.lblNomSecteur.Location = new System.Drawing.Point(41, 51);
            this.lblNomSecteur.Name = "lblNomSecteur";
            this.lblNomSecteur.Size = new System.Drawing.Size(73, 13);
            this.lblNomSecteur.TabIndex = 0;
            this.lblNomSecteur.Text = "Nom secteur :";
            // 
            // tbxNomSecteur
            // 
            this.tbxNomSecteur.Location = new System.Drawing.Point(130, 48);
            this.tbxNomSecteur.Name = "tbxNomSecteur";
            this.tbxNomSecteur.Size = new System.Drawing.Size(100, 20);
            this.tbxNomSecteur.TabIndex = 1;
            this.tbxNomSecteur.TextChanged += new System.EventHandler(this.tbxNomSecteur_TextChanged);
            // 
            // btnAjouterSecteur
            // 
            this.btnAjouterSecteur.Location = new System.Drawing.Point(145, 100);
            this.btnAjouterSecteur.Name = "btnAjouterSecteur";
            this.btnAjouterSecteur.Size = new System.Drawing.Size(75, 23);
            this.btnAjouterSecteur.TabIndex = 2;
            this.btnAjouterSecteur.Text = "Ajouter";
            this.btnAjouterSecteur.UseVisualStyleBackColor = true;
            this.btnAjouterSecteur.Click += new System.EventHandler(this.btnAjouterSecteur_Click);
            // 
            // FormAjouterSecteur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 155);
            this.Controls.Add(this.btnAjouterSecteur);
            this.Controls.Add(this.tbxNomSecteur);
            this.Controls.Add(this.lblNomSecteur);
            this.Name = "FormAjouterSecteur";
            this.Text = "Ajouter un secteur";
            this.Load += new System.EventHandler(this.FormAjouterSecteur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomSecteur;
        private System.Windows.Forms.TextBox tbxNomSecteur;
        private System.Windows.Forms.Button btnAjouterSecteur;
    }
}