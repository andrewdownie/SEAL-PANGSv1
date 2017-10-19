﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEA : MonoBehaviour {

	[SerializeField]
	Level level;
	[SerializeField]
	Vitals vitals;


	[Header("Stats")]
	[SerializeField]
	Stats baseStats;
	[SerializeField]
	Stats attributedStats;
	[SerializeField]
	Stats multipliedStats;
	[SerializeField]
	Stats effectiveStats;


	[Header("Effects")]
	[SerializeField]
	Effects effects;


	[Header("Attributes")]
	[SerializeField]
	Attributes baseAttributes;
	[SerializeField]
	Attributes effectiveAttributes;
	
	public static float TICK_TIME{
		get{
			return 0.020f;
		}
	}

	public void UpdateSEA(){
		// update level
		level.CalculateLevel();

		// update attributes
		effectiveAttributes = baseAttributes + effects.CalculateAttributes(); 

		// update stats
		attributedStats = baseStats + StatAttRatio.AttributesToStats(effectiveAttributes);
		multipliedStats = attributedStats.MultiplyCombatStats(level.multiplierPercent);
		effectiveStats = multipliedStats + effects.CalculateStats(multipliedStats);
	}

	void OnValidate(){
		Debug.Log("validation occured -- updating SEA");
		UpdateSEA();
	}

	void Start(){
		InvokeRepeating("SEAUpdate", 0f, TICK_TIME);
	}

	void SEAUpdate()
    {
		Debug.Log("This is sea coroutine");
		UpdateSEA();
		ApplyEffectDamage();
    }



	void ApplyEffectDamage(){
		CombatStats aggregatedDamage = effects.CalculateDamage();
		vitals.ApplyDamage(effectiveStats, aggregatedDamage);

	}

}
