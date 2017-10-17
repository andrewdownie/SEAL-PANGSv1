using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct CombatStats {
	[SerializeField]
	int fire,
	ice,
	lightning,
	bleeding,
	blunt,
	sharp,
	piercing,
	normal;

	public CombatStats(int fire, int ice, int lightning, int bleeding, int blunt, int sharp, int piercing, int normal){
		this.fire = fire;
		this.ice = ice;
		this.lightning = lightning;
		this.bleeding = bleeding;
		this.blunt = blunt;
		this.sharp = sharp;
		this.piercing = piercing;
		this.normal = normal;
	}

	public CombatStats Clone(){
		return new CombatStats(fire, ice, lightning, bleeding, blunt, sharp, piercing, normal);
	}

    public int this[CombatStatEnum cse]{
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
			}
		}
	}
}
