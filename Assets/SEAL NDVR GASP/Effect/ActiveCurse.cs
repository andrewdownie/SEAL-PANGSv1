using UnityEngine;

[System.Serializable]
public class ActiveCurse : InstantCurse, IDamageTick{
	[SerializeField]
	ActiveTick activeTick;


    public CombatStats DamageTick()
    {
		  return (CombatStats)activeTick.Tick(damage);
    }
}
