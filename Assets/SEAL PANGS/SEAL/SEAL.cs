using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEAL : MonoBehaviour {

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
	
	public static float MS_PER_TICK{
		get{
			return 1 / TICKS_PER_SECOND;
		}
	}
	public static float TICKS_PER_SECOND{
		get{
			return 50;
		}
	}

	public void UpdateSEA(){
		// update level
		level.CalculateLevel();

		// update attributes
		baseAttributes.Clamp();
		effectiveAttributes = baseAttributes + effects.CalculateAttributes(); 
		effectiveAttributes.Clamp();

		// update stats
		attributedStats = baseStats + StatAttRatio.AttributesToStats(effectiveAttributes);
		multipliedStats = attributedStats.MultiplyCombatStats(level.multiplierPercent);
		effectiveStats = multipliedStats + effects.CalculateStats(multipliedStats);
		effectiveStats.Clamp();

		// update vitals
		vitals.Clamp(effectiveStats);
	}

	void OnValidate(){
		Debug.Log("validation occured -- updating SEAL");
		UpdateSEA();
	}

	void Start(){
		InvokeRepeating("SEAL_Update", 0f, MS_PER_TICK);
	}

	void SEAL_Update()
    {
		Debug.Log("This is 'SEAL_Update'");
		UpdateSEA();
		ApplyEffectHealing();
		ApplyEffectDamage();
    }


	void ApplyEffectHealing(){
		Aid aggregatedAid = effects.CalculateHealing();
		vitals.ApplyHealing(effectiveStats, aggregatedAid);
	}

	void ApplyEffectDamage(){
		CombatStats aggregatedDamage = effects.CalculateDamage();
		vitals.ApplyDamage(effectiveStats, aggregatedDamage);

	}

}
