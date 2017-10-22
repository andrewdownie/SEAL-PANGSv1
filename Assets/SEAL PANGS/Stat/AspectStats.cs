using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AspectStats {
	[SerializeField]
	float movement_speed,
	max_health,
	max_stamina,
	max_mana,
	dodge,
	healing,
	aid_consumables;

	public AspectStats(){
		movement_speed = 0;
		max_health = 0;
		max_stamina = 0;
		max_mana = 0;
		dodge = 0;
		healing = 0;
		aid_consumables = 0;
	}

	public AspectStats(float movement_speed, float max_health, float max_stamina, float max_mana, float dodge, float healing, float aid_consumables){
		this.movement_speed = movement_speed;
		this.max_health = max_health;
		this.max_stamina = max_stamina;
		this.max_mana= max_mana;
		this.dodge = dodge;
		this.healing = healing;
		this.aid_consumables = aid_consumables;
	}

	public void Clamp(){
		foreach(AspectStatEnum ae in System.Enum.GetValues(typeof(AspectStatEnum))){
			if(this[ae] < SEAL_Consts.MIN_ASPECT){
				this[ae] = SEAL_Consts.MIN_ASPECT;
			}
			else if(this[ae] > SEAL_Consts.MAX_ASPECT){
				this[ae] = SEAL_Consts.MAX_ASPECT;
			}
		}
	}

	public AspectStats Clone(){
		return new AspectStats(movement_speed, max_health, max_stamina, max_mana, dodge, healing, aid_consumables);
	}


	public float this[AspectStatEnum se]{
		get{
			switch(se){
				case AspectStatEnum.movement_speed:
					return movement_speed;
				case AspectStatEnum.max_health:
					return max_health;
				case AspectStatEnum.max_stamina:
					return max_stamina;
				case AspectStatEnum.max_mana:
					return max_mana;
				case AspectStatEnum.dodge:
					return dodge;
				case AspectStatEnum.healing:
					return healing;
				case AspectStatEnum.aid_consumables:
					return aid_consumables;
			}
			return 0;
		}

		set{
			switch(se){
				case AspectStatEnum.movement_speed:
					movement_speed = value;
					break;
				case AspectStatEnum.max_health:
					max_health = value;
					break;
				case AspectStatEnum.max_stamina:
					max_stamina = value;
					break;
				case AspectStatEnum.max_mana:
					max_mana = value;
					break;
				case AspectStatEnum.dodge:
					dodge = value;
					break;
				case AspectStatEnum.aid_consumables:
					aid_consumables = value;
					break;
			}
		}

	}
}
