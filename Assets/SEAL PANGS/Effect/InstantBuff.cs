using UnityEngine;

[System.Serializable]
public class InstantBuff : AbstractEffect {
	[SerializeField]
	protected Aid aid;


	public float AidValue(VitalsEnum ae){
		return aid[ae];
	}


}
