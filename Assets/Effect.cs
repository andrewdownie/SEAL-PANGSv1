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
		float dmgRatio = 1 / ( ((float)damageRate) * durationInSeconds);
		Debug.Log("Ratio: " + dmgRatio);
		return dmgRatio;
	}
	
	int TicksUntilNextDamage(){
		int ticksUntilNextDamage = (int)(SEA.TICKS_PER_SECOND / ((float)damageRate));
		Debug.Log("Ticks till damage: " + ticksUntilNextDamage);

		return ticksUntilNextDamage;
	}


	[SerializeField]
	int timesDamageApplied;
	public CombatStats? DamageTick(){
		timePassed += SEA.MS_PER_TICK;
		ticksUntilNextDamage = ticksUntilNextDamage - 1;

		//Debug.Log(timePassed);


		if(timePassed >= durationInSeconds){
			Debug.Log("marker 1");
			return null;
		}

		if(ticksUntilNextDamage < 1){
			Debug.Log("marker 2");
			ticksUntilNextDamage = TicksUntilNextDamage();
			timesDamageApplied++;
			CombatStats? resultDamage = damage * DamageRatio();
			Debug.Log("Damage per tick: " + resultDamage.Value[CombatStatEnum.normal]);
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
