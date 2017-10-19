using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct CombatStats {
	[SerializeField]
	[Range(0, 999)]
	float fire,
	ice,
	lightning,
	bleeding,
	blunt,
	sharp,
	piercing,
	normal,
	stamina,
	mana;

	public CombatStats(float fire, float ice, float lightning, float bleeding,
						float blunt, float sharp, float piercing, float normal,
						float stamina, float mana){
		this.fire = fire;
		this.ice = ice;
		this.lightning = lightning;
		this.bleeding = bleeding;
		this.blunt = blunt;
		this.sharp = sharp;
		this.piercing = piercing;
		this.normal = normal;
		this.stamina = stamina;
		this.mana = mana;
	}

	public CombatStats Clone(){
		return new CombatStats(fire, ice, lightning, bleeding, blunt,
								sharp, piercing, normal, stamina, mana);
	}

    public float this[CombatStatEnum cse]{
		get{
			switch(cse){
				case CombatStatEnum.fire:
					return fire;
				case CombatStatEnum.ice:
					return ice;
				case CombatStatEnum.lightning:
					return lightning;
				case CombatStatEnum.bleeding:
					return bleeding;
				case CombatStatEnum.blunt:
					return blunt;
				case CombatStatEnum.sharp:
					return sharp;
				case CombatStatEnum.piercing:
					return piercing;
				case CombatStatEnum.normal:
					return normal;
				case CombatStatEnum.stamina:
					return stamina;
				case CombatStatEnum.mana:
					return mana;
			}
			return 0;
		}

		set{
			switch(cse){
				case CombatStatEnum.fire:
					fire = value;
					break;
				case CombatStatEnum.ice:
					ice = value;
					break;
				case CombatStatEnum.lightning:
					lightning = value;
					break;
				case CombatStatEnum.bleeding:
					bleeding = value;
					break;
				case CombatStatEnum.blunt:
					blunt = value;
					break;
				case CombatStatEnum.sharp:
					sharp = value;
					break;
				case CombatStatEnum.piercing:
					piercing = value;
					break;
				case CombatStatEnum.normal:
					normal = value;
					break;
				case CombatStatEnum.stamina:
					stamina = value;
					break;
				case CombatStatEnum.mana:
					mana = value;
					break;
			}
		}
	}


	public static CombatStats operator *(float multiplier, CombatStats combatStats){
		return Multiply(multiplier, combatStats);
	}
	public static CombatStats operator *(CombatStats combatStats, float multiplier){
		return Multiply(multiplier, combatStats);
	}

	static CombatStats Multiply(float multiplier, CombatStats combatStats){
		CombatStats result = new CombatStats();

		foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
			result[cse] = multiplier * combatStats[cse];
		}

		return result;
	}

}
