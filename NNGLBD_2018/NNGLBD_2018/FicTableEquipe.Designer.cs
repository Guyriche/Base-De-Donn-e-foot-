namespace NNGLBD_2018
{
    partial class EcranTableEquipe
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
            this.dgvTEquipe = new System.Windows.Forms.DataGridView();
            this.IdEquipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomEquipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NiveauEquipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefClub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbNiveauEqui = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tbNomEqui = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.tbIdEquipe = new System.Windows.Forms.TextBox();
            this.btnSupprimer = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnEditer = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnAjouter = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnEnregistrer = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnAnnuler = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblRefClub = new MaterialSkin.Controls.MaterialLabel();
            this.cbRefClub = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTEquipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTEquipe
            // 
            this.dgvTEquipe.AllowUserToAddRows = false;
            this.dgvTEquipe.AllowUserToDeleteRows = false;
            this.dgvTEquipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTEquipe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdEquipe,
            this.NomEquipe,
            this.NiveauEquipe,
            this.RefClub});
            this.dgvTEquipe.Location = new System.Drawing.Point(2, 65);
            this.dgvTEquipe.Name = "dgvTEquipe";
            this.dgvTEquipe.ReadOnly = true;
            this.dgvTEquipe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTEquipe.Size = new System.Drawing.Size(483, 183);
            this.dgvTEquipe.TabIndex = 28;
            // 
            // IdEquipe
            // 
            this.IdEquipe.DataPropertyName = "IdEquipe";
            this.IdEquipe.HeaderText = "IdEquipe";
            this.IdEquipe.Name = "IdEquipe";
            this.IdEquipe.ReadOnly = true;
            this.IdEquipe.Visible = false;
            this.IdEquipe.Width = 150;
            // 
            // NomEquipe
            // 
            this.NomEquipe.DataPropertyName = "NomEquipe";
            this.NomEquipe.HeaderText = "NomEquipe";
            this.NomEquipe.Name = "NomEquipe";
            this.NomEquipe.ReadOnly = true;
            this.NomEquipe.Width = 200;
            // 
            // NiveauEquipe
            // 
            this.NiveauEquipe.DataPropertyName = "NiveauEquipe";
            this.NiveauEquipe.HeaderText = "NiveauEquipe";
            this.NiveauEquipe.Name = "NiveauEquipe";
            this.NiveauEquipe.ReadOnly = true;
            this.NiveauEquipe.Width = 200;
            // 
            // RefClub
            // 
            this.RefClub.DataPropertyName = "RefClub";
            this.RefClub.HeaderText = "ReferenceClub";
            this.RefClub.Name = "RefClub";
            this.RefClub.ReadOnly = true;
            // 
            // tbNiveauEqui
            // 
            this.tbNiveauEqui.Depth = 0;
            this.tbNiveauEqui.Hint = "";
            this.tbNiveauEqui.Location = new System.Drawing.Point(135, 430);
            this.tbNiveauEqui.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbNiveauEqui.Name = "tbNiveauEqui";
            this.tbNiveauEqui.PasswordChar = '\0';
            this.tbNiveauEqui.SelectedText = "";
            this.tbNiveauEqui.SelectionLength = 0;
            this.tbNiveauEqui.SelectionStart = 0;
            this.tbNiveauEqui.Size = new System.Drawing.Size(297, 23);
            this.tbNiveauEqui.TabIndex = 27;
            this.tbNiveauEqui.UseSystemPasswordChar = false;
            // 
            // tbNomEqui
            // 
            this.tbNomEqui.Depth = 0;
            this.tbNomEqui.Hint = "";
            this.tbNomEqui.Location = new System.Drawing.Point(135, 367);
            this.tbNomEqui.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbNomEqui.Name = "tbNomEqui";
            this.tbNomEqui.PasswordChar = '\0';
            this.tbNomEqui.SelectedText = "";
            this.tbNomEqui.SelectionLength = 0;
            this.tbNomEqui.SelectionStart = 0;
            this.tbNomEqui.Size = new System.Drawing.Size(297, 23);
            this.tbNomEqui.TabIndex = 26;
            this.tbNomEqui.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(12, 430);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(105, 19);
            this.materialLabel3.TabIndex = 23;
            this.materialLabel3.Text = "Niveau Equipe";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 371);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(92, 19);
            this.materialLabel2.TabIndex = 22;
            this.materialLabel2.Text = "Nom Equipe";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 276);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(71, 19);
            this.materialLabel1.TabIndex = 21;
            this.materialLabel1.Text = "Id Equipe";
            // 
            // tbIdEquipe
            // 
            this.tbIdEquipe.Location = new System.Drawing.Point(134, 275);
            this.tbIdEquipe.Name = "tbIdEquipe";
            this.tbIdEquipe.ReadOnly = true;
            this.tbIdEquipe.Size = new System.Drawing.Size(297, 20);
            this.tbIdEquipe.TabIndex = 32;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.AutoSize = true;
            this.btnSupprimer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSupprimer.Depth = 0;
            this.btnSupprimer.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(495, 198);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSupprimer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Primary = false;
            this.btnSupprimer.Size = new System.Drawing.Size(69, 36);
            this.btnSupprimer.TabIndex = 31;
            this.btnSupprimer.Text = "Effacer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnEditer
            // 
            this.btnEditer.AutoSize = true;
            this.btnEditer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditer.Depth = 0;
            this.btnEditer.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditer.Location = new System.Drawing.Point(507, 130);
            this.btnEditer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEditer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditer.Name = "btnEditer";
            this.btnEditer.Primary = false;
            this.btnEditer.Size = new System.Drawing.Size(57, 36);
            this.btnEditer.TabIndex = 30;
            this.btnEditer.Text = "Editer  ";
            this.btnEditer.UseVisualStyleBackColor = true;
            this.btnEditer.Click += new System.EventHandler(this.btnEditer_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.AutoSize = true;
            this.btnAjouter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAjouter.Depth = 0;
            this.btnAjouter.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(492, 65);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAjouter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Primary = false;
            this.btnAjouter.Size = new System.Drawing.Size(72, 36);
            this.btnAjouter.TabIndex = 29;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.AutoSize = true;
            this.btnEnregistrer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEnregistrer.Depth = 0;
            this.btnEnregistrer.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Location = new System.Drawing.Point(463, 322);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEnregistrer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Primary = false;
            this.btnEnregistrer.Size = new System.Drawing.Size(101, 36);
            this.btnEnregistrer.TabIndex = 25;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.AutoSize = true;
            this.btnAnnuler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAnnuler.Depth = 0;
            this.btnAnnuler.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(463, 371);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAnnuler.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Primary = false;
            this.btnAnnuler.Size = new System.Drawing.Size(73, 36);
            this.btnAnnuler.TabIndex = 24;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // lblRefClub
            // 
            this.lblRefClub.AutoSize = true;
            this.lblRefClub.Depth = 0;
            this.lblRefClub.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRefClub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRefClub.Location = new System.Drawing.Point(12, 322);
            this.lblRefClub.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRefClub.Name = "lblRefClub";
            this.lblRefClub.Size = new System.Drawing.Size(65, 19);
            this.lblRefClub.TabIndex = 33;
            this.lblRefClub.Text = "Ref Club";
            // 
            // cbRefClub
            // 
            this.cbRefClub.FormattingEnabled = true;
            this.cbRefClub.Location = new System.Drawing.Point(135, 320);
            this.cbRefClub.Name = "cbRefClub";
            this.cbRefClub.Size = new System.Drawing.Size(296, 21);
            this.cbRefClub.TabIndex = 34;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::NNGLBD_2018.Properties.Resources.logo;
            this.pictureBox3.Location = new System.Drawing.Point(549, 25);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NNGLBD_2018.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(534, 405);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // EcranTableEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 475);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.cbRefClub);
            this.Controls.Add(this.lblRefClub);
            this.Controls.Add(this.dgvTEquipe);
            this.Controls.Add(this.tbNiveauEqui);
            this.Controls.Add(this.tbNomEqui);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.tbIdEquipe);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnEditer);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAnnuler);
            this.Name = "EcranTableEquipe";
            this.Text = "Table Equipe";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTEquipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTEquipe;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbNiveauEqui;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbNomEqui;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox tbIdEquipe;
        private MaterialSkin.Controls.MaterialFlatButton btnSupprimer;
        private MaterialSkin.Controls.MaterialFlatButton btnEditer;
        private MaterialSkin.Controls.MaterialFlatButton btnAjouter;
        private MaterialSkin.Controls.MaterialFlatButton btnEnregistrer;
        private MaterialSkin.Controls.MaterialFlatButton btnAnnuler;
        private MaterialSkin.Controls.MaterialLabel lblRefClub;
        private System.Windows.Forms.ComboBox cbRefClub;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEquipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomEquipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NiveauEquipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefClub;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}