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
 public class A_T_Equipe : ADBase
 {
  #region Constructeurs
  public A_T_Equipe(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string NomEquipeDomicile, string NiveauEquipeDomicile, int IdClub)
  {
   CreerCommande("AjouterT_Equipe");
   int res = 0;
   Commande.Parameters.Add("IdEquipeDomicile", SqlDbType.Int);
   Direction("IdEquipeDomicile", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@NomEquipeDomicile", NomEquipeDomicile);
   Commande.Parameters.AddWithValue("@NiveauEquipeDomicile", NiveauEquipeDomicile);
   Commande.Parameters.AddWithValue("@IdClub", IdClub);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("IdEquipeDomicile"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int IdEquipeDomicile, string NomEquipeDomicile, string NiveauEquipeDomicile, int IdClub)
  {
   CreerCommande("ModifierT_Equipe");
   int res = 0;
   Commande.Parameters.AddWithValue("@IdEquipeDomicile", IdEquipeDomicile);
   Commande.Parameters.AddWithValue("@NomEquipeDomicile", NomEquipeDomicile);
   Commande.Parameters.AddWithValue("@NiveauEquipeDomicile", NiveauEquipeDomicile);
   Commande.Parameters.AddWithValue("@IdClub", IdClub);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_T_Equipe> Lire(string Index)
  {
   CreerCommande("SelectionnerT_Equipe");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_T_Equipe> res = new List<C_T_Equipe>();
   while (dr.Read())
   {
    C_T_Equipe tmp = new C_T_Equipe();
    tmp.IdEquipeDomicile = int.Parse(dr["IdEquipeDomicile"].ToString());
    tmp.NomEquipeDomicile = dr["NomEquipeDomicile"].ToString();
    tmp.NiveauEquipeDomicile = dr["NiveauEquipeDomicile"].ToString();
    tmp.IdClub = int.Parse(dr["IdClub"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_T_Equipe Lire_ID(int IdEquipeDomicile)
  {
   CreerCommande("SelectionnerT_Equipe_ID");
   Commande.Parameters.AddWithValue("@IdEquipeDomicile", IdEquipeDomicile);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_T_Equipe res = new C_T_Equipe();
   while (dr.Read())
   {
    res.IdEquipeDomicile = int.Parse(dr["IdEquipeDomicile"].ToString());
    res.NomEquipeDomicile = dr["NomEquipeDomicile"].ToString();
    res.NiveauEquipeDomicile = dr["NiveauEquipeDomicile"].ToString();
    res.IdClub = int.Parse(dr["IdClub"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int IdEquipeDomicile)
  {
   CreerCommande("SupprimerT_Equipe");
   int res = 0;
   Commande.Parameters.AddWithValue("@IdEquipeDomicile", IdEquipeDomicile);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
