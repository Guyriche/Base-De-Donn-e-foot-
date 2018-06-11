using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using MaterialSkin;
using NNGLBDCouAcces;
using NNGLBDCouClasse;
using NNGLBDCouGestion;

namespace NNGLBD_2018
{
    public partial class EcranTableMembre : MaterialForm
    {
        private DataTable dtMembre;
        private BindingSource bsMembre;
        private string Conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Nouveau doc 2eme IS\Quadrimestre II\Program even labo (Mr Alexandre)\Projet de base de données\NNGL_BDSport.mdf;Integrated Security = True; Connect Timeout = 30";
        public EcranTableMembre()
        {
            InitializeComponent();
            List<C_T_Club> CbTmp = new G_T_Club(Conn).Lire("IdClub");
            List<C_T_Equipe> lTmp = new G_T_Equipe(Conn).Lire("IdEquipe");
                foreach (C_T_Equipe Tmp in lTmp)
                {
                    C_T_Club VerifCamp = new G_T_Club(Conn).Lire_ID(Tmp.IdClub);
                    if (VerifCamp.ClubAdverse != true)
                        cbRefEquipe.Items.Add(Tmp.IdEquipeDomicile + " : " + Tmp.NomEquipeDomicile );
                }
            RemplirDGV();
            if (dgvMembre.Rows.Count > 0)
            {
                Activer(true);
                dgvMembre.Rows[0].Selected = true;
            }
            else { Activer(false); }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Activer(false);
            tbNomMem.Text = tbPreMem.Text = tbNationalite.Text = tbFonction.Text = tbAdresse.Text =
                tbLicence.Text = "";
            dtpDateNai.Value = DateTime.Today;
        }

        private void BtnEditer_Click(object sender, EventArgs e)
        {
            if(dgvMembre.SelectedRows.Count > 0)
            {
                Activer(false);
                tbIdMembre.Text = dgvMembre.SelectedRows[0].Cells["IdMembre"].Value.ToString();
                C_T_Membres Tmp = new G_T_Membres(Conn).Lire_ID(int.Parse(tbIdMembre.Text));
                cbRefEquipe.Text = Tmp.IdEquipe.ToString();
                tbNomMem.Text = Tmp.NomMembres;
                tbPreMem.Text = Tmp.PrenomMembres;
                tbNationalite.Text = Tmp.NationaliteMembres;
                dtpDateNai.Value = Tmp.DateNaissanceMembres;
                tbFonction.Text = Tmp.FonctionMembres;
                tbAdresse.Text = Tmp.AdresseMembres;
                tbLicence.Text = Tmp.LicenseMembres;
            }
        }
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if(dgvMembre.SelectedRows.Count > 0)
            {
                int nID = (int)dgvMembre.SelectedRows[0].Cells["IdMembre"].Value;
                new G_T_Membres(Conn).Supprimer(nID); // suppression dans la base de donnée
                // à tester
                bsMembre.RemoveCurrent(); // suppression  a l'affichage
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            Activer(true);
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (tbNomMem.Text == "")
                MessageBox.Show("Veuillez Renseigner le Nom Du Club");
            else
            {

                if (tbIdMembre.Text == "")
                //mode ajout
                {
                    int nID = new G_T_Membres(Conn).Ajouter(tbNomMem.Text, tbPreMem.Text, tbNationalite.Text , dtpDateNai.Value,
                       tbFonction.Text, tbAdresse.Text , tbLicence.Text ,  Convert.ToInt32(cbRefEquipe.Text));
                    dtMembre.Rows.Add(nID, tbNomMem.Text, tbPreMem.Text, tbNationalite.Text , dtpDateNai.Value , tbFonction.Text , tbAdresse.Text 
                        , tbLicence.Text , cbRefEquipe.Text);
                }
                else
                //mode édition
                {
                    int nID = int.Parse(tbIdMembre.Text);
                    new G_T_Membres(Conn).Modifier(nID , tbNomMem.Text, tbPreMem.Text, tbNationalite.Text, dtpDateNai.Value,
                       tbFonction.Text, tbAdresse.Text, tbLicence.Text, Convert.ToInt32(cbRefEquipe.Text));
                    for (int i = 0; i < dtMembre.Rows.Count; i++)
                    {
                        if ((int)dtMembre.Rows[i]["IdMembre"] == nID)
                        {
                            //dtClub.Rows[i]["NomClub"] = tbNomClub.Text;
                            dgvMembre.Rows[i].Cells["RefEqui"].Value = cbRefEquipe.Text;
                            dgvMembre.Rows[i].Cells["NomMem"].Value = tbNomMem.Text;
                            dgvMembre.Rows[i].Cells["Pré"].Value = tbPreMem.Text;
                            dgvMembre.Rows[i].Cells["PaysNai"].Value = tbNationalite.Text;
                            dgvMembre.Rows[i].Cells["DateNai"].Value = dtpDateNai.Value;
                            dgvMembre.Rows[i].Cells["FonctionMem"].Value = tbFonction.Text;
                            dgvMembre.Rows[i].Cells["AdresseMem"].Value = tbAdresse.Text;
                            dgvMembre.Rows[i].Cells["LicenceMem"].Value = tbLicence.Text;
                            break;
                        }
                    }
                }
                //dgvClub.SelectedRows[0].Cells["NomClub"].Value = tbNomClub.Text;
                bsMembre.EndEdit();
                Activer(true);
            }
        }
        private void Activer(bool lNavigation)
        {
            btnAjoutermem.Enabled = BtnEditerMem.Enabled = btnSupprimerMEm.Enabled = lNavigation;
            btnAnnulerMem.Enabled = btnConfirmerMem.Enabled = !lNavigation;
            tbNomMem.Enabled = tbPreMem.Enabled  = tbNationalite.Enabled = tbLicence.Enabled = tbFonction.Enabled
                 = tbAdresse.Enabled = dtpDateNai.Enabled = !lNavigation;
            dgvMembre.Enabled = lNavigation;
            if (lNavigation)
                dgvMembre.Focus();
            else tbNomMem.Focus();
        }
        private void RemplirDGV()
        {
            dtMembre = new DataTable();
            dtMembre.Columns.Add(new DataColumn("IdMembre", System.Type.GetType("System.Int32")));
            dtMembre.Columns.Add("NomMem");
            dtMembre.Columns.Add("Pré");
            dtMembre.Columns.Add("PaysNai");
            dtMembre.Columns.Add("DateNai");
            dtMembre.Columns.Add("FonctionMem");
            dtMembre.Columns.Add("AdresseMem");
            dtMembre.Columns.Add("LicenceMem");
            dtMembre.Columns.Add("RefEqui");
            List<C_T_Membres> lTmp = new G_T_Membres(Conn).Lire("NomMembre");
            foreach (C_T_Membres Tmp in lTmp)
            {
                dtMembre.Rows.Add(Tmp.IdMembres, Tmp.NomMembres, Tmp.PrenomMembres, Tmp.NationaliteMembres , Tmp.DateNaissanceMembres
                    , Tmp.FonctionMembres , Tmp.AdresseMembres , Tmp.LicenseMembres ,Tmp.IdEquipe);
            }
            bsMembre = new BindingSource();
            bsMembre.DataSource = dtMembre;
            dgvMembre.DataSource = bsMembre;
        }
    }
}
