using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aid : IMultipliable{
	float health, mana, stamina;

	public float this[AidEnum ae]{
		get{
			switch(ae){
				case AidEnum.health:
					return health;
				case AidEnum.stamina:
					return stamina;
				case AidEnum.mana:
					return mana;
			}

			return 0;
		}
		set{
			switch(ae){
				case AidEnum.health:
					health = value;
					break;
				case AidEnum.stamina:
					stamina = value;
					break;
				case AidEnum.mana:
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

		foreach(AidEnum ae in System.Enum.GetValues(typeof(AidEnum))){
			result[ae] = multiplier * aid[ae];
		}

		return result;
	}

    IMultipliable IMultipliable.Multiply(float constant)
    {
		return (IMultipliable)(_Multiply(constant, this));
    }
}
