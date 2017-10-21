using UnityEngine;

[System.Serializable]
public class StaticBuff : InstantBuff, IAidTick{
	[SerializeField]
	StaticTick staticTick;


    public Aid AidTick()
    {
		return (Aid)staticTick.Tick(aid);
    }
}
