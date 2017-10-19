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
	once_per_second = 1,
	twice_per_second = 2,
	four_times_per_second = 4,
	five_times_per_second = 5,
	ten_times_per_second = 10,
}