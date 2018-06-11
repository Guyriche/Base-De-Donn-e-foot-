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
    public partial class EcranListesMembre : MaterialForm
    {
        List<C_T_Club> CbTmp;
        List<C_T_Equipe> EquiTmp;
        List<C_T_Rencontre> RenTmp;
        List<C_T_Membres> MemTmp;
        private DataTable dtMembre;
        private BindingSource bsMembre;
        private string Conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Nouveau doc 2eme IS\Quadrimestre II\Program even labo (Mr Alexandre)\Projet de base de données\NNGL_BDSport.mdf;Integrated Security = True; Connect Timeout = 30";
        public EcranListesMembre()
        {
            InitializeComponent();
            CbTmp = new G_T_Club(Conn).Lire("IdClub");
            EquiTmp = new G_T_Equipe(Conn).Lire("IdEquipe");
            RenTmp = new G_T_Rencontre(Conn).Lire("IdRencontre");
            foreach (C_T_Equipe Tmp in EquiTmp)
            {
                C_T_Equipe recherche = EquiTmp.Find(X => X.IdEquipeDomicile == (Tmp.IdEquipeDomicile));
                C_T_Club VerifCamp = new G_T_Club(Conn).Lire_ID(Tmp.IdClub);
                if (VerifCamp.ClubAdverse != true)
                    cbListeMembre.Items.Add(recherche.IdEquipeDomicile + " : " + Tmp.NomEquipeDomicile);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnListeEqui_Click(object sender, EventArgs e)
        {
            dtMembre = new DataTable();
            dtMembre.Columns.Add(new DataColumn("IdMembre", System.Type.GetType("System.Int32")));
            dtMembre.Columns.Add("Nom du Membre");
            dtMembre.Columns.Add("Prénom du Membre");
            dtMembre.Columns.Add("Fonction du Membre");
            string[] teb = cbListeMembre.SelectedItem.ToString().Split(':');
            //MessageBox.Show(teb[0]);
            EquiTmp = new G_T_Equipe(Conn).Lire("IdEquipe");
            MemTmp = new G_T_Membres(Conn).Lire("IdMembres");
            foreach(C_T_Membres Tmp in MemTmp)
            {
                C_T_Equipe Search = EquiTmp.Find(x => x.IdEquipeDomicile == Tmp.IdEquipe);
                if (Int32.Parse(teb[0]) == Search.IdEquipeDomicile)
                {
                    dtMembre.Rows.Add(Tmp.IdMembres, Tmp.NomMembres, Tmp.PrenomMembres
                    , Tmp.FonctionMembres);
                }
            }
            bsMembre = new BindingSource();
            bsMembre.DataSource = dtMembre;
            dgvListeMembre.DataSource = bsMembre;
        }
    }
}
