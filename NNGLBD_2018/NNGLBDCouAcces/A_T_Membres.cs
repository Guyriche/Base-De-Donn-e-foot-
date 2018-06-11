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
 public class A_T_Membres : ADBase
 {
  #region Constructeurs
  public A_T_Membres(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string NomMembres, string PrenomMembres, string NationaliteMembres, DateTime DateNaissanceMembres, string FonctionMembres, string AdresseMembres, string LicenseMembres, int IdEquipe)
  {
   CreerCommande("AjouterT_Membres");
   int res = 0;
   Commande.Parameters.Add("IdMembres", SqlDbType.Int);
   Direction("IdMembres", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@NomMembres", NomMembres);
   Commande.Parameters.AddWithValue("@PrenomMembres", PrenomMembres);
   Commande.Parameters.AddWithValue("@NationaliteMembres", NationaliteMembres);
   Commande.Parameters.AddWithValue("@DateNaissanceMembres", DateNaissanceMembres);
   Commande.Parameters.AddWithValue("@FonctionMembres", FonctionMembres);
   Commande.Parameters.AddWithValue("@AdresseMembres", AdresseMembres);
   Commande.Parameters.AddWithValue("@LicenseMembres", LicenseMembres);
   Commande.Parameters.AddWithValue("@IdEquipe", IdEquipe);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("IdMembres"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int IdMembres, string NomMembres, string PrenomMembres, string NationaliteMembres, DateTime DateNaissanceMembres, string FonctionMembres, string AdresseMembres, string LicenseMembres, int IdEquipe)
  {
   CreerCommande("ModifierT_Membres");
   int res = 0;
   Commande.Parameters.AddWithValue("@IdMembres", IdMembres);
   Commande.Parameters.AddWithValue("@NomMembres", NomMembres);
   Commande.Parameters.AddWithValue("@PrenomMembres", PrenomMembres);
   Commande.Parameters.AddWithValue("@NationaliteMembres", NationaliteMembres);
   Commande.Parameters.AddWithValue("@DateNaissanceMembres", DateNaissanceMembres);
   Commande.Parameters.AddWithValue("@FonctionMembres", FonctionMembres);
   Commande.Parameters.AddWithValue("@AdresseMembres", AdresseMembres);
   Commande.Parameters.AddWithValue("@LicenseMembres", LicenseMembres);
   Commande.Parameters.AddWithValue("@IdEquipe", IdEquipe);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_T_Membres> Lire(string Index)
  {
   CreerCommande("SelectionnerT_Membres");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_T_Membres> res = new List<C_T_Membres>();
   while (dr.Read())
   {
    C_T_Membres tmp = new C_T_Membres();
    tmp.IdMembres = int.Parse(dr["IdMembres"].ToString());
    tmp.NomMembres = dr["NomMembres"].ToString();
    tmp.PrenomMembres = dr["PrenomMembres"].ToString();
    tmp.NationaliteMembres = dr["NationaliteMembres"].ToString();
    tmp.DateNaissanceMembres = DateTime.Parse(dr["DateNaissanceMembres"].ToString());
    tmp.FonctionMembres = dr["FonctionMembres"].ToString();
    tmp.AdresseMembres = dr["AdresseMembres"].ToString();
    tmp.LicenseMembres = dr["LicenseMembres"].ToString();
    tmp.IdEquipe = int.Parse(dr["IdEquipe"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_T_Membres Lire_ID(int IdMembres)
  {
   CreerCommande("SelectionnerT_Membres_ID");
   Commande.Parameters.AddWithValue("@IdMembres", IdMembres);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_T_Membres res = new C_T_Membres();
   while (dr.Read())
   {
    res.IdMembres = int.Parse(dr["IdMembres"].ToString());
    res.NomMembres = dr["NomMembres"].ToString();
    res.PrenomMembres = dr["PrenomMembres"].ToString();
    res.NationaliteMembres = dr["NationaliteMembres"].ToString();
    res.DateNaissanceMembres = DateTime.Parse(dr["DateNaissanceMembres"].ToString());
    res.FonctionMembres = dr["FonctionMembres"].ToString();
    res.AdresseMembres = dr["AdresseMembres"].ToString();
    res.LicenseMembres = dr["LicenseMembres"].ToString();
    res.IdEquipe = int.Parse(dr["IdEquipe"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int IdMembres)
  {
   CreerCommande("SupprimerT_Membres");
   int res = 0;
   Commande.Parameters.AddWithValue("@IdMembres", IdMembres);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
