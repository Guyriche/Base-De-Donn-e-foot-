#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace NNGLBDCouClasse
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class C_T_Membres
 {
  #region Données membres
  private int _IdMembres;
  private string _NomMembres;
  private string _PrenomMembres;
  private string _NationaliteMembres;
  private DateTime _DateNaissanceMembres;
  private string _FonctionMembres;
  private string _AdresseMembres;
  private string _LicenseMembres;
  private int _IdEquipe;
  #endregion
  #region Constructeurs
  public C_T_Membres()
  { }
  public C_T_Membres(string NomMembres_, string PrenomMembres_, string NationaliteMembres_, DateTime DateNaissanceMembres_, string FonctionMembres_, string AdresseMembres_, string LicenseMembres_, int IdEquipe_)
  {
   NomMembres = NomMembres_;
   PrenomMembres = PrenomMembres_;
   NationaliteMembres = NationaliteMembres_;
   DateNaissanceMembres = DateNaissanceMembres_;
   FonctionMembres = FonctionMembres_;
   AdresseMembres = AdresseMembres_;
   LicenseMembres = LicenseMembres_;
   IdEquipe = IdEquipe_;
  }
  public C_T_Membres(int IdMembres_, string NomMembres_, string PrenomMembres_, string NationaliteMembres_, DateTime DateNaissanceMembres_, string FonctionMembres_, string AdresseMembres_, string LicenseMembres_, int IdEquipe_)
   : this(NomMembres_, PrenomMembres_, NationaliteMembres_, DateNaissanceMembres_, FonctionMembres_, AdresseMembres_, LicenseMembres_, IdEquipe_)
  {
   IdMembres = IdMembres_;
  }
  #endregion
  #region Accesseurs
  public int IdMembres
  {
   get { return _IdMembres; }
   set { _IdMembres = value; }
  }
  public string NomMembres
  {
   get { return _NomMembres; }
   set { _NomMembres = value; }
  }
  public string PrenomMembres
  {
   get { return _PrenomMembres; }
   set { _PrenomMembres = value; }
  }
  public string NationaliteMembres
  {
   get { return _NationaliteMembres; }
   set { _NationaliteMembres = value; }
  }
  public DateTime DateNaissanceMembres
  {
   get { return _DateNaissanceMembres; }
   set { _DateNaissanceMembres = value; }
  }
  public string FonctionMembres
  {
   get { return _FonctionMembres; }
   set { _FonctionMembres = value; }
  }
  public string AdresseMembres
  {
   get { return _AdresseMembres; }
   set { _AdresseMembres = value; }
  }
  public string LicenseMembres
  {
   get { return _LicenseMembres; }
   set { _LicenseMembres = value; }
  }
  public int IdEquipe
  {
   get { return _IdEquipe; }
   set { _IdEquipe = value; }
  }
  #endregion
 }
}
