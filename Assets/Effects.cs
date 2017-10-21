using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Effects {
	[SerializeField]
	List<StaticCurse> characterBuffs;
	
	[SerializeField]
	List<StaticCurse> gearBuffs;
	[SerializeField]
	List<StaticCurse> gearCurses;
	[SerializeField]
	List<ActiveCurse> activeBuffs;
	[SerializeField]
	List<ActiveCurse> activeCurses;
	[SerializeField]
	List<InstantCurse> instantBuffs;
	[SerializeField]
	List<InstantCurse> instantCurses;
	[SerializeField]
	List<StaticCurse> toggleBuffs;
	[SerializeField]
	List<StaticCurse> toggleCurses;


	public void AddEffect(AbstractEffect effect){
	/*	

		switch(effectType){
			case EffectTypeEnum.character_buff:
				characterBuffs.Add(effect);
				break;
			case EffectTypeEnum.active_buff:
				activeBuffs.Add(effect);
				break;
			case EffectTypeEnum.active_curse:
				activeCurses.Add(effect);
				break;
			case EffectTypeEnum.gear_buff:
				gearBuffs.Add(effect);
				break;
			case EffectTypeEnum.gear_curse:
				gearCurses.Add(effect);
				break;
			case EffectTypeEnum.instant_buff:
				instantBuffs.Add(effect);
				break;
			case EffectTypeEnum.instant_curse:
				instantCurses.Add(effect);
				break;
			case EffectTypeEnum.toggle_buff:
				toggleBuffs.Add(effect);
				break;
			case EffectTypeEnum.toggle_curse:
				toggleCurses.Add(effect);
				break;
		}

	*/
	}

	public Attributes CalculateAttributes(){
		Attributes a = new Attributes();
		

		foreach(AttributeEnum ae in System.Enum.GetValues(typeof(AttributeEnum))){
			foreach(StaticCurse e in characterBuffs){
				a[ae] += e.AttributeValue(ae);
			}

			foreach(ActiveCurse e in activeBuffs){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(StaticCurse e in gearBuffs){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(InstantCurse e in instantBuffs){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(StaticCurse e in toggleBuffs){
				a[ae] += e.AttributeValue(ae);
			}

			foreach(ActiveCurse e in activeCurses){
				a[ae] -= e.AttributeValue(ae);
			}
			foreach(StaticCurse e in gearCurses){
				a[ae] -= e.AttributeValue(ae);
			}
			foreach(ActiveCurse e in instantCurses){
				a[ae] -= e.AttributeValue(ae);
			}
			foreach(StaticCurse e in toggleCurses){
				a[ae] -= e.AttributeValue(ae);
			}
		}

		return a;
	}



	public Stats CalculateStats(Stats precursorStats){
        AspectStats aspect = new AspectStats();
        CombatStats power = new CombatStats();
        CombatStats resistance = new CombatStats();


		foreach(AspectEnum ae in System.Enum.GetValues(typeof(AspectEnum))){
			foreach(StaticCurse e in characterBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}


			foreach(ActiveCurse e in activeBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(StaticCurse e in gearBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(ActiveCurse e in instantBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(StaticCurse e in toggleBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}


			foreach(ActiveCurse e in activeBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(ActiveCurse e in activeCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(StaticCurse e in gearCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(ActiveCurse e in instantCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(StaticCurse e in toggleCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
		}



		foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
			foreach(StaticCurse e in characterBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}


			foreach(ActiveCurse e in activeBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(StaticCurse e in gearBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(ActiveCurse e in instantBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(StaticCurse e in toggleBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}


			foreach(ActiveCurse e in activeCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(StaticCurse e in gearCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(ActiveCurse e in instantCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(StaticCurse e in toggleCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
		}


		return new Stats(aspect, power, resistance);
	}


	// Static and Active effects apply their damage through ticks
	bool ApplyDamageTick(ref CombatStats damage, ref IDamageTick effect){
		CombatStats tickDamage = effect.DamageTick();
		if(tickDamage != null){

			foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
				damage[cse] += tickDamage[cse];
			}

			return false;
		}

		return true;
	}


	public CombatStats CalculateHealing(){
		CombatStats healing = new CombatStats();



		return healing;
	}

	public CombatStats CalculateDamage(){
		CombatStats damage = new CombatStats();

		for(int i = activeCurses.Count - 1; i >= 0; i--){
			IDamageTick effect = activeCurses[i];
			bool deleteItem = ApplyDamageTick(ref damage, ref effect);
			//activeCurses[i] = (ActiveCurse)e; //TODO: now that I use classes instead of structs, do I still need this line?
			if(deleteItem){
				activeCurses.RemoveAt(i);
			}
		}



		//TODO: update the mana and stamina methods to handle the new tick damage procedure
		//---------------------------------------------------------------------------------
		/* 
		foreach(Effect e in characterBuffs){
			damage[CombatStatEnum.mana] -= e.DamageValue(CombatStatEnum.mana);
			damage[CombatStatEnum.stamina] -= e.DamageValue(CombatStatEnum.stamina);
		}
		foreach(Effect e in gearBuffs){
			damage[CombatStatEnum.mana] -= e.DamageValue(CombatStatEnum.mana);
			damage[CombatStatEnum.stamina] -= e.DamageValue(CombatStatEnum.stamina);
		}
		foreach(Effect e in activeBuffs){
			damage[CombatStatEnum.mana] -= e.DamageValue(CombatStatEnum.mana);
			damage[CombatStatEnum.stamina] -= e.DamageValue(CombatStatEnum.stamina);
		}
		foreach(Effect e in instantBuffs){
			damage[CombatStatEnum.mana] -= e.DamageValue(CombatStatEnum.mana);
			damage[CombatStatEnum.stamina] -= e.DamageValue(CombatStatEnum.stamina);
		}
		foreach(Effect e in toggleBuffs){
			damage[CombatStatEnum.mana] -= e.DamageValue(CombatStatEnum.mana);
			damage[CombatStatEnum.stamina] -= e.DamageValue(CombatStatEnum.stamina);
		}
		*/

		return damage;
	}

}
