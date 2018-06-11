using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using MaterialSkin;
using NNGLBDCouAcces;
using NNGLBDCouClasse;
using NNGLBDCouGestion;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace NNGLBD_2018
{
    public partial class EcranRencontre : MaterialForm
    {
        #region Déclaration Des Variables
        List<C_T_Club> CbTmp;
        List<C_T_Equipe> EquiTmp;
        List<C_T_Rencontre> RenTmp;
        List<C_T_Membres> MemTmp;
        private int Semaine_Ref, ActueSemaine;
        private DataTable dtRencontre;
        private BindingSource bsRencontre ;
        private string Conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Nouveau doc 2eme IS\Quadrimestre II\Program even labo (Mr Alexandre)\Projet de base de données\NNGL_BDSport.mdf;Integrated Security = True; Connect Timeout = 30";
#endregion
        public EcranRencontre()
        {
            InitializeComponent();
            #region deseign
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey800, MaterialSkin.Primary.Amber900,
                MaterialSkin.Primary.Amber500, MaterialSkin.Accent.Green400, MaterialSkin.TextShade.WHITE);
            #endregion
            //RemplirDGV();
            CbTmp = new G_T_Club(Conn).Lire("IdClub");
            EquiTmp = new G_T_Equipe(Conn).Lire("IdEquipe");
            foreach (C_T_Equipe Tmp in EquiTmp)
            {
                C_T_Club VerifCamp = new G_T_Club(Conn).Lire_ID(Tmp.IdClub);
                if (VerifCamp.ClubAdverse != true)
                {
                    cbChoixEquipe.Items.Add(Tmp.NomEquipeDomicile);
                    comboBox1.Items.Add(Tmp.NomEquipeDomicile);
                }
                //else
                //    cbEquipeAdverse.Items.Add(Tmp.IdEquipeDomicile);
            }
        }

        private void btnPreviews_Click(object sender, EventArgs e)
        {
            dtRencontre = new DataTable();
            dtRencontre.Columns.Add(new DataColumn("IdRencontre", System.Type.GetType("System.Int32")));
            dtRencontre.Columns.Add("DateRen");
            dtRencontre.Columns.Add("EquipeDomic");
            dtRencontre.Columns.Add("vsresultat");
            dtRencontre.Columns.Add("equiAdv");
            EquiTmp = new G_T_Equipe(Conn).Lire("IdEquipe");
            RenTmp = new G_T_Rencontre(Conn).Lire("Equi");
            CbTmp = new G_T_Club(Conn).Lire("IdClub");
            int num_semaineref = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear
                    (DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            tbsemaine.Text = num_semaineref.ToString();
            foreach (C_T_Rencontre Tmp in RenTmp)
            {
                int num_Semaine = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear
                    (Tmp.DateRencontre, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                if (num_Semaine < num_semaineref)
                {

                    C_T_Equipe recherche = EquiTmp.Find(X => X.IdEquipeDomicile == (Tmp.IdEquipeDomicile));
                    C_T_Equipe recherche2 = EquiTmp.Find(X => X.IdEquipeDomicile == (Tmp.IdEquipeVisiteuse));

                    C_T_Equipe seachEquipe = EquiTmp.Find(X => X.IdEquipeDomicile == Tmp.IdEquipeDomicile);
                    C_T_Equipe seachEquipeAdv = EquiTmp.Find(X => X.IdEquipeDomicile == Tmp.IdEquipeVisiteuse);
                    C_T_Club VerifCamp = CbTmp.Find(X => X.IdClub == seachEquipe.IdClub);
                    C_T_Club VerifCampAdv = CbTmp.Find(X => X.IdClub == seachEquipeAdv.IdClub);
                    if (!VerifCamp.ClubAdverse || !VerifCampAdv.ClubAdverse)
                        dtRencontre.Rows.Add(Tmp.IdRencontre, Tmp.DateRencontre, recherche.NomEquipeDomicile,
                            Tmp.ScoreRencontre, recherche2.NomEquipeDomicile);
                }

            }
            bsRencontre = new BindingSource();
            bsRencontre.DataSource = dtRencontre;
            dgvResultat.DataSource = bsRencontre;
        }

        private void btnSemainePre_Click(object sender, EventArgs e)
        {
            GestionDesSemaines(dgvCalendrier , Semaine_Ref, ActueSemaine);
        }
        private void btnSamainePasser_Click(object sender, EventArgs e)
        {
            
            dtRencontre = new DataTable();
            dtRencontre.Columns.Add(new DataColumn("IdRencontre", System.Type.GetType("System.Int32")));
            dtRencontre.Columns.Add("DateHeure");
            dtRencontre.Columns.Add("EquipeDomi");
            dtRencontre.Columns.Add("vs");
            dtRencontre.Columns.Add("EquipeVisit");
            EquiTmp = new G_T_Equipe(Conn).Lire("IdEquipe");
            RenTmp = new G_T_Rencontre(Conn).Lire("Equi");
            CbTmp = new G_T_Club(Conn).Lire("IdClub");
            int num_semaineref = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear
                    (DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            tbsemaine.Text = num_semaineref.ToString();
            foreach (C_T_Rencontre Tmp in RenTmp)
            {
                int num_Semaine = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear
                    (Tmp.DateRencontre, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                if (num_Semaine > num_semaineref)
                {

                    C_T_Equipe recherche = EquiTmp.Find(X => X.IdEquipeDomicile == (Tmp.IdEquipeDomicile));
                    C_T_Equipe recherche2 = EquiTmp.Find(X => X.IdEquipeDomicile == (Tmp.IdEquipeVisiteuse));

                    C_T_Equipe seachEquipe = EquiTmp.Find(X => X.IdEquipeDomicile == Tmp.IdEquipeDomicile);
                    C_T_Equipe seachEquipeAdv = EquiTmp.Find(X => X.IdEquipeDomicile == Tmp.IdEquipeVisiteuse);
                    C_T_Club VerifCamp = CbTmp.Find(X => X.IdClub == seachEquipe.IdClub);
                    C_T_Club VerifCampAdv = CbTmp.Find(X => X.IdClub == seachEquipeAdv.IdClub);
                    if (!VerifCamp.ClubAdverse || !VerifCampAdv.ClubAdverse)
                        dtRencontre.Rows.Add(Tmp.IdRencontre, Tmp.DateRencontre, recherche.NomEquipeDomicile,
                            Tmp.ScoreRencontre, recherche2.NomEquipeDomicile);
                }

            }
            //else
            //        MessageBox.Show(" ERREUR DE CORRESPONDANCE !! ");
            bsRencontre = new BindingSource();
            bsRencontre.DataSource = dtRencontre;
            dgvCalendrier.DataSource = bsRencontre;
        }
        private void btnConfirmerRen_Click(object sender, EventArgs e)
        {
            if (cbChoixEquipe.Text == "")
                MessageBox.Show("Veuillez Choisir l'Equipe");
            else
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
                doc.Open(); // ouvrir le document ecrit
                            // ecrire le contenant du document
                iTextSharp.text.Image jpeg = iTextSharp.text.Image.GetInstance("logo.jpg");
                jpeg.ScalePercent(25f);
                jpeg.Alignment = 1;
                // Fonction pour background image
                iTextSharp.text.Image filigrane = iTextSharp.text.Image.GetInstance("Campo.png");
                filigrane.SetAbsolutePosition(20, 200);
                doc.Add(filigrane);
                //Watermark Background = new Watermark(Image.GetInstance("watermark.jpg"), 200, 420);
                //doc.Add(Background);
                // pour positionner l'image 
                //jpeg.SetAbsolutePosition(doc.PageSize.Width - 36f - 72f, doc.PageSize.Height - 30f - 216f);
                Paragraph date = new Paragraph(DateTime.Today.ToString("dd/MM/yyyy"));
                date.Alignment = 2;// 0= left , 1 = centre , 2 = right
                doc.Add(date);
                doc.Add(jpeg);
                Paragraph paragraph = new Paragraph("COMPETITION INTERNATIONAL DE FOOTBALL D'EUROPE..\n\n\n", new iTextSharp.text.Font(
                    iTextSharp.text.Font.NORMAL, 30f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE));

                Paragraph Corp = new Paragraph("   Suite au règle du tournoi , notre Club Comme chaque Année et chaque jour de renconte notre Equipe     " + cbChoixEquipe.SelectedItem + " Somme honnoré de prendre part a cette rencontre qui Oppose " + dgvCalendrier.CurrentRow.Cells["EquipeDomi"].Value.ToString() + " Vs " + dgvCalendrier.CurrentRow.Cells["EquipeVisit"].Value.ToString() + " se tiendra le " + dgvCalendrier.CurrentRow.Cells["DateHeure"].Value.ToString() + " heure\n\n\n");
                Paragraph signature_d = new Paragraph(" Coordialement l'Entrainneur________________\n");
                signature_d.Alignment = 0;
                Paragraph signature_g = new Paragraph(" Mr L'entraineur___\n");
                signature_g.Alignment = 2;
                paragraph.Alignment = 1;// 0= left , 1 = centre , 2 = right
                PdfPTable table = new PdfPTable(1);
                PdfPCell entête = new PdfPCell(new Phrase("CONFIRMATION DE LA RENCONTRE \n", new iTextSharp.text.Font(
                    iTextSharp.text.Font.NORMAL, 20f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE)));
                entête.BackgroundColor = new iTextSharp.text.BaseColor(0, 150, 50);
                entête.Colspan = 8;
                entête.HorizontalAlignment = 1;// 0= left , 1 = centre , 2 = right
                doc.Add(paragraph);
                table.AddCell(entête);
                doc.Add(table);
                doc.Add(Corp);
                doc.Add(signature_d);
                doc.Add(signature_g);
                doc.Close(); // fermer le document
            }
        }

        private void btnSignerRencontre_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Resultat.pdf", FileMode.Create));
            doc.Open(); // ouvrir le document ecrit
                        // ecrire le contenant du document
            iTextSharp.text.Image jpeg = iTextSharp.text.Image.GetInstance("logo.jpg");
            jpeg.ScalePercent(25f);
            jpeg.Alignment = 1;
            // Fonction pour background image
            iTextSharp.text.Image filigrane = iTextSharp.text.Image.GetInstance("Campo.png");
            filigrane.SetAbsolutePosition(20, 200);
            doc.Add(filigrane);
            //Watermark Background = new Watermark(Image.GetInstance("watermark.jpg"), 200, 420);
            //doc.Add(Background);
            // pour positionner l'image 
            //jpeg.SetAbsolutePosition(doc.PageSize.Width - 36f - 72f, doc.PageSize.Height - 30f - 216f);
            Paragraph date = new Paragraph(" Date________________\n\n\n");
            date.Alignment = 2;// 0= left , 1 = centre , 2 = right
            doc.Add(date);
            doc.Add(jpeg);
            Paragraph paragraph = new Paragraph("COMPETITION INTERNATIONAL DE FOOTBALL D'EUROPE..\n\n\n", new iTextSharp.text.Font(
                iTextSharp.text.Font.NORMAL, 30f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE));
            Paragraph Corp = new Paragraph("\n\n   Suite a la rencontre qui s'est effectuée le " + dgvResultat.CurrentRow.Cells["DateRen"].Value.ToString() + " Nous ressortons avec un de score de "+ dgvResultat.CurrentRow.Cells["EquipeDomic"].Value.ToString() + " " + dgvResultat.CurrentRow.Cells["vsresultat"].Value.ToString() + " " + dgvResultat.CurrentRow.Cells["EquipeAdv"].Value.ToString() + "  \n\n\n");
            paragraph.Alignment = 1;// 0= left , 1 = centre , 2 = right
            PdfPTable table = new PdfPTable(1);
            PdfPCell entête = new PdfPCell(new Phrase("RESULTAT DE LA RENCONTRE \n", new iTextSharp.text.Font(
                iTextSharp.text.Font.NORMAL, 20f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE)));
            entête.BackgroundColor = new iTextSharp.text.BaseColor(150, 150, 50);
            entête.Colspan = 8;
            entête.HorizontalAlignment = 1;// 0= left , 1 = centre , 2 = right
            doc.Add(paragraph);
            table.AddCell(entête);
            doc.Add(table);
            doc.Add(Corp);
            doc.Close(); // fermer le document
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Resultats Non Disponible : EN ATTENTE DE RENCONTRE EFFECTUER !!", " ATTENTION ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMiseajourCalen_Click(object sender, EventArgs e)
        {
            GestionDesSemaines(dgvCalendrier, Semaine_Ref, ActueSemaine);
        }

        private void GestionDesSemaines(DataGridView dgv ,  int SemRef , int Sem)
        {
            
            dtRencontre = new DataTable();
            dtRencontre.Columns.Add(new DataColumn("IdRencontre", System.Type.GetType("System.Int32")));
            dtRencontre.Columns.Add("DateHeure");
            dtRencontre.Columns.Add("EquipeDomi");
            dtRencontre.Columns.Add("vs");
            dtRencontre.Columns.Add("EquipeVisit");
            EquiTmp = new G_T_Equipe(Conn).Lire("IdEquipe");
            RenTmp = new G_T_Rencontre(Conn).Lire("Equi");
            CbTmp = new G_T_Club(Conn).Lire("IdClub");
            int num_semaineref = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear
                    (DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            tbsemaine.Text = num_semaineref.ToString();
            foreach (C_T_Rencontre Tmp in RenTmp)
            {
                int num_Semaine = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear
                    (Tmp.DateRencontre, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                if (num_Semaine == num_semaineref)
                {

                    C_T_Equipe recherche = EquiTmp.Find(X => X.IdEquipeDomicile == (Tmp.IdEquipeDomicile));
                    C_T_Equipe recherche2 = EquiTmp.Find(X => X.IdEquipeDomicile == (Tmp.IdEquipeVisiteuse));

                    C_T_Equipe seachEquipe = EquiTmp.Find(X => X.IdEquipeDomicile == Tmp.IdEquipeDomicile);
                    C_T_Equipe seachEquipeAdv = EquiTmp.Find(X => X.IdEquipeDomicile == Tmp.IdEquipeVisiteuse);
                    C_T_Club VerifCamp = CbTmp.Find(X => X.IdClub == seachEquipe.IdClub);
                    C_T_Club VerifCampAdv = CbTmp.Find(X => X.IdClub == seachEquipeAdv.IdClub);
                    if (!VerifCamp.ClubAdverse || !VerifCampAdv.ClubAdverse)
                        dtRencontre.Rows.Add(Tmp.IdRencontre, Tmp.DateRencontre, recherche.NomEquipeDomicile,
                            Tmp.ScoreRencontre, recherche2.NomEquipeDomicile);
                }

            }
            //else
            //        MessageBox.Show(" ERREUR DE CORRESPONDANCE !! ");
            bsRencontre = new BindingSource();
            bsRencontre.DataSource = dtRencontre;
            dgv.DataSource = bsRencontre;
        }
    }
}
