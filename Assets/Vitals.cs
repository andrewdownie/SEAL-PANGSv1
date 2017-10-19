using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Vitals {
	[SerializeField]
	[Range(0, 2147483583)]
	float health,
	stamina,
	mana;




	public void ApplyDamage(Stats playerStats, CombatStats damageToApply){

		foreach(CombatStatEnum cs in System.Enum.GetValues(typeof(CombatStatEnum))){
			switch(cs){
				case CombatStatEnum.stamina:
					stamina -= CalculateResultingDamage(damageToApply[CombatStatEnum.stamina], playerStats.ResistanceValue(CombatStatEnum.stamina));
					break;
				case CombatStatEnum.mana:
					mana -= CalculateResultingDamage(damageToApply[CombatStatEnum.mana], playerStats.ResistanceValue(CombatStatEnum.mana));
					break;
				default:
					health -= CalculateResultingDamage(damageToApply[cs], playerStats.ResistanceValue(cs));
					break;
			}

		}
		
	}


	float CalculateResultingDamage(float damage, float resistance){
		float damageDealt = Mathf.Sqrt( Mathf.Pow(damage, 2) - Mathf.Pow(resistance / 10, 2) );


		if(damageDealt < 0){
			damageDealt = 0;
		}


		if(damage > 0){
			if(damageDealt < 1){
				damageDealt = 1;
			}
		}

		return damageDealt;
	}

}
