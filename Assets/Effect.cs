using UnityEngine;

[System.Serializable]
public struct Effect {
	[SerializeField]
	Stats stats;

	[SerializeField]
	Attributes attributes;

	[SerializeField]
	CombatStats damage;

	public int AttributeValue(AttributeEnum ae){
		return attributes[ae];
	}

}
