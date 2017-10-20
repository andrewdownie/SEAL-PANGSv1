using UnityEngine;

[System.Serializable]
public class StaticEffect : InstantEffect{
	[SerializeField]
	protected TickDamageRateEnum damageRate;
	protected int ticksUntilNextDamage;


	protected float DamageRatio(float effectDuration){
		/*
		Calculates the ratio of how much damage should be done
		per tick for damage over time (DOTs)
		*/
		float dmgRatio = 1 / ( ((float)damageRate) * effectDuration);
		Debug.Log("Ratio: " + dmgRatio);
		return dmgRatio;
	}
	
	protected int TicksUntilNextDamage(){
		int ticksUntilNextDamage = (int)(SEA.TICKS_PER_SECOND / ((float)damageRate));
		Debug.Log("Ticks till damage: " + ticksUntilNextDamage);

		return ticksUntilNextDamage;
	}


	public virtual CombatStats? DamageTick(){
		ticksUntilNextDamage = ticksUntilNextDamage - 1;

		if(ticksUntilNextDamage < 1){
			ticksUntilNextDamage = TicksUntilNextDamage();
			CombatStats? resultDamage = base.damage * DamageRatio(1);
			return resultDamage;
		}

		return new CombatStats();
	}

}
