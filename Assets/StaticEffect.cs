using UnityEngine;

[System.Serializable]
public class StaticEffect : InstantEffect{
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
			CombatStats? resultDamage = base.damage * DamageRatio();
			Debug.Log("Damage per tick: " + resultDamage.Value[CombatStatEnum.normal]);
			return resultDamage;
		}

		return new CombatStats();
	}



}
