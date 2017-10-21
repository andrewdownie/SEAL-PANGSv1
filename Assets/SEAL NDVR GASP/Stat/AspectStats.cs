﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AspectStats {
	[SerializeField]
	float movement_speed,
	max_health,
	max_stamina,
	max_mana,
	dodge;

	public AspectStats(){
		movement_speed = 0;
		max_health = 0;
		max_stamina = 0;
		max_mana = 0;
		dodge = 0;
	}

	public AspectStats(float movement_speed, float max_health, float max_stamina, float max_mana, float dodge){
		this.movement_speed = movement_speed;
		this.max_health = max_health;
		this.max_stamina = max_stamina;
		this.max_mana= max_mana;
		this.dodge = dodge;
	}

	public void Clamp(){
		foreach(AspectEnum ae in System.Enum.GetValues(typeof(AspectEnum))){
			if(this[ae] < SEAL_Consts.MIN_ASPECT){
				this[ae] = SEAL_Consts.MIN_ASPECT;
			}
			else if(this[ae] > SEAL_Consts.MAX_ASPECT){
				this[ae] = SEAL_Consts.MAX_ASPECT;
			}
		}
	}

	public AspectStats Clone(){
		return new AspectStats(movement_speed, max_health, max_stamina, max_mana, dodge);
	}


	public float this[AspectEnum se]{
		get{
			switch(se){
				case AspectEnum.movement_speed:
					return movement_speed;
				case AspectEnum.max_health:
					return max_health;
				case AspectEnum.max_stamina:
					return max_stamina;
				case AspectEnum.max_mana:
					return max_mana;
				case AspectEnum.dodge:
					return dodge;
			}
			return 0;
		}

		set{
			switch(se){
				case AspectEnum.movement_speed:
					movement_speed = value;
					break;
				case AspectEnum.max_health:
					max_health = value;
					break;
				case AspectEnum.max_stamina:
					max_stamina = value;
					break;
				case AspectEnum.max_mana:
					max_mana = value;
					break;
				case AspectEnum.dodge:
					dodge = value;
					break;
			}
		}

	}
}
