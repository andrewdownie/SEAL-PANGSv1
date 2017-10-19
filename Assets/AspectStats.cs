﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AspectStats {
	[SerializeField]
	[Range(0, 999)]
	float movement_speed,
	max_health,
	dodge;

	public AspectStats(float movement_speed, float max_health, float dodge){
		this.movement_speed = movement_speed;
		this.max_health = max_health;
		this.dodge = dodge;
	}

	public AspectStats Clone(){
		return new AspectStats(movement_speed, max_health, dodge);
	}


	public float this[AspectEnum se]{
		get{
			switch(se){
				case AspectEnum.movement_speed:
					return movement_speed;
				case AspectEnum.max_health:
					return max_health;
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
				case AspectEnum.dodge:
					dodge = value;
					break;
			}
		}

	}
}
