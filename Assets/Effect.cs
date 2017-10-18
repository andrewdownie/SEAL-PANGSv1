using UnityEngine;

[System.Serializable]
public struct Effect {
	[SerializeField]
	Stats stats;
	[SerializeField]
	Stats percentStats;

	[SerializeField]
	Attributes attributes;

	[SerializeField]
	CombatStats damage;

	public int AttributeValue(AttributeEnum ae){
		return attributes[ae];
	}

	public int AspectValue(AspectEnum ae){
		return stats.AspectValue(ae);
	}

	public int PowerValue(CombatStatEnum combatStatEnum){
		return stats.PowerValue(combatStatEnum);
	}

	public int ResistanceValue(CombatStatEnum combatStatEnum){
		return stats.ResistanceValue(combatStatEnum);
	}
	public int PercentAspectValue(AspectEnum ae){
		return percentStats.AspectValue(ae);
	}

	public int PercentPowerValue(CombatStatEnum combatStatEnum){
		return percentStats.PowerValue(combatStatEnum);
	}

	public int PercentResistanceValue(CombatStatEnum combatStatEnum){
		return percentStats.ResistanceValue(combatStatEnum);
	}

}
