using UnityEngine;

[System.Serializable]
public struct Effect {
	[SerializeField]
	Stats stats;
	[SerializeField]
	Stats percentStats;

	[SerializeField]
	Attributes attributes;

	[SerializeField]
	CombatStats damage;

	[SerializeField]
	float durationInSeconds;
	[SerializeField]
	TickDamageRateEnum damageRate;


	[SerializeField]
	float timePassed;
	[SerializeField]
	int ticksUntilNextDamage;




	float DamageRatio(){
		/*
		Calculates the ratio of how much damage should be done
		per tick for damage over time (DOTs)
		*/
		return 1 / ( ((float)damageRate) * durationInSeconds);
	}
	
	int TicksUntilNextDamage(){
		int ticks = Mathf.CeilToInt((1000 / SEA.TICK_TIME) / ((float)damageRate));
		Debug.Log("Calc ticks till next: " + ticks);

		return ticks;
	}


	public CombatStats? DamageTick(){
		timePassed += SEA.TICK_TIME;
		ticksUntilNextDamage = ticksUntilNextDamage - 1;

		//Debug.Log(timePassed);


		if(timePassed >= durationInSeconds){
			Debug.Log("marker 1");
			return null;
		}

		Debug.Log("Ticks till next pre: " + ticksUntilNextDamage);
		if(ticksUntilNextDamage < 1){
			Debug.Log("marker 2");
			ticksUntilNextDamage = TicksUntilNextDamage();
			Debug.Log("Ticks till next post: " + ticksUntilNextDamage);

			CombatStats? resultDamage = damage * DamageRatio();
			return resultDamage;
		}

		return new CombatStats();
	}



	public int AttributeValue(AttributeEnum ae){
		return attributes[ae];
	}

	public float AspectValue(AspectEnum ae){
		return stats.AspectValue(ae);
	}

	public float PowerValue(CombatStatEnum combatStatEnum){
		return stats.PowerValue(combatStatEnum);
	}

	public float ResistanceValue(CombatStatEnum combatStatEnum){
		return stats.ResistanceValue(combatStatEnum);
	}

	public float DamageValue(CombatStatEnum cse){
		return damage[cse];
	}

	public float PercentAspectValue(AspectEnum ae){
		return percentStats.AspectValue(ae);
	}

	public float PercentPowerValue(CombatStatEnum combatStatEnum){
		return percentStats.PowerValue(combatStatEnum);
	}

	public float PercentResistanceValue(CombatStatEnum combatStatEnum){
		return percentStats.ResistanceValue(combatStatEnum);
	}

}
