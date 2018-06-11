#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using NNGLBDCouClasse;
using NNGLBDCouAcces;
#endregion

namespace NNGLBDCouGestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class G_T_Membres : G_Base
 {
  #region Constructeurs
  public G_T_Membres()
   : base()
  { }
  public G_T_Membres(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string NomMembres, string PrenomMembres, string NationaliteMembres, DateTime DateNaissanceMembres, string FonctionMembres, string AdresseMembres, string LicenseMembres, int IdEquipe)
  { return new A_T_Membres(ChaineConnexion).Ajouter(NomMembres, PrenomMembres, NationaliteMembres, DateNaissanceMembres, FonctionMembres, AdresseMembres, LicenseMembres, IdEquipe); }
  public int Modifier(int IdMembres, string NomMembres, string PrenomMembres, string NationaliteMembres, DateTime DateNaissanceMembres, string FonctionMembres, string AdresseMembres, string LicenseMembres, int IdEquipe)
  { return new A_T_Membres(ChaineConnexion).Modifier(IdMembres, NomMembres, PrenomMembres, NationaliteMembres, DateNaissanceMembres, FonctionMembres, AdresseMembres, LicenseMembres, IdEquipe); }
  public List<C_T_Membres> Lire(string Index)
  { return new A_T_Membres(ChaineConnexion).Lire(Index); }
  public C_T_Membres Lire_ID(int IdMembres)
  { return new A_T_Membres(ChaineConnexion).Lire_ID(IdMembres); }
  public int Supprimer(int IdMembres)
  { return new A_T_Membres(ChaineConnexion).Supprimer(IdMembres); }
 }
}
