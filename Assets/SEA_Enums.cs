public enum AttributeEnum{
	strength,
	agility,
	endurance,
	constitution,
	intelligence,
	wisdom,
	dexterity,
}

public enum AspectEnum {
	movement_speed,
	max_health,
	dodge,
	armour,
}

public enum CombatStatEnum{
	fire,
	ice,
	lightning,
	bleeding,
	blunt,
	sharp,
	piercing,
	normal,
	stamina,
	mana,
}

public enum EffectEnum{
	gear_buff,
	gear_curse,
	active_buff,
	active_curse,
	instant_buff,
	instant_curse,
	toggle_buff,
	toggle_curse,
}

public enum TickDamageRateEnum{
	slow_oncePerSecond = 1,
	normal_twicePerSecond = 2,
	fast_fiveTimesPerSecond = 5,
	veryFast_tenTimesPerSecond = 10,
}