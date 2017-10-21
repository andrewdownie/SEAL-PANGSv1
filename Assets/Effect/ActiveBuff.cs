using UnityEngine;

[System.Serializable]
public class ActiveBuff : InstantBuff, IAidTick{
	[SerializeField]
	ActiveTick activeTick;


    public Aid AidTick()
    {
		  return (Aid)activeTick.Tick(aid);
    }
}
