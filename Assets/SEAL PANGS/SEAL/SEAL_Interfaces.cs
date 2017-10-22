public interface ITick{
	IMultipliable Tick(IMultipliable dataContainer);
}


public interface IDamageTick{
	CombatStats DamageTick();
}
public interface IAidTick{
	Aid AidTick();
}

public interface IStackResolve<T>{
	T DropStats();
}