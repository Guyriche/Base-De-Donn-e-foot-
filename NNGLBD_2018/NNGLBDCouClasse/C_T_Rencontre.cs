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
 public class C_T_Rencontre
 {
  #region Données membres
  private int _IdRencontre;
  private DateTime _DateRencontre;
  private string _ScoreRencontre;
  private int _IdEquipeDomicile;
  private int _IdEquipeVisiteuse;
  #endregion
  #region Constructeurs
  public C_T_Rencontre()
  { }
  public C_T_Rencontre(DateTime DateRencontre_, string ScoreRencontre_, int IdEquipeDomicile_, int IdEquipeVisiteuse_)
  {
   DateRencontre = DateRencontre_;
   ScoreRencontre = ScoreRencontre_;
   IdEquipeDomicile = IdEquipeDomicile_;
   IdEquipeVisiteuse = IdEquipeVisiteuse_;
  }
  public C_T_Rencontre(int IdRencontre_, DateTime DateRencontre_, string ScoreRencontre_, int IdEquipeDomicile_, int IdEquipeVisiteuse_)
   : this(DateRencontre_, ScoreRencontre_, IdEquipeDomicile_, IdEquipeVisiteuse_)
  {
   IdRencontre = IdRencontre_;
  }
  #endregion
  #region Accesseurs
  public int IdRencontre
  {
   get { return _IdRencontre; }
   set { _IdRencontre = value; }
  }
  public DateTime DateRencontre
  {
   get { return _DateRencontre; }
   set { _DateRencontre = value; }
  }
  public string ScoreRencontre
  {
   get { return _ScoreRencontre; }
   set { _ScoreRencontre = value; }
  }
  public int IdEquipeDomicile
  {
   get { return _IdEquipeDomicile; }
   set { _IdEquipeDomicile = value; }
  }
  public int IdEquipeVisiteuse
  {
   get { return _IdEquipeVisiteuse; }
   set { _IdEquipeVisiteuse = value; }
  }
  #endregion
 }
}
