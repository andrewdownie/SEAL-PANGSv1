using UnityEngine;

[System.Serializable]
public class ActiveBuff : InstantBuff, IAidTick{
	[SerializeField]
	ActiveTick activeTick;


    public Aid AidTick()
    {
		  return (Aid)activeTick.Tick(aid);
    }
    public ActiveBuff CloneWithoutStats(){
        return new ActiveBuff(activeTick, aid);
    }

    public ActiveBuff(ActiveTick tick, Aid aid){
        stats = new Stats();
        percentStats = new Stats();
        attributes = new Attributes();
        activeTick = tick;
        base.aid = aid;
    }
}
