using System.Collections.Generic;

public static class StatAttRatio {
//
// Variables ----------------------------------------------------------------------------
//
	static bool initialized = false;
	static Dictionary<AttributeEnum, Dictionary<CombatStatEnum, float>> powerRatio;
	static Dictionary<AttributeEnum, Dictionary<CombatStatEnum, float>> resistanceRatio;
	static Dictionary<AttributeEnum, Dictionary<AspectStatEnum, float>> aspectRatio;

//
// Setup --------------------------------------------------------------------------------
//
	public static void SetupRatios(){
	//
	// Setup the ratios between attributes and stats
	//	
		powerRatio[AttributeEnum.dexterity][CombatStatEnum.bleeding] = 5;



		aspectRatio[AttributeEnum.agility][AspectStatEnum.movement_speed] = 1;
	}

	public static void SetupSingleton(){
	//
	// Initialize the dict of dict's to hold zeros
	//
		powerRatio = new Dictionary<AttributeEnum, Dictionary<CombatStatEnum, float>>();
		resistanceRatio = new Dictionary<AttributeEnum, Dictionary<CombatStatEnum, float>>();
		aspectRatio = new Dictionary<AttributeEnum, Dictionary<AspectStatEnum, float>>();

		foreach(AttributeEnum ae in System.Enum.GetValues(typeof(AttributeEnum))){
			powerRatio.Add(ae, new Dictionary<CombatStatEnum, float>());
			resistanceRatio.Add(ae, new Dictionary<CombatStatEnum, float>());
			aspectRatio.Add(ae, new Dictionary<AspectStatEnum, float>());

			foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
				powerRatio[ae].Add(cse, 0);
				resistanceRatio[ae].Add(cse, 0);
			}

			foreach(AspectStatEnum aspectEnum in System.Enum.GetValues(typeof(AspectStatEnum))){
				aspectRatio[ae].Add(aspectEnum, 0);
			}
		}

		SetupRatios();

		initialized = true;
	}


//
// Get Ratios ---------------------------------------------------------------------------
//
	public static Stats AttributesToStats(Attributes attributes){
		if(!initialized){
			SetupSingleton();
		}


		AspectStats aspectStats = new AspectStats();
		CombatStats power = new CombatStats();
		CombatStats resistance = new CombatStats();


		foreach(AttributeEnum ae in System.Enum.GetValues(typeof(AttributeEnum))){

			foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
				power[cse] += powerRatio[ae][cse] * attributes[ae];
				resistance[cse] += resistanceRatio[ae][cse] * attributes[ae];
			}

			foreach(AspectStatEnum aspectEnum in System.Enum.GetValues(typeof(AspectStatEnum))){
				aspectStats[aspectEnum] += aspectRatio[ae][aspectEnum] * attributes[ae];
			}	
		}


		return new Stats(aspectStats, power, resistance);
	}


}
