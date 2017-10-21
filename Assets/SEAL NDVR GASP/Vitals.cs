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


	public void ApplyHealing(Stats playerStats, CombatStats healingToApply){
		health += healingToApply[CombatStatEnum.healing];
		stamina += healingToApply[CombatStatEnum.stamina];
		mana += healingToApply[CombatStatEnum.mana];

		Clamp(playerStats);
	}



	public void ApplyDamage(Stats playerStats, CombatStats damageToApply){

		foreach(CombatStatEnum cs in System.Enum.GetValues(typeof(CombatStatEnum))){
			switch(cs){
				case CombatStatEnum.stamina:
					stamina -= CalculateResultingDamage(damageToApply[CombatStatEnum.stamina], playerStats.ResistanceValue(CombatStatEnum.stamina));
					break;
				case CombatStatEnum.mana:
					mana -= CalculateResultingDamage(damageToApply[CombatStatEnum.mana], playerStats.ResistanceValue(CombatStatEnum.mana));
					break;
				case CombatStatEnum.healing:
					// Healing stat does no damage
					break;
				default:
					health -= CalculateResultingDamage(damageToApply[cs], playerStats.ResistanceValue(cs));
					break;
			}

		}
		

		Clamp(playerStats);
	}


	float CalculateResultingDamage(float damage, float resistance){
		// aka. apply resistance
		float damageDealt = Mathf.Sqrt( Mathf.Pow(damage, 2) - Mathf.Pow(resistance / 10, 2) );


		if(damageDealt < 0){
			damageDealt = 0;
		}


		return damageDealt;
	}


	public void Clamp(Stats playerStats){
		health = Mathf.Clamp(health, 0, playerStats.AspectValue(AspectEnum.max_health));
		stamina = Mathf.Clamp(stamina, 0, playerStats.AspectValue(AspectEnum.max_stamina));
		mana = Mathf.Clamp(mana, 0, playerStats.AspectValue(AspectEnum.max_mana));
	}

}
