using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEA : MonoBehaviour {
	[Header("Level")]
	[SerializeField]
	Level level;
	[Header("Stats")]
	[SerializeField]
	Stats baseStats;
	[SerializeField]
	Stats attributedStats;
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

		effectiveStats = attributedStats.Clone(); //TODO: add stats from effects here
	}

	void OnValidate(){
		Debug.Log("validation occured -- updating component chain");

		UpdateComponentChain();
	}

}
