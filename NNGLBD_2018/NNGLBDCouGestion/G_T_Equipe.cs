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
 public class G_T_Equipe : G_Base
 {
  #region Constructeurs
  public G_T_Equipe()
   : base()
  { }
  public G_T_Equipe(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string NomEquipeDomicile, string NiveauEquipeDomicile, int IdClub)
  { return new A_T_Equipe(ChaineConnexion).Ajouter(NomEquipeDomicile, NiveauEquipeDomicile, IdClub); }
  public int Modifier(int IdEquipeDomicile, string NomEquipeDomicile, string NiveauEquipeDomicile, int IdClub)
  { return new A_T_Equipe(ChaineConnexion).Modifier(IdEquipeDomicile, NomEquipeDomicile, NiveauEquipeDomicile, IdClub); }
  public List<C_T_Equipe> Lire(string Index)
  { return new A_T_Equipe(ChaineConnexion).Lire(Index); }
  public C_T_Equipe Lire_ID(int IdEquipeDomicile)
  { return new A_T_Equipe(ChaineConnexion).Lire_ID(IdEquipeDomicile); }
  public int Supprimer(int IdEquipeDomicile)
  { return new A_T_Equipe(ChaineConnexion).Supprimer(IdEquipeDomicile); }
 }
}
