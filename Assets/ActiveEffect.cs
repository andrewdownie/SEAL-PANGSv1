using UnityEngine;

[System.Serializable]
public class ActiveEffect : StaticEffect{
	[SerializeField]
	protected float durationInSeconds;
	[SerializeField]
	protected float timePassed;



	public override CombatStats? DamageTick(){
		timePassed += SEA.MS_PER_TICK;
		ticksUntilNextDamage = ticksUntilNextDamage - 1;

		if(timePassed >= durationInSeconds){
			return null;
		}

		if(ticksUntilNextDamage < 1){
			ticksUntilNextDamage = TicksUntilNextDamage();
			CombatStats? resultDamage = base.damage * DamageRatio(durationInSeconds);
			return resultDamage;
		}

		return new CombatStats();
	}


}
