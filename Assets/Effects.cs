using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Effects {
	[SerializeField]
	List<StaticEffect> characterBuffs;
	
	[SerializeField]
	List<StaticEffect> gearBuffs;
	[SerializeField]
	List<StaticEffect> gearCurses;
	[SerializeField]
	List<ActiveEffect> activeBuffs;
	[SerializeField]
	List<ActiveEffect> activeCurses;
	[SerializeField]
	List<InstantEffect> instantBuffs;
	[SerializeField]
	List<InstantEffect> instantCurses;
	[SerializeField]
	List<StaticEffect> toggleBuffs;
	[SerializeField]
	List<StaticEffect> toggleCurses;


	public void AddEffect(ActiveEffect effect, EffectEnum effectType){
		/*
		switch(effectType){
			case EffectEnum.active:
				activeEffects.Add(effect);
				break;
			case EffectEnum.gear:
				gearEffects.Add(effect);
				break;
			case EffectEnum.instant:
				instantEffects.Add(effect);
				break;
			case EffectEnum.toggle:
				toggleEffects.Add(effect);
				break;
		}
		*/
	}

	public Attributes CalculateAttributes(){
		Attributes a = new Attributes();
		

		foreach(AttributeEnum ae in System.Enum.GetValues(typeof(AttributeEnum))){
			foreach(StaticEffect e in characterBuffs){
				a[ae] += e.AttributeValue(ae);
			}

			foreach(ActiveEffect e in activeBuffs){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(StaticEffect e in gearBuffs){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(InstantEffect e in instantBuffs){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(StaticEffect e in toggleBuffs){
				a[ae] += e.AttributeValue(ae);
			}

			foreach(ActiveEffect e in activeCurses){
				a[ae] -= e.AttributeValue(ae);
			}
			foreach(StaticEffect e in gearCurses){
				a[ae] -= e.AttributeValue(ae);
			}
			foreach(ActiveEffect e in instantCurses){
				a[ae] -= e.AttributeValue(ae);
			}
			foreach(StaticEffect e in toggleCurses){
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
			foreach(StaticEffect e in characterBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}


			foreach(ActiveEffect e in activeBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(StaticEffect e in gearBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(ActiveEffect e in instantBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(StaticEffect e in toggleBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}


			foreach(ActiveEffect e in activeBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(ActiveEffect e in activeCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(StaticEffect e in gearCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(ActiveEffect e in instantCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(StaticEffect e in toggleCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
		}



		foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
			foreach(StaticEffect e in characterBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}


			foreach(ActiveEffect e in activeBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(StaticEffect e in gearBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(ActiveEffect e in instantBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(StaticEffect e in toggleBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}


			foreach(ActiveEffect e in activeCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(StaticEffect e in gearCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(ActiveEffect e in instantCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(StaticEffect e in toggleCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
		}


		return new Stats(aspect, power, resistance);
	}



	bool ApplyTickDamage(ref CombatStats damage, ref ActiveEffect e){
		CombatStats? nullableTickDamage = e.DamageTick();
		if(nullableTickDamage != null){
			CombatStats tickDamage = nullableTickDamage.Value;

			foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
				damage[cse] += tickDamage[cse];
			}

			return false;
		}

		return true;
	}

	public CombatStats CalculateDamage(){
		CombatStats damage = new CombatStats();


		/*
		foreach(Effect e in gearCurses){
			bool deleteItem = ApplyTickDamage(ref damage, ref e);
			if(deleteItem){
				//TODO: remove the item from the list
			}
		}
		foreach(Effect e in activeCurses){
			bool deleteItem = ApplyTickDamage(ref damage, e);
			if(deleteItem){
				//TODO: remove the item from the list
			}
		}
		
		foreach(Effect e in instantBuffs){
			bool deleteItem = ApplyTickDamage(ref damage, e);
			if(deleteItem){
				//TODO: remove the item from the list
			}
		}

		foreach(Effect e in toggleBuffs){
			bool deleteItem = ApplyTickDamage(ref damage, e);
			if(deleteItem){
				//TODO: remove the item from the list
			}
		}
		*/

		//TODO: put this into a method
		for(int i = activeCurses.Count - 1; i >= 0; i--){
			ActiveEffect e = activeCurses[i];
			bool deleteItem = ApplyTickDamage(ref damage, ref e);
			activeCurses[i] = e;
			if(deleteItem){
				activeCurses.RemoveAt(i);
			}
		}


		//TODO: update the mana and stamina methods to handle the new tick damage procedure
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
