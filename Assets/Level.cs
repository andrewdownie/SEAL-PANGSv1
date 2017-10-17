using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Level {
	[SerializeField]
	int _experience;
	[SerializeField]
	int _level;
	[SerializeField]
	float _multiplier;


	public int level{
		get{
			return _level;
		}
	}
	public int experience{
		get{
			return _experience; 
		}
	}

	public float multiplier{
		get{
			return _multiplier;
		}
	}

	public void AddExperience(int amount){
		_experience += amount;
		CalculateLevel();
	}

	public void CalculateLevel(){
		_level = Mathf.FloorToInt(Mathf.Pow(_experience, 0.25f));
		CalculateLevelMultiplier();
	}

	private void CalculateLevelMultiplier(){
		double levelMultiplier = Mathf.Pow(_level, 3) / (2 * _level) + 99.5;
		_multiplier = (float)levelMultiplier;
	}

}
