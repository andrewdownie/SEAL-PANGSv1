using UnityEngine;

[System.Serializable]
public class StaticCurse : InstantCurse, IDamageTick{
	[SerializeField]
	StaticTick staticTick;


    public CombatStats DamageTick()
    {
		return (CombatStats)staticTick.Tick(damage);
    }
}
