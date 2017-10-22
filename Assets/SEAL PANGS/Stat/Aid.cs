using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Aid : IMultipliable{
	[SerializeField]
	float health, mana, stamina;

	public float this[VitalsEnum ae]{
		get{
			switch(ae){
				case VitalsEnum.health:
					return health;
				case VitalsEnum.stamina:
					return stamina;
				case VitalsEnum.mana:
					return mana;
			}

			return 0;
		}
		set{
			switch(ae){
				case VitalsEnum.health:
					health = value;
					break;
				case VitalsEnum.stamina:
					stamina = value;
					break;
				case VitalsEnum.mana:
					mana = value;
					break;
			}
		}
	}

	public static Aid operator *(float multiplier, Aid aid){
		return _Multiply(multiplier, aid);
	}
	public static Aid operator *(Aid aid, float multiplier){
		return _Multiply(multiplier, aid);
	}

	static Aid _Multiply(float multiplier, Aid aid){
		Aid result = new Aid();

		foreach(VitalsEnum ae in System.Enum.GetValues(typeof(VitalsEnum))){
			result[ae] = multiplier * aid[ae];
		}

		return result;
	}

    IMultipliable IMultipliable.Multiply(float constant)
    {
		return (IMultipliable)(_Multiply(constant, this));
    }
}
