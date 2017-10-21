using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StaticTick : ITick{
	//Description: StaticTick's have their duration hard coded to 1, meaning they always 
	//				apply effects at the damageRate, and run forever 
	//					(
	//						StaticTicks run forever unless an outside action removes them:
	//						for example armour (gear effect) and sprinting (toggle effect) are examples of
	//						StaticTicks, as they don't have a known duration, and thus run at a constant
	//						rate until removed by an outside action.
	//						- maybe some armour heals the player at one health per second until they player takes the armour off,
	//						- maybe sprinting drains 5 stamina per second from the player until they stop sprinting,
	//					)

	[SerializeField]
	protected TickDamageRateEnum damageRate;
	protected int ticksUntilNextDamage;

	protected float rate{
		get{

			float rate = (float)damageRate;
			if(rate == 0){
				rate = 1;
			}
			return rate;
		}
	}


	protected float DamageRatio(float effectDuration){
		/*
		Calculates the ratio of how much damage should be done
		on a tick where damage is applied.
		*/
		float dmgRatio = 1 / (rate * effectDuration);
		return dmgRatio;
	}
	
	protected int TicksUntilNextDamage(){
		/*
		Calculates how many ticks before damage gets applied again.
		*/

		int ticksUntilNextDamage = (int)(SEAL.TICKS_PER_SECOND / rate);
		return ticksUntilNextDamage;
	}


	public virtual IMultipliable Tick(IMultipliable dataContainer){
		ticksUntilNextDamage = ticksUntilNextDamage - 1;

		if(ticksUntilNextDamage < 1){
			ticksUntilNextDamage = TicksUntilNextDamage();
			IMultipliable result = dataContainer.Multiply(DamageRatio(1));
			return result;
		}

		return dataContainer.Multiply(0);
	}

}


