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
 public class A_T_Club : ADBase
 {
  #region Constructeurs
  public A_T_Club(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string NomClub, string LocaliteClub, string AdresseClub, bool ClubAdverse)
  {
   CreerCommande("AjouterT_Club");
   int res = 0;
   Commande.Parameters.Add("IdClub", SqlDbType.Int);
   Direction("IdClub", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@NomClub", NomClub);
   Commande.Parameters.AddWithValue("@LocaliteClub", LocaliteClub);
   Commande.Parameters.AddWithValue("@AdresseClub", AdresseClub);
   Commande.Parameters.AddWithValue("@ClubAdverse", ClubAdverse);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("IdClub"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int IdClub, string NomClub, string LocaliteClub, string AdresseClub, bool ClubAdverse)
  {
   CreerCommande("ModifierT_Club");
   int res = 0;
   Commande.Parameters.AddWithValue("@IdClub", IdClub);
   Commande.Parameters.AddWithValue("@NomClub", NomClub);
   Commande.Parameters.AddWithValue("@LocaliteClub", LocaliteClub);
   Commande.Parameters.AddWithValue("@AdresseClub", AdresseClub);
   Commande.Parameters.AddWithValue("@ClubAdverse", ClubAdverse);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_T_Club> Lire(string Index)
  {
   CreerCommande("SelectionnerT_Club");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_T_Club> res = new List<C_T_Club>();
   while (dr.Read())
   {
    C_T_Club tmp = new C_T_Club();
    tmp.IdClub = int.Parse(dr["IdClub"].ToString());
    tmp.NomClub = dr["NomClub"].ToString();
    tmp.LocaliteClub = dr["LocaliteClub"].ToString();
    tmp.AdresseClub = dr["AdresseClub"].ToString();
    tmp.ClubAdverse = bool.Parse(dr["ClubAdverse"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_T_Club Lire_ID(int IdClub)
  {
   CreerCommande("SelectionnerT_Club_ID");
   Commande.Parameters.AddWithValue("@IdClub", IdClub);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_T_Club res = new C_T_Club();
   while (dr.Read())
   {
    res.IdClub = int.Parse(dr["IdClub"].ToString());
    res.NomClub = dr["NomClub"].ToString();
    res.LocaliteClub = dr["LocaliteClub"].ToString();
    res.AdresseClub = dr["AdresseClub"].ToString();
    res.ClubAdverse = bool.Parse(dr["ClubAdverse"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int IdClub)
  {
   CreerCommande("SupprimerT_Club");
   int res = 0;
   Commande.Parameters.AddWithValue("@IdClub", IdClub);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
