using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
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
    public partial class EcranPrincipal : MaterialForm
    {
        List<C_T_Club> CbTmp;
        List<C_T_Equipe> EquiTmp;
        List<C_T_Rencontre> RenTmp;
        private DataTable dtClub , dtEquipes , dtMembre , dtRencontre;
        private BindingSource bsClub , bsEquipes , bsMembre , bsRencontre;
        private string Conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Nouveau doc 2eme IS\Quadrimestre II\Program even labo (Mr Alexandre)\Projet de base de données\NNGL_BDSport.mdf;Integrated Security = True; Connect Timeout = 30";
        public EcranPrincipal()
        {
            InitializeComponent();
            #region deseign
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey800, MaterialSkin.Primary.Blue700,
                MaterialSkin.Primary.Amber500, MaterialSkin.Accent.Green400, MaterialSkin.TextShade.WHITE);
            #endregion
            CbTmp = new G_T_Club(Conn).Lire("IdClub");
            EquiTmp = new G_T_Equipe(Conn).Lire("IdEquipe");
            RemplirDGV();
            RemplirDGVRen();
            RemplirDGVEquipe();
            RemplirDGVMembre();
            CbTmp = new G_T_Club(Conn).Lire("IdClub");
            EquiTmp = new G_T_Equipe(Conn).Lire("IdEquipe");
            RenTmp = new G_T_Rencontre(Conn).Lire("IdRencontre");
            foreach (C_T_Equipe Tmp in EquiTmp)
            {
                cbEquipeRen.Items.Add(Tmp.IdEquipeDomicile + " : " + Tmp.NomEquipeDomicile);
                cbEquipeAdverse.Items.Add(Tmp.IdEquipeDomicile + " : " + Tmp.NomEquipeDomicile);
            }
            if (dgvClub.Rows.Count > 0 || dgvRencontre.Rows.Count < 0)
            {
                Activer(true);
                ActiverRen(true);
                dgvClub.Rows[0].Selected = true;
                dgvRencontre.Rows[0].Selected = true;
            }
            else { Activer(false); ActiverRen(false); }
            dtpDateHeureRen.Value = DateTime.Today;
            tbNumSemaine.Text = (CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString());
        }
        private void Activer(bool lNavigation)
        {
            btnAjouterClub.Enabled = btnEditerClub.Enabled = btnSupprimerClub.Enabled = lNavigation;
            btnAnnulerClub.Enabled = btnConfirmerClub.Enabled = !lNavigation;
            tbNomClub.Enabled = tbAddresseClub.Enabled = tbLocaliteClub.Enabled = tbClubAdverse.Enabled = !lNavigation;
            dgvClub.Enabled = lNavigation;
            if (lNavigation)
                dgvClub.Focus();
            else tbNomClub.Focus();
        }
        private void ActiverRen(bool lNavigation)
        {
            btnAjouterRen.Enabled = btnEditerRen.Enabled = btnSupprimerRen.Enabled = lNavigation;
            btnAnnuler.Enabled = btnConfirmerRen.Enabled = !lNavigation;
            cbEquipeRen.Enabled = cbEquipeAdverse.Enabled = tbScore.Enabled = dtpDateHeureRen.Enabled = !lNavigation;
            dgvRencontre.Enabled = lNavigation;
            if (lNavigation)
                dgvRencontre.Focus();
            else cbEquipeRen.Focus();
        }
        private void RemplirDGVRen()
        {
            dtRencontre = new DataTable();
            dtRencontre.Columns.Add(new DataColumn("IdRencontre", System.Type.GetType("System.Int32")));
            dtRencontre.Columns.Add("Scor");
            dtRencontre.Columns.Add("Equi");
            dtRencontre.Columns.Add("EquipeAdv");
            dtRencontre.Columns.Add("DateHeure");
            RenTmp = new G_T_Rencontre(Conn).Lire("Equi");
            foreach (C_T_Rencontre Tmp in RenTmp)
            {
                C_T_Equipe recherche = EquiTmp.Find(X => X.IdEquipeDomicile == (Tmp.IdEquipeDomicile));
                C_T_Equipe recherche2 = EquiTmp.Find(X => X.IdEquipeDomicile == (Tmp.IdEquipeVisiteuse));
                dtRencontre.Rows.Add(Tmp.IdRencontre, Tmp.ScoreRencontre , Tmp.IdEquipeDomicile + " : " + recherche.NomEquipeDomicile , 
                    Tmp.IdEquipeVisiteuse + " : " + recherche2.NomEquipeDomicile , Tmp.DateRencontre);
                
            }
            bsRencontre = new BindingSource();
            bsRencontre.DataSource = dtRencontre;
            dgvRencontre.DataSource = bsRencontre;
        }
        private void RemplirDGV()
        {
            dtClub = new DataTable();
            dtClub.Columns.Add(new DataColumn("IdClub", System.Type.GetType("System.Int32")));
            dtClub.Columns.Add("NomCb");
            dtClub.Columns.Add("LocaliteCb");
            dtClub.Columns.Add("AdresseCb");
            dtClub.Columns.Add("CbAdverse");
            List<C_T_Club> lTmp = new G_T_Club(Conn).Lire("NomClub");
            foreach (C_T_Club Tmp in lTmp)
            {
                dtClub.Rows.Add(Tmp.IdClub, Tmp.NomClub, Tmp.LocaliteClub, Tmp.AdresseClub, Tmp.ClubAdverse);
            }
            bsClub = new BindingSource();
            bsClub.DataSource = dtClub;
            dgvClub.DataSource = bsClub;
            dgvClubBord.DataSource = bsClub;
        }
        private void RemplirDGVEquipe()
        {
            dtEquipes = new DataTable();
            dtEquipes.Columns.Add(new DataColumn("IdEquipe", System.Type.GetType("System.Int32")));
            dtEquipes.Columns.Add("NomEqui");
            dtEquipes.Columns.Add("NiveauEqui");
            List<C_T_Equipe> lTmp = new G_T_Equipe(Conn).Lire("NomEquipe");
            foreach (C_T_Equipe Tmp in lTmp)
            {
                dtEquipes.Rows.Add(Tmp.IdEquipeDomicile, Tmp.NomEquipeDomicile, Tmp.NiveauEquipeDomicile);
            }
            bsEquipes = new BindingSource();
            bsEquipes.DataSource = dtEquipes;
            dgvEquipe.DataSource = bsEquipes;
        }
        private void RemplirDGVMembre()
        {
            dtMembre = new DataTable();
            dtMembre.Columns.Add(new DataColumn("IdMembre", System.Type.GetType("System.Int32")));
            dtMembre.Columns.Add("NomMem");
            dtMembre.Columns.Add("Pré");
            dtMembre.Columns.Add("FonctionMem");
            List<C_T_Membres> lTmp = new G_T_Membres(Conn).Lire("NomMembre");
            foreach (C_T_Membres Tmp in lTmp)
            {
                dtMembre.Rows.Add(Tmp.IdMembres, Tmp.NomMembres, Tmp.PrenomMembres
                    , Tmp.FonctionMembres);
            }
            bsMembre = new BindingSource();
            bsMembre.DataSource = dtMembre;
            dgvMembres.DataSource = bsMembre;
        }
        private void btnConfirmerClub_Click(object sender, EventArgs e)
        {
            if (tbNomClub.Text == "")
                MessageBox.Show("Veuillez Renseigner le Nom Du Club");
            else
            {

                if (tbIdClub.Text == "")
                //mode ajout
                {
                    int nID = new G_T_Club(Conn).Ajouter(tbNomClub.Text, tbLocaliteClub.Text, tbAddresseClub.Text,
                       Convert.ToBoolean(tbClubAdverse.Text));
                    dtClub.Rows.Add(nID, tbNomClub.Text, tbLocaliteClub.Text, tbAddresseClub.Text, Convert.ToBoolean(tbClubAdverse.Text));
                }
                else
                //mode édition
                {
                    int nID = int.Parse(tbIdClub.Text);
                    new G_T_Club(Conn).Modifier(nID, tbNomClub.Text, tbLocaliteClub.Text, tbAddresseClub.Text,
                       Convert.ToBoolean(tbClubAdverse.Text));
                    for (int i = 0; i < dtClub.Rows.Count; i++)
                    {
                        if ((int)dtClub.Rows[i]["IdClub"] == nID)
                        {
                            //dtClub.Rows[i]["NomClub"] = tbNomClub.Text;
                            dgvClub.Rows[i].Cells["NOMCb"].Value = tbNomClub.Text;
                            dgvClub.Rows[i].Cells["Localitecb"].Value = tbLocaliteClub.Text;
                            dgvClub.Rows[i].Cells["Adressecb"].Value = tbAddresseClub.Text;
                            dgvClub.Rows[i].Cells["cbAdverse"].Value = tbClubAdverse.Text;
                            break;
                        }
                    }
                }
                //dgvClub.SelectedRows[0].Cells["NomClub"].Value = tbNomClub.Text;
                bsClub.EndEdit();
                Activer(true);
            }
        }
        private void btnAnnulerClub_Click(object sender, EventArgs e)
        {
            Activer(true);
        }
        private void btnAjouterClub_Click(object sender, EventArgs e)
        {
            Activer(false);
            tbNomClub.Text = tbLocaliteClub.Text = tbAddresseClub.Text = tbClubAdverse.Text = "";
        }
        private void btnSupprimerClub_Click(object sender, EventArgs e)
        {
            if (dgvClub.SelectedRows.Count > 0)
            {
                int nID = (int)dgvClub.SelectedRows[0].Cells["IdClub"].Value; // cette ligne permet de selectionner une ligne dans le dgv
                new G_T_Club(Conn).Supprimer(nID); // suppression dans la base de donnée
                // à tester
                bsClub.RemoveCurrent(); // suppression  a l'affichage
            }
        }
        private void btnAjouterRen_Click(object sender, EventArgs e)
        {
            ActiverRen(false);
            tbIdRencontre.Text = cbEquipeAdverse.Text = cbEquipeRen.Text = tbScore.Text = "";
        }
        private void btnEditerRen_Click(object sender, EventArgs e)
        {
            if(dgvRencontre.SelectedRows.Count > 0)
            {
                ActiverRen(false);
                tbIdRencontre.Text = dgvRencontre.SelectedRows[0].Cells["IdRencontre"].Value.ToString();
                C_T_Rencontre Tmp
                = new G_T_Rencontre(Conn).Lire_ID(int.Parse(tbIdRencontre.Text));
                dtpDateHeureRen.Value = Tmp.DateRencontre;
                tbScore.Text = Tmp.ScoreRencontre;
                cbEquipeRen.Text = Tmp.IdEquipeDomicile.ToString();
                cbEquipeAdverse.Text = Tmp.IdEquipeVisiteuse.ToString();
            }
        }
        private void btnSupprimerRen_Click(object sender, EventArgs e)
        {
            DateTime date1 = Convert.ToDateTime(dgvRencontre.CurrentRow.Cells["DateHeure"].Value);
            DateTime date2 = DateTime.Today;
            int Compare = DateTime.Compare(date1, date2);
            if (dgvRencontre.SelectedRows.Count > 0)
            {
                int nID = (int)dgvRencontre.SelectedRows[0].Cells["IdRencontre"].Value;
                if (Compare == 0)
                    MessageBox.Show("ATTENTION MATCH EN COURS...", " IMPOSSIBLE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (Compare < 0)
                    MessageBox.Show("ATTENTION MATCH DEJA PASSER...", " IMPOSSIBLE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    new G_T_Rencontre(Conn).Supprimer(nID); // suppression dans la base de donnée
                    bsRencontre.RemoveCurrent();
                }
            }
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            ActiverRen(true);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EcranListesMembre f = new EcranListesMembre();
            f.ShowDialog();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            RemplirDGV();
            RemplirDGVEquipe();
            RemplirDGVMembre();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //if (tbConnect.Text != " 0")
            //{
            //    Menu.Enabled = gbMembres.Enabled = gbEquipe.Enabled = gbClub.Enabled = true;
            //    dgvMembres.Visible = dgvEquipe.Visible = dgvClubBord.Visible = true;
            //}

            //else
            //    Menu.Enabled = sousMenu.Enabled = gbMembres.Enabled = gbEquipe.Enabled = gbClub.Enabled = false;
        }

        private void cbEquipeAdverse_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool verif = false;
            for (int k=0; k < dtRencontre.Rows.Count;k++)
            {
                if ((dgvRencontre.Rows[k].Cells["Equi"].Value.ToString() == cbEquipeRen.SelectedItem.ToString() &&
                        dgvRencontre.Rows[k].Cells["EquipeAdv"].Value.ToString() == cbEquipeAdverse.SelectedItem.ToString()))
                {
                    verif = true;
                }
                else
                    btnConfirmerRen.Enabled = true;
            }
            if (verif)
            {
                MessageBox.Show("Rencontre existante !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnConfirmerRen.Enabled = false;
            }
        } // pour la securité
        private void btnConfirmerRen_Click(object sender, EventArgs e)
        {
            int num_semaineref = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear
                    (DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            int comp = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear
                    (dtpDateHeureRen.Value, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            if (tbScore.Text == "")
                MessageBox.Show("Veuillez Renseigner Comme Score  - ");
            else 
            {
                if(cbEquipeRen.SelectedItem.ToString() == cbEquipeAdverse.SelectedItem.ToString())
                    MessageBox.Show("Attention !!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    if (tbIdRencontre.Text == "")
                    //mode ajout
                    {
                        int nID = new G_T_Rencontre(Conn).Ajouter(dtpDateHeureRen.Value, tbScore.Text, Convert.ToInt32(cbEquipeRen.Text.Substring(0, 1)),
                          Convert.ToInt32(cbEquipeAdverse.Text.Substring(0, 1)));
                        dtRencontre.Rows.Add(nID, tbScore.Text, Convert.ToInt32(cbEquipeRen.Text.Substring(0, 1)), Convert.ToInt32(cbEquipeAdverse.Text.Substring(0, 1)), dtpDateHeureRen.Value);
                    }
                    else
                    //mode édition
                    {
                        if ((cbEquipeRen.SelectedItem.ToString().Substring(0, 1) == cbEquipeAdverse.SelectedItem.ToString().Substring(0, 1)) ||
                                        ((dgvRencontre.Rows[0].Cells["Equi"].Value.ToString() == cbEquipeRen.SelectedItem.ToString()) && (dgvRencontre.Rows[0].
                                        Cells["EquipeAdv"].Value.ToString() == cbEquipeAdverse.SelectedItem.ToString())))
                        {

                            MessageBox.Show("ERREUR D'ADRESSAGE D'EQUIPE !!", " ERREUR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int nID = int.Parse(tbIdRencontre.Text);
                            new G_T_Rencontre(Conn).Modifier(nID, dtpDateHeureRen.Value, tbScore.Text,
                                Convert.ToInt32(cbEquipeRen.Text.Substring(0, 1)), Convert.ToInt32(cbEquipeAdverse.Text.Substring(0, 1)));
                            for (int i = 0; i < dtRencontre.Rows.Count; i++)
                            {
                                if ((int)dtRencontre.Rows[i]["IdRencontre"] == nID)
                                {
                                    //dtClub.Rows[i]["NomClub"] = tbNomClub.Text;
                                    dgvRencontre.Rows[i].Cells["Scor"].Value = tbScore.Text;
                                    dgvRencontre.Rows[i].Cells["Equi"].Value = cbEquipeRen.Text;
                                    dgvRencontre.Rows[i].Cells["EquipeAdv"].Value = cbEquipeAdverse.Text;
                                    dgvRencontre.Rows[i].Cells["DateHeure"].Value = dtpDateHeureRen.Value;
                                    break;
                                }
                            }
                        }
                    }
                    bsRencontre.EndEdit();
                    Activer(true);
                }
               
            }
        }
        private void btnEditerClub_Click(object sender, EventArgs e)
        {

            if(dgvClub.SelectedRows.Count > 0)
            {
                Activer(false);
                tbIdClub.Text = dgvClub.SelectedRows[0].Cells["IdClub"].Value.ToString();
                C_T_Club Tmp
                = new G_T_Club(Conn).Lire_ID(int.Parse(tbIdClub.Text));
                tbNomClub.Text = Tmp.NomClub;
                tbLocaliteClub.Text = Tmp.LocaliteClub;
                tbAddresseClub.Text = Tmp.AdresseClub;
                tbClubAdverse.Text = Tmp.ClubAdverse.ToString();
            }

        }
        private void btnGestionEqui_Click(object sender, EventArgs e)
        {
            EcranTableEquipe f = new EcranTableEquipe();
            f.ShowDialog();
        }
        private void btnGestionMem_Click(object sender, EventArgs e)
        {
            EcranTableMembre f = new EcranTableMembre();
            f.ShowDialog();
        }
        private void btnProgramme_Click(object sender, EventArgs e)
        {
            EcranRencontre f = new EcranRencontre();
            f.ShowDialog();
        }
    }
}
