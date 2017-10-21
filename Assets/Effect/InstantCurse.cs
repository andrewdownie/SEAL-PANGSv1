using UnityEngine;

[System.Serializable]
public class InstantCurse : AbstractEffect {
	[SerializeField]
	protected CombatStats damage;


	public float DamageValue(CombatStatEnum cse){
		return damage[cse];
	}


}
