using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CombatStats : IMultipliable{
	[SerializeField]
	float fire,
	ice,
	lightning,
	bleeding,
	blunt,
	sharp,
	piercing,
	normal,
	stamina,
	mana,
	healing;


	public CombatStats(){
		fire = 0;
		ice = 0;
		lightning = 0;
		bleeding = 0;
		blunt = 0;
		sharp = 0;
		piercing = 0;
		normal = 0;
		stamina = 0;
		mana = 0;
		healing = 0;
	}

	public CombatStats(float fire, float ice, float lightning, float bleeding,
						float blunt, float sharp, float piercing, float normal,
						float stamina, float mana, float healing){
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
		this.healing = healing;
	}

	public CombatStats Clone(){
		return new CombatStats(fire, ice, lightning, bleeding, blunt,
								sharp, piercing, normal, stamina, mana, healing);
	}

	public void Clamp(){
		foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){

			if(this[cse] > SEAL_Consts.MAX_COMBAT_STAT){
				this[cse] = SEAL_Consts.MAX_COMBAT_STAT;
			}
			else if(this[cse] < SEAL_Consts.MIN_COMBAT_STAT){
				this[cse] = SEAL_Consts.MIN_COMBAT_STAT;
			}
		}
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
				case CombatStatEnum.healing:
					return healing;
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
				case CombatStatEnum.healing:
					healing = value;
					break;
			}
		}
	}


	public static CombatStats operator *(float multiplier, CombatStats combatStats){
		return _Multiply(multiplier, combatStats);
	}
	public static CombatStats operator *(CombatStats combatStats, float multiplier){
		return _Multiply(multiplier, combatStats);
	}

	static CombatStats _Multiply(float multiplier, CombatStats combatStats){
		CombatStats result = new CombatStats();

		foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
			result[cse] = multiplier * combatStats[cse];
		}

		return result;
	}

    IMultipliable IMultipliable.Multiply(float constant)
    {
		return (IMultipliable)(_Multiply(constant, this));
    }
}
