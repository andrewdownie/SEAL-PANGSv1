using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Effects {
	[SerializeField]
	List<Effect> characterBuffs;
	
	[SerializeField]
	List<Effect> gearBuffs;
	[SerializeField]
	List<Effect> gearCurses;
	[SerializeField]
	List<Effect> activeBuffs;
	[SerializeField]
	List<Effect> activeCurses;
	[SerializeField]
	List<Effect> instantBuffs;
	[SerializeField]
	List<Effect> instantCurses;
	[SerializeField]
	List<Effect> toggleBuffs;
	[SerializeField]
	List<Effect> toggleCurses;


	public void AddEffect(Effect effect, EffectEnum effectType){
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
			foreach(Effect e in characterBuffs){
				a[ae] += e.AttributeValue(ae);
			}

			foreach(Effect e in activeBuffs){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(Effect e in gearBuffs){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(Effect e in instantBuffs){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(Effect e in toggleBuffs){
				a[ae] += e.AttributeValue(ae);
			}

			foreach(Effect e in activeCurses){
				a[ae] -= e.AttributeValue(ae);
			}
			foreach(Effect e in gearCurses){
				a[ae] -= e.AttributeValue(ae);
			}
			foreach(Effect e in instantCurses){
				a[ae] -= e.AttributeValue(ae);
			}
			foreach(Effect e in toggleCurses){
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
			foreach(Effect e in characterBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}


			foreach(Effect e in activeBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(Effect e in gearBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(Effect e in instantBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(Effect e in toggleBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}


			foreach(Effect e in activeBuffs){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(Effect e in activeCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(Effect e in gearCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(Effect e in instantCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(Effect e in toggleCurses){
				aspect[ae] -= e.AspectValue(ae);
				aspect[ae] -= e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
		}



		foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
			foreach(Effect e in characterBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}


			foreach(Effect e in activeBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(Effect e in gearBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(Effect e in instantBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(Effect e in toggleBuffs){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}


			foreach(Effect e in activeCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(Effect e in gearCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(Effect e in instantCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(Effect e in toggleCurses){
				power[cse] -= e.PowerValue(cse);
				resistance[cse] -= e.ResistanceValue(cse);
				power[cse] -= e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] -= e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
		}


		return new Stats(aspect, power, resistance);
	}



	bool ApplyTickDamage(ref CombatStats damage, Effect e){
		CombatStats? nullableTickDamage = e.DamageTick();
		if(nullableTickDamage != null){
			CombatStats tickDamage = nullableTickDamage.Value;

			foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
				damage[cse] = tickDamage[cse];
			}

			return false;
		}

		return true;
	}

	public CombatStats CalculateDamage(){
		CombatStats damage = new CombatStats();


		foreach(Effect e in gearCurses){
			bool deleteItem = ApplyTickDamage(ref damage, e);
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
