using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEA : MonoBehaviour {
	[SerializeField]
	Level level;
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
	

	public void UpdateComponentChain(){
		level.CalculateLevel();

		effectiveAttributes = baseAttributes + effects.CalculateAttributes(); 

		attributedStats = baseStats + StatAttRatio.AttributesToStats(effectiveAttributes);

		multipliedStats = attributedStats.MultiplyCombatStats(level.multiplierPercent);

		effectiveStats = multipliedStats + effects.CalculateStats(multipliedStats);//TODO: should this use multiplied or attributed?

	}

	void OnValidate(){
		Debug.Log("validation occured -- updating component chain");

		UpdateComponentChain();
	}

}
