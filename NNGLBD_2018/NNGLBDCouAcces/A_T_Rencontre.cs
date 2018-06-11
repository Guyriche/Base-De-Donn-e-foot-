#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using NNGLBDCouClasse;
#endregion

namespace NNGLBDCouAcces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class A_T_Rencontre : ADBase
 {
  #region Constructeurs
  public A_T_Rencontre(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(DateTime DateRencontre, string ScoreRencontre, int IdEquipeDomicile, int IdEquipeVisiteuse)
  {
   CreerCommande("AjouterT_Rencontre");
   int res = 0;
   Commande.Parameters.Add("IdRencontre", SqlDbType.Int);
   Direction("IdRencontre", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@DateRencontre", DateRencontre);
   Commande.Parameters.AddWithValue("@ScoreRencontre", ScoreRencontre);
   Commande.Parameters.AddWithValue("@IdEquipeDomicile", IdEquipeDomicile);
   Commande.Parameters.AddWithValue("@IdEquipeVisiteuse", IdEquipeVisiteuse);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("IdRencontre"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int IdRencontre, DateTime DateRencontre, string ScoreRencontre, int IdEquipeDomicile, int IdEquipeVisiteuse)
  {
   CreerCommande("ModifierT_Rencontre");
   int res = 0;
   Commande.Parameters.AddWithValue("@IdRencontre", IdRencontre);
   Commande.Parameters.AddWithValue("@DateRencontre", DateRencontre);
   Commande.Parameters.AddWithValue("@ScoreRencontre", ScoreRencontre);
   Commande.Parameters.AddWithValue("@IdEquipeDomicile", IdEquipeDomicile);
   Commande.Parameters.AddWithValue("@IdEquipeVisiteuse", IdEquipeVisiteuse);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_T_Rencontre> Lire(string Index)
  {
   CreerCommande("SelectionnerT_Rencontre");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_T_Rencontre> res = new List<C_T_Rencontre>();
   while (dr.Read())
   {
    C_T_Rencontre tmp = new C_T_Rencontre();
    tmp.IdRencontre = int.Parse(dr["IdRencontre"].ToString());
    tmp.DateRencontre = DateTime.Parse(dr["DateRencontre"].ToString());
    tmp.ScoreRencontre = dr["ScoreRencontre"].ToString();
    tmp.IdEquipeDomicile = int.Parse(dr["IdEquipeDomicile"].ToString());
    tmp.IdEquipeVisiteuse = int.Parse(dr["IdEquipeVisiteuse"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_T_Rencontre Lire_ID(int IdRencontre)
  {
   CreerCommande("SelectionnerT_Rencontre_ID");
   Commande.Parameters.AddWithValue("@IdRencontre", IdRencontre);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_T_Rencontre res = new C_T_Rencontre();
   while (dr.Read())
   {
    res.IdRencontre = int.Parse(dr["IdRencontre"].ToString());
    res.DateRencontre = DateTime.Parse(dr["DateRencontre"].ToString());
    res.ScoreRencontre = dr["ScoreRencontre"].ToString();
    res.IdEquipeDomicile = int.Parse(dr["IdEquipeDomicile"].ToString());
    res.IdEquipeVisiteuse = int.Parse(dr["IdEquipeVisiteuse"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int IdRencontre)
  {
   CreerCommande("SupprimerT_Rencontre");
   int res = 0;
   Commande.Parameters.AddWithValue("@IdRencontre", IdRencontre);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
