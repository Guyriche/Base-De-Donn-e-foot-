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
 public class C_T_Equipe
 {
  #region Données membres
  private int _IdEquipeDomicile;
  private string _NomEquipeDomicile;
  private string _NiveauEquipeDomicile;
  private int _IdClub;
  #endregion
  #region Constructeurs
  public C_T_Equipe()
  { }
  public C_T_Equipe(string NomEquipeDomicile_, string NiveauEquipeDomicile_, int IdClub_)
  {
   NomEquipeDomicile = NomEquipeDomicile_;
   NiveauEquipeDomicile = NiveauEquipeDomicile_;
   IdClub = IdClub_;
  }
  public C_T_Equipe(int IdEquipeDomicile_, string NomEquipeDomicile_, string NiveauEquipeDomicile_, int IdClub_)
   : this(NomEquipeDomicile_, NiveauEquipeDomicile_, IdClub_)
  {
   IdEquipeDomicile = IdEquipeDomicile_;
  }
  #endregion
  #region Accesseurs
  public int IdEquipeDomicile
  {
   get { return _IdEquipeDomicile; }
   set { _IdEquipeDomicile = value; }
  }
  public string NomEquipeDomicile
  {
   get { return _NomEquipeDomicile; }
   set { _NomEquipeDomicile = value; }
  }
  public string NiveauEquipeDomicile
  {
   get { return _NiveauEquipeDomicile; }
   set { _NiveauEquipeDomicile = value; }
  }
  public int IdClub
  {
   get { return _IdClub; }
   set { _IdClub = value; }
  }
  #endregion
 }
}
