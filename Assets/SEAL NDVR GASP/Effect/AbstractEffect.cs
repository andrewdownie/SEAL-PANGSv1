using UnityEngine;

[System.Serializable]
public abstract class AbstractEffect {
	/*
	The base effect type. Does no damage, and doesn't heal.
	*/
	[SerializeField]
	protected Stats stats;
	[SerializeField]
	protected Stats percentStats;

	[SerializeField]
	protected Attributes attributes;


	public int AttributeValue(AttributeEnum ae){
		return attributes[ae];
	}

	public float AspectValue(AspectEnum ae){
		return stats.AspectValue(ae);
	}

	public float PowerValue(CombatStatEnum combatStatEnum){
		return stats.PowerValue(combatStatEnum);
	}

	public float ResistanceValue(CombatStatEnum combatStatEnum){
		return stats.ResistanceValue(combatStatEnum);
	}

	public float PercentAspectValue(AspectEnum ae){
		return percentStats.AspectValue(ae);
	}

	public float PercentPowerValue(CombatStatEnum combatStatEnum){
		return percentStats.PowerValue(combatStatEnum);
	}

	public float PercentResistanceValue(CombatStatEnum combatStatEnum){
		return percentStats.ResistanceValue(combatStatEnum);
	}

}
