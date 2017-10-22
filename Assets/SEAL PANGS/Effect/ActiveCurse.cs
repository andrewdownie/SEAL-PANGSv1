using UnityEngine;

[System.Serializable]
public class ActiveCurse : InstantCurse, IDamageTick{
	[SerializeField]
	ActiveTick activeTick;


    public CombatStats DamageTick()
    {
		  return (CombatStats)activeTick.Tick(damage);
    }

    public ActiveCurse CloneWithoutStats(){
        return new ActiveCurse(activeTick, damage);
    }

    public ActiveCurse(ActiveTick tick, CombatStats damage){
        stats = new Stats();
        percentStats = new Stats();
        attributes = new Attributes();
        activeTick = tick;
        base.damage = damage;
    }

}
