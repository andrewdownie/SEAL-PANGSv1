using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Stats {
    [SerializeField]
    AspectStats aspectStats;
    [SerializeField]
    CombatStats power, resistance;


    public int AspectValue(AspectEnum ae){
        return aspectStats[ae];
    }

    public int PowerValue(CombatStatEnum combatStatEnum){
        return power[combatStatEnum];
    }

    public int ResistanceValue(CombatStatEnum combatStatEnum){
        return resistance[combatStatEnum];
    }

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

    public Stats MultiplyCombatStats(float multiplier){
        CombatStats power = new CombatStats();

        foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
            power[cse] = Mathf.RoundToInt(this.power[cse] * multiplier);
            resistance[cse] = Mathf.RoundToInt(this.resistance[cse] * multiplier);
        }

        return new Stats(aspectStats, power, resistance);
    }


    public static Stats operator *(float multiplier, Stats s){
        AspectStats aspect = new AspectStats();
        CombatStats power = new CombatStats();
        CombatStats resistance = new CombatStats();


        foreach(AspectEnum ae in System.Enum.GetValues(typeof(AspectEnum))){
            aspect[ae] = Mathf.RoundToInt(s.aspectStats[ae] * multiplier);
        }

        foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
            power[cse] = Mathf.RoundToInt(s.power[cse] * multiplier);
            resistance[cse] = Mathf.RoundToInt(s.resistance[cse] * multiplier);
        }


        return new Stats(aspect, power, resistance);
    }

}
