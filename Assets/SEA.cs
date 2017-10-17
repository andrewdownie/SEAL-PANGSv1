using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEA : MonoBehaviour {
	[Header("Attributes")]
	[SerializeField]
	Attributes baseAttributes;
	[SerializeField]
	Attributes effectiveAttributes;

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
	

	public void UpdateComponentChain(){
		effectiveAttributes = baseAttributes + effects.CalculateAttributes(); 

		attributedStats = baseStats.Clone(); //TODO: add stats * atts here

		effectiveStats = attributedStats.Clone(); //TODO: add stats from effects here
	}

	void OnValidate(){
		Debug.Log("validation occured -- updating component chain");

		UpdateComponentChain();
	}

}
