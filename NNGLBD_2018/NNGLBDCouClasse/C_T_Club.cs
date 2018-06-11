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
 public class C_T_Club
 {
  #region Données membres
  private int _IdClub;
  private string _NomClub;
  private string _LocaliteClub;
  private string _AdresseClub;
  private bool _ClubAdverse;
  #endregion
  #region Constructeurs
  public C_T_Club()
  { }
  public C_T_Club(string NomClub_, string LocaliteClub_, string AdresseClub_, bool ClubAdverse_)
  {
   NomClub = NomClub_;
   LocaliteClub = LocaliteClub_;
   AdresseClub = AdresseClub_;
   ClubAdverse = ClubAdverse_;
  }
  public C_T_Club(int IdClub_, string NomClub_, string LocaliteClub_, string AdresseClub_, bool ClubAdverse_)
   : this(NomClub_, LocaliteClub_, AdresseClub_, ClubAdverse_)
  {
   IdClub = IdClub_;
  }
  #endregion
  #region Accesseurs
  public int IdClub
  {
   get { return _IdClub; }
   set { _IdClub = value; }
  }
  public string NomClub
  {
   get { return _NomClub; }
   set { _NomClub = value; }
  }
  public string LocaliteClub
  {
   get { return _LocaliteClub; }
   set { _LocaliteClub = value; }
  }
  public string AdresseClub
  {
   get { return _AdresseClub; }
   set { _AdresseClub = value; }
  }
  public bool ClubAdverse
  {
   get { return _ClubAdverse; }
   set { _ClubAdverse = value; }
  }
  #endregion
 }
}
