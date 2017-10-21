using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActiveTick : StaticTick{
	//Description: ActiveTick's have variable durations, meaning they apply at their damageRate for x seconds
	//				after the duration is up, the effect should be destroyed
	[SerializeField]
	protected float durationInSeconds;
	protected float timePassed;



	public override IMultipliable Tick(IMultipliable dataContainer){
		timePassed += SEAL.MS_PER_TICK;
		ticksUntilNextDamage = ticksUntilNextDamage - 1;

		if(timePassed >= durationInSeconds){
			return null;
		}

		if(ticksUntilNextDamage < 1){
			ticksUntilNextDamage = TicksUntilNextDamage();
			IMultipliable result = dataContainer.Multiply(DamageRatio(durationInSeconds));
			return result;
		}

		return dataContainer.Multiply(0);
	}
}
