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
}
