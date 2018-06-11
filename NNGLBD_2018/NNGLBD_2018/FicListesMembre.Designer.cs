namespace NNGLBD_2018
{
    partial class EcranListesMembre
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
            this.dgvListeMembre = new System.Windows.Forms.DataGridView();
            this.lblChoixEquipe = new MaterialSkin.Controls.MaterialLabel();
            this.btnListeEqui = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnClose = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cbListeMembre = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeMembre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListeMembre
            // 
            this.dgvListeMembre.AllowUserToAddRows = false;
            this.dgvListeMembre.AllowUserToDeleteRows = false;
            this.dgvListeMembre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListeMembre.Location = new System.Drawing.Point(2, 67);
            this.dgvListeMembre.Name = "dgvListeMembre";
            this.dgvListeMembre.ReadOnly = true;
            this.dgvListeMembre.Size = new System.Drawing.Size(443, 252);
            this.dgvListeMembre.TabIndex = 0;
            // 
            // lblChoixEquipe
            // 
            this.lblChoixEquipe.AutoSize = true;
            this.lblChoixEquipe.Depth = 0;
            this.lblChoixEquipe.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblChoixEquipe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblChoixEquipe.Location = new System.Drawing.Point(12, 337);
            this.lblChoixEquipe.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblChoixEquipe.Name = "lblChoixEquipe";
            this.lblChoixEquipe.Size = new System.Drawing.Size(97, 19);
            this.lblChoixEquipe.TabIndex = 2;
            this.lblChoixEquipe.Text = "Choix Equipe";
            // 
            // btnListeEqui
            // 
            this.btnListeEqui.Depth = 0;
            this.btnListeEqui.Location = new System.Drawing.Point(259, 328);
            this.btnListeEqui.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnListeEqui.Name = "btnListeEqui";
            this.btnListeEqui.Primary = true;
            this.btnListeEqui.Size = new System.Drawing.Size(153, 39);
            this.btnListeEqui.TabIndex = 3;
            this.btnListeEqui.Text = "Générer La Liste Des Membres";
            this.btnListeEqui.UseVisualStyleBackColor = true;
            this.btnListeEqui.Click += new System.EventHandler(this.btnListeEqui_Click);
            // 
            // btnClose
            // 
            this.btnClose.Depth = 0;
            this.btnClose.Location = new System.Drawing.Point(418, 337);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Primary = true;
            this.btnClose.Size = new System.Drawing.Size(27, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbListeMembre
            // 
            this.cbListeMembre.FormattingEnabled = true;
            this.cbListeMembre.Location = new System.Drawing.Point(116, 337);
            this.cbListeMembre.Name = "cbListeMembre";
            this.cbListeMembre.Size = new System.Drawing.Size(137, 21);
            this.cbListeMembre.TabIndex = 5;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::NNGLBD_2018.Properties.Resources.logo;
            this.pictureBox3.Location = new System.Drawing.Point(401, 26);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(44, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
            // 
            // EcranListesMembre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(446, 374);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.cbListeMembre);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnListeEqui);
            this.Controls.Add(this.lblChoixEquipe);
            this.Controls.Add(this.dgvListeMembre);
            this.Name = "EcranListesMembre";
            this.Text = "Listes Des  Membres/Equipe";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeMembre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListeMembre;
        private MaterialSkin.Controls.MaterialLabel lblChoixEquipe;
        private MaterialSkin.Controls.MaterialRaisedButton btnListeEqui;
        private MaterialSkin.Controls.MaterialRaisedButton btnClose;
        private System.Windows.Forms.ComboBox cbListeMembre;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}