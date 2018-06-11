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
 public class G_T_Rencontre : G_Base
 {
  #region Constructeurs
  public G_T_Rencontre()
   : base()
  { }
  public G_T_Rencontre(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(DateTime DateRencontre, string ScoreRencontre, int IdEquipeDomicile, int IdEquipeVisiteuse)
  { return new A_T_Rencontre(ChaineConnexion).Ajouter(DateRencontre, ScoreRencontre, IdEquipeDomicile, IdEquipeVisiteuse); }
  public int Modifier(int IdRencontre, DateTime DateRencontre, string ScoreRencontre, int IdEquipeDomicile, int IdEquipeVisiteuse)
  { return new A_T_Rencontre(ChaineConnexion).Modifier(IdRencontre, DateRencontre, ScoreRencontre, IdEquipeDomicile, IdEquipeVisiteuse); }
  public List<C_T_Rencontre> Lire(string Index)
  { return new A_T_Rencontre(ChaineConnexion).Lire(Index); }
  public C_T_Rencontre Lire_ID(int IdRencontre)
  { return new A_T_Rencontre(ChaineConnexion).Lire_ID(IdRencontre); }
  public int Supprimer(int IdRencontre)
  { return new A_T_Rencontre(ChaineConnexion).Supprimer(IdRencontre); }
 }
}
