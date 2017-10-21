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
	max_stamina,
	max_mana,
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
	healing,
}

public enum EffectTypeEnum{
	character_buff,
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

public enum AidEnum{
	health,
	stamina,
	mana,
}
public enum EffectTickStatusEnum{
	no_damage,
	damage,
	effect_over,
}