using System.Collections.Generic;

public static class StatAttRatio {
//
// Variables ----------------------------------------------------------------------------
//
	static bool initialized = false;
	static Dictionary<AttributeEnum, Dictionary<CombatStatEnum, int>> powerRatio;
	static Dictionary<AttributeEnum, Dictionary<CombatStatEnum, int>> resistanceRatio;
	static Dictionary<AttributeEnum, Dictionary<AspectEnum, int>> aspectRatio;

//
// Setup --------------------------------------------------------------------------------
//
	public static void SetupRatios(){
	//
	// Setup the ratios between attributes and stats
	//	
		powerRatio[AttributeEnum.dexterity][CombatStatEnum.bleeding] = 5;
	}

	public static void SetupSingleton(){
	//
	// Initialize the dict of dict's to hold zeros
	//
		powerRatio = new Dictionary<AttributeEnum, Dictionary<CombatStatEnum, int>>();
		resistanceRatio = new Dictionary<AttributeEnum, Dictionary<CombatStatEnum, int>>();
		aspectRatio = new Dictionary<AttributeEnum, Dictionary<AspectEnum, int>>();

		foreach(AttributeEnum ae in System.Enum.GetValues(typeof(AttributeEnum))){
			powerRatio.Add(ae, new Dictionary<CombatStatEnum, int>());
			resistanceRatio.Add(ae, new Dictionary<CombatStatEnum, int>());
			aspectRatio.Add(ae, new Dictionary<AspectEnum, int>());

			foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
				powerRatio[ae].Add(cse, 0);
				resistanceRatio[ae].Add(cse, 0);
			}

			foreach(AspectEnum aspectEnum in System.Enum.GetValues(typeof(AspectEnum))){
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

			foreach(AspectEnum aspectEnum in System.Enum.GetValues(typeof(AspectEnum))){
				aspectStats[aspectEnum] += aspectRatio[ae][aspectEnum] * attributes[ae];
			}	
		}


		return new Stats(aspectStats, power, resistance);
	}


}
