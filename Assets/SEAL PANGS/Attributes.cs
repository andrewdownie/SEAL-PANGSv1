using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public struct Attributes {
/*
This is my attempt to create a attributes data structure that combines the ease of use
	of a dictionary, also works in the default Unity inspector, and that can be copied,
	and passed around with easy (meaning does not require inheritance from MonoBehaviour)
 */

	[SerializeField]
	uint strength,
	agility,
	uintelligence,
	endurance,
	constitution,
	dexterity;


	public Attributes(uint strength, uint agility, uint uintelligence, uint endurance, uint constitution, uint dexterity){
		this.strength = strength;
		this.agility = agility;
		this.uintelligence = uintelligence;
		this.endurance = endurance;
		this.constitution = constitution;
		this.dexterity = dexterity;
	}


	public void Clamp(){
		foreach(AttributeEnum ae in System.Enum.GetValues(typeof(AttributeEnum))){
			if(this[ae] < SEAL_Consts.MIN_ATTRIBUTE){
				this[ae] = SEAL_Consts.MIN_ATTRIBUTE;
			}
			else if(this[ae] > SEAL_Consts.MAX_ATTRIBUTE){
				this[ae] = SEAL_Consts.MAX_ATTRIBUTE;
			}
		}
	}

	public Attributes Clone(){
		return new Attributes(strength, agility, uintelligence, endurance, constitution, dexterity);
	}

	public static Attributes operator +(Attributes a1, Attributes a2){
		Attributes a = new Attributes();

		foreach(AttributeEnum ae in System.Enum.GetValues(typeof(AttributeEnum))){
			a[ae] = a1[ae] + a2[ae];
		}

		return a;
	}

    public uint this[AttributeEnum ae]{

		get{
			switch(ae){
				case AttributeEnum.strength:
					return strength;
				case AttributeEnum.agility:
					return agility;
				case AttributeEnum.intelligence:
					return uintelligence;
				case AttributeEnum.endurance:
					return endurance;
				case AttributeEnum.constitution:
					return constitution;
				case AttributeEnum.dexterity:
					return dexterity;
			}

			return 0;
		}

		set{
			switch(ae){
				case AttributeEnum.strength:
					strength = value;
					break;
				case AttributeEnum.agility:
					agility = value;
					break;
				case AttributeEnum.intelligence:
					uintelligence = value;
					break;
				case AttributeEnum.endurance:
					endurance = value;
					break;
				case AttributeEnum.constitution:
					constitution = value;
					break;
				case AttributeEnum.dexterity:
					dexterity = value;
					break;
			}
		}
	}


}
