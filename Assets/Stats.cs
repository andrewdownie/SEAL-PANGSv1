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

}
