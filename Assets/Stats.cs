using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Stats {
    [SerializeField]
    AspectStats aspectStats;
    [SerializeField]
    CombatStats power, resistance;


    public Stats(AspectStats aspectStats, CombatStats power, CombatStats resistance){
        this.aspectStats = aspectStats;
        this.power = power;
        this.resistance = resistance;
    }

    public Stats Clone(){
        return new Stats(aspectStats.Clone(), power.Clone(), resistance.Clone()); 
    }

	public static Stats operator +(Stats s1, Stats s2){
        AspectStats aspect = new AspectStats();
        CombatStats power = new CombatStats();
        CombatStats resistance = new CombatStats();


        foreach(AspectEnum ae in System.Enum.GetValues(typeof(AspectEnum))){
            aspect[ae] = s1.aspectStats[ae] + s2.aspectStats[ae];
        }

        foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
            power[cse] = s1.power[cse] + s2.power[cse];
            resistance[cse] = s1.resistance[cse] + s2.resistance[cse];
        }


		return new Stats(aspect, power, resistance);
	}

}
