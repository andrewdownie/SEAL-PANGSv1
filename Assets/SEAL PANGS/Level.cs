﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Level {
	[SerializeField]
	uint _experience;
	[SerializeField]
	uint _level;
	[SerializeField]
	float _multiplierPercent;


	public uint level{
		get{
			return _level;
		}
	}
	public uint experience{
		get{
			return _experience; 
		}
	}

	public float multiplierPercent{
		get{
			return _multiplierPercent;
		}
	}

	public void AddExperience(uint amount){
		_experience += amount;
		if(_experience < 1){
			_experience = 1;
		}
		CalculateLevel();
	}

	public void CalculateLevel(){
		_level = (uint)Mathf.FloorToInt(Mathf.Pow(_experience, 0.25f));
		if(_level < 1){
			_level = 1;
		}
		CalculateLevelMultiplier();
	}

	private void CalculateLevelMultiplier(){
		_multiplierPercent = (float)(Mathf.Pow(_level, 3) / (2 * _level) + 99.5) / 100;
		if(_multiplierPercent < 1){
			_multiplierPercent = 1;
		}
	}

}
