using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Effects {
	[SerializeField]
	List<Effect> gearEffects;
	[SerializeField]
	List<Effect> activeEffects;
	[SerializeField]
	List<Effect> instantEffects;
	[SerializeField]
	List<Effect> toggleEffects;


	public void AddEffect(Effect effect, EffectEnum effectType){
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
	}

	public Attributes CalculateAttributes(){
		Attributes a = new Attributes();
		

		foreach(AttributeEnum ae in System.Enum.GetValues(typeof(AttributeEnum))){
			foreach(Effect e in activeEffects){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(Effect e in gearEffects){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(Effect e in instantEffects){
				a[ae] += e.AttributeValue(ae);
			}
			foreach(Effect e in toggleEffects){
				a[ae] += e.AttributeValue(ae);
			}
		}

		return a;
	}

	public Stats CalculateStats(Stats precursorStats){
        AspectStats aspect = new AspectStats();
        CombatStats power = new CombatStats();
        CombatStats resistance = new CombatStats();


		foreach(AspectEnum ae in System.Enum.GetValues(typeof(AspectEnum))){
			foreach(Effect e in activeEffects){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(Effect e in gearEffects){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(Effect e in instantEffects){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
			foreach(Effect e in toggleEffects){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
		}

		foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
			foreach(Effect e in activeEffects){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(Effect e in gearEffects){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(Effect e in instantEffects){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
			foreach(Effect e in toggleEffects){
				power[cse] += e.PowerValue(cse);
				resistance[cse] += e.ResistanceValue(cse);
				power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
				resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
			}
		}


		return new Stats(aspect, power, resistance);
	}

}
