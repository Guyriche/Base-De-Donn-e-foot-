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
 public class G_T_Club : G_Base
 {
  #region Constructeurs
  public G_T_Club()
   : base()
  { }
  public G_T_Club(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string NomClub, string LocaliteClub, string AdresseClub, bool ClubAdverse)
  { return new A_T_Club(ChaineConnexion).Ajouter(NomClub, LocaliteClub, AdresseClub, ClubAdverse); }
  public int Modifier(int IdClub, string NomClub, string LocaliteClub, string AdresseClub, bool ClubAdverse)
  { return new A_T_Club(ChaineConnexion).Modifier(IdClub, NomClub, LocaliteClub, AdresseClub, ClubAdverse); }
  public List<C_T_Club> Lire(string Index)
  { return new A_T_Club(ChaineConnexion).Lire(Index); }
  public C_T_Club Lire_ID(int IdClub)
  { return new A_T_Club(ChaineConnexion).Lire_ID(IdClub); }
  public int Supprimer(int IdClub)
  { return new A_T_Club(ChaineConnexion).Supprimer(IdClub); }
 }
}
