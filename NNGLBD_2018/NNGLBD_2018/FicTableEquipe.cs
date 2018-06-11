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
    public partial class EcranTableEquipe : MaterialForm
    {
        List<C_T_Club> clubs;
        private DataTable dtEquipes;
        private BindingSource bsEquipes;
        private string Conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Nouveau doc 2eme IS\Quadrimestre II\Program even labo (Mr Alexandre)\Projet de base de données\NNGL_BDSport.mdf;Integrated Security = True; Connect Timeout = 30";
        public EcranTableEquipe()
        {
            InitializeComponent();
            clubs = new G_T_Club(Conn).Lire("IdClub");
            foreach (C_T_Club Tmp in clubs)
            {
                cbRefClub.Items.Add(Tmp.IdClub + " : " + Tmp.NomClub);
                //cbRefClub.Items.Add(club.ClubAdverse);
            }
            RemplirDGV();
            if (dgvTEquipe.Rows.Count > 0)
            {
                Activer(true);
                dgvTEquipe.Rows[0].Selected = true;
            }
            else { Activer(false); }
        }
        private void Activer(bool lNavigation)
        {
            btnAjouter.Enabled = btnEditer.Enabled = btnSupprimer.Enabled = lNavigation;
            btnAnnuler.Enabled = btnEnregistrer.Enabled = !lNavigation;
            tbNomEqui.Enabled = tbNiveauEqui.Enabled = !lNavigation;
            dgvTEquipe.Enabled = lNavigation;
            if (lNavigation)
                dgvTEquipe.Focus();
            else tbNomEqui.Focus();
        }
        private void RemplirDGV()
        {
            dtEquipes = new DataTable();
            dtEquipes.Columns.Add(new DataColumn("IdEquipe", System.Type.GetType("System.Int32")));
            dtEquipes.Columns.Add("NomEquipe");
            dtEquipes.Columns.Add("NiveauEquipe");
            dtEquipes.Columns.Add("RefClub");
            List<C_T_Equipe> lTmp = new G_T_Equipe(Conn).Lire("NomEquipe");
            foreach (C_T_Equipe Tmp in lTmp)
            {
                C_T_Club recherche = clubs.Find(X => X.IdClub == (Tmp.IdClub));
                dtEquipes.Rows.Add(Tmp.IdEquipeDomicile, Tmp.NomEquipeDomicile, Tmp.NiveauEquipeDomicile , Tmp.IdClub + " - " + recherche.NomClub);
            }
            bsEquipes = new BindingSource();
            bsEquipes.DataSource = dtEquipes;
            dgvTEquipe.DataSource = bsEquipes;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            Activer(true);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Activer(false);
            tbIdEquipe.Text = tbNomEqui.Text = tbNiveauEqui.Text = "";
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (tbNomEqui.Text == "")
                MessageBox.Show("Veuillez Renseigner le Nom Du Club");
            else
            {

                if (tbIdEquipe.Text == "")
                //mode ajout
                {
                    int nID = new G_T_Equipe(Conn).Ajouter(tbNomEqui.Text, tbNiveauEqui.Text, Convert.ToInt32(cbRefClub.Text));
                    dtEquipes.Rows.Add(nID, tbNomEqui.Text, tbNiveauEqui.Text, cbRefClub.Text);
                }
                else
                //mode édition
                {
                    int nID = int.Parse(tbIdEquipe.Text);
                    new G_T_Equipe(Conn).Modifier(nID, tbNomEqui.Text, tbNiveauEqui.Text, Convert.ToInt32(cbRefClub.Text));
                    for (int i = 0; i < dtEquipes.Rows.Count; i++)
                    {
                        if ((int)dtEquipes.Rows[i]["IdEquipe"] == nID)
                        {
                            //dtClub.Rows[i]["NomClub"] = tbNomClub.Text;
                            dgvTEquipe.Rows[i].Cells["RefClub"].Value = cbRefClub.Text;
                            dgvTEquipe.Rows[i].Cells["NomEquipe"].Value = tbNomEqui.Text;
                            dgvTEquipe.Rows[i].Cells["NiveauEquipe"].Value = tbNiveauEqui.Text;
                            break;
                        }
                    }
                }
                //dgvClub.SelectedRows[0].Cells["NomClub"].Value = tbNomClub.Text;
                bsEquipes.EndEdit();
                Activer(true);
            }
        }

        private void btnEditer_Click(object sender, EventArgs e)
        {
            if(dgvTEquipe.SelectedRows.Count > 0)
            {
                Activer(false);
                tbIdEquipe.Text = dgvTEquipe.SelectedRows[0].Cells["IdEquipe"].Value.ToString();
                C_T_Equipe Tmp = new G_T_Equipe(Conn).Lire_ID(int.Parse(tbIdEquipe.Text));
                tbNomEqui.Text = Tmp.NomEquipeDomicile;
                tbNiveauEqui.Text = Tmp.NiveauEquipeDomicile;
                cbRefClub.Text = Tmp.IdClub.ToString();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvTEquipe.SelectedRows.Count > 0)
            {
                int nID = (int)dgvTEquipe.SelectedRows[0].Cells["IdEquipe"].Value;
                new G_T_Equipe(Conn).Supprimer(nID); // suppression dans la base de donnée
                // à tester
                bsEquipes.RemoveCurrent(); // suppression  a l'affichage
            }
        }
    }
}
