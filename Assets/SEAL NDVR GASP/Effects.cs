using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public struct Effects {
	[SerializeField]
	List<StaticBuff> characterBuffs;
	
	[SerializeField]
	List<StaticBuff> gearBuffs;
	[SerializeField]
	List<StaticCurse> gearCurses;
	[SerializeField]
	List<ActiveBuff> activeBuffs;
	[SerializeField]
	List<ActiveCurse> activeCurses;
	[SerializeField]
	List<InstantBuff> instantBuffs;
	[SerializeField]
	List<InstantCurse> instantCurses;
	[SerializeField]
	List<StaticBuff> toggleBuffs;
	[SerializeField]
	List<StaticCurse> toggleCurses;


	//=====
	//=====
	//=====		Public Methods ------------------------------------------------
	//=====
	//=====

	//
	// Add only
	//
	public void AddActiveBuff(ActiveBuff item){
		activeBuffs.Add(item);
	}
	public void AddActiveCurse(ActiveCurse item){
		activeCurses.Add(item);
	}
	public void AddInstantBuff(InstantBuff item){
		instantBuffs.Add(item);
	}
	public void AddInstantCurse(InstantCurse item){
		instantCurses.Add(item);
	}

	//
	// Add and Remove
	//
	public void AddGearBuff(StaticBuff item){
		gearBuffs.Add(item);
	}
	public void RemoveGearBuff(StaticBuff item){
		gearBuffs.Remove(item);
	}
	public void AddGearCurse(StaticCurse item){
		gearCurses.Add(item);
	}
	public void RemoveGearCurse(StaticCurse item){
		gearCurses.Remove(item);
	}


	public void AddCharacterBuff(StaticBuff item){
		characterBuffs.Add(item);
	}
	public void RemoveCharacterBuff(StaticBuff item){
		characterBuffs.Remove(item);
	}
	public void AddToggleBuff(StaticBuff item){
		toggleBuffs.Add(item);
	}
	public void RemoveToggleBuff(StaticBuff item){
		toggleBuffs.Remove(item);
	}
	public void AddToggleCurse(StaticCurse item){
		toggleCurses.Add(item);
	}
	public void RemoveToggleCurse(StaticCurse item){
		toggleCurses.Remove(item);
	}


	//
	// Calculations
	//
	public Attributes CalculateAttributes(){
		Attributes a = new Attributes();
		
		foreach(AttributeEnum ae in System.Enum.GetValues(typeof(AttributeEnum))){
			AddAttribute(ae, ref a, characterBuffs);
			AddAttribute(ae, ref a, gearBuffs);
			AddAttribute(ae, ref a, activeBuffs);
			AddAttribute(ae, ref a, instantBuffs);
			AddAttribute(ae, ref a, toggleBuffs);

			SubtractAttribute(ae, ref a, gearCurses);
			SubtractAttribute(ae, ref a, activeCurses);
			SubtractAttribute(ae, ref a, instantCurses);
			SubtractAttribute(ae, ref a, toggleCurses);
		}

		return a;
	}

	public Stats CalculateStats(Stats precursorStats){
        AspectStats aspect = new AspectStats();
        CombatStats power = new CombatStats();
        CombatStats resistance = new CombatStats();


		foreach(AspectEnum ae in System.Enum.GetValues(typeof(AspectEnum))){
			AddAspect(ae, precursorStats, characterBuffs, ref aspect);
			AddAspect(ae, precursorStats, gearBuffs, ref aspect);
			AddAspect(ae, precursorStats, activeBuffs, ref aspect);
			AddAspect(ae, precursorStats, instantBuffs, ref aspect);
			AddAspect(ae, precursorStats, toggleBuffs, ref aspect);

			SubtractAspect(ae, precursorStats, gearCurses, ref aspect);
			SubtractAspect(ae, precursorStats, activeCurses, ref aspect);
			SubtractAspect(ae, precursorStats, instantCurses, ref aspect);
			SubtractAspect(ae, precursorStats, toggleCurses, ref aspect);

		}



		foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
			AddPowerResistance(cse, precursorStats, ref power, ref resistance, characterBuffs);

			AddPowerResistance(cse, precursorStats, ref power, ref resistance, gearBuffs);
			AddPowerResistance(cse, precursorStats, ref power, ref resistance, activeBuffs);
			AddPowerResistance(cse, precursorStats, ref power, ref resistance, instantBuffs);
			AddPowerResistance(cse, precursorStats, ref power, ref resistance, toggleBuffs);

			SubtractPowerResistance(cse, precursorStats, ref power, ref resistance, gearCurses);
			SubtractPowerResistance(cse, precursorStats, ref power, ref resistance, activeCurses);
			SubtractPowerResistance(cse, precursorStats, ref power, ref resistance, instantCurses);
			SubtractPowerResistance(cse, precursorStats, ref power, ref resistance, toggleCurses);
		}


		return new Stats(aspect, power, resistance);
	}

	public CombatStats CalculateDamage(){
		CombatStats damage = new CombatStats();

		ApplyCurse_TickDamage(ref damage, gearCurses);
		ApplyCurse_TickDamage(ref damage, activeCurses);
		ApplyCurse_InstantDamage(ref damage);
		ApplyCurse_TickDamage(ref damage, toggleCurses);

		return damage;
	}

	public Aid CalculateHealing(){
		Aid healing = new Aid();

		ApplyBuff_TickAid(ref healing, characterBuffs);

		ApplyBuff_TickAid(ref healing, gearBuffs);
		ApplyBuff_TickAid(ref healing, activeBuffs);
		ApplyBuff_InstantAid(ref healing);
		ApplyBuff_TickAid(ref healing, toggleBuffs);

		return healing;
	}

	//=====
	//=====
	//=====		Private Helper Methods ----------------------------------------
	//=====
	//=====
	void AddAspect<T>(AspectEnum ae, Stats precursorStats, List<T> effectList, ref AspectStats aspect) where T : AbstractEffect{
			foreach(AbstractEffect e in effectList){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
	}
	void SubtractAspect<T>(AspectEnum ae, Stats precursorStats, List<T> effectList, ref AspectStats aspect) where T : AbstractEffect{
			foreach(AbstractEffect e in effectList){
				aspect[ae] += e.AspectValue(ae);
				aspect[ae] += e.PercentAspectValue(ae) * precursorStats.AspectValue(ae) / 100;
			}
	}

	void ApplyCurse_TickDamage<T>(ref CombatStats damage, List<T> curseList) where T : IDamageTick{
		for(int i = curseList.Count - 1; i >= 0; i--){
			IDamageTick idt = curseList[i];

			CombatStats tickDamage = idt.DamageTick();
			if(tickDamage != null){

				foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
					damage[cse] += tickDamage[cse];
				}
			}
			else{
				curseList.RemoveAt(i);
			}
		}
	}

	void ApplyCurse_InstantDamage(ref CombatStats damage){
		for(int i = instantCurses.Count - 1; i >= 0; i--){
			InstantCurse ic = instantCurses[i];
			foreach(CombatStatEnum cse in System.Enum.GetValues(typeof(CombatStatEnum))){
				damage[cse] += ic.DamageValue(cse);
			}
			
			instantCurses.RemoveAt(i);
		}
	}


	void ApplyBuff_TickAid<T>(ref Aid healing, List<T> aidList) where T : IAidTick{
		for(int i = aidList.Count - 1; i >= 0; i--){
			IAidTick idt = aidList[i];

			Aid aid = idt.AidTick();
			if(aid != null){

				foreach(AidEnum ae in System.Enum.GetValues(typeof(AidEnum))){
					healing[ae] += aid[ae];
				}
			}
			else{
				aidList.RemoveAt(i);
			}

		}
	}

	void ApplyBuff_InstantAid(ref Aid healing){
		for(int i = instantBuffs.Count - 1; i >= 0; i--){
			InstantBuff ib = instantBuffs[i];
			foreach(AidEnum ae in System.Enum.GetValues(typeof(AidEnum))){
				healing[ae] += ib.AidValue(ae);
			}
			
			instantBuffs.RemoveAt(i);
		}
	}

	void AddAttribute<T>(AttributeEnum ae, ref Attributes a, List<T> effectList) where T : AbstractEffect{
		foreach(AbstractEffect e in effectList){
			a[ae] += e.AttributeValue(ae);
		}
	}
	void SubtractAttribute<T>(AttributeEnum ae, ref Attributes a, List<T> effectList) where T : AbstractEffect{
		foreach(AbstractEffect e in effectList){
			a[ae] -= e.AttributeValue(ae);
		}
	}

	void AddPowerResistance<T>(CombatStatEnum cse, Stats precursorStats, ref CombatStats power, ref CombatStats resistance, List<T> buffList) where T: AbstractEffect{
		foreach(AbstractEffect e in buffList){
			power[cse] += e.PowerValue(cse);
			resistance[cse] += e.ResistanceValue(cse);
			power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
			resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
		}
	}

	void SubtractPowerResistance<T>(CombatStatEnum cse, Stats precursorStats, ref CombatStats power, ref CombatStats resistance, List<T> buffList) where T: AbstractEffect{
		foreach(AbstractEffect e in buffList){
			power[cse] += e.PowerValue(cse);
			resistance[cse] += e.ResistanceValue(cse);
			power[cse] += e.PercentPowerValue(cse) * precursorStats.PowerValue(cse) / 100;
			resistance[cse] += e.ResistanceValue(cse) * precursorStats.ResistanceValue(cse) / 100;
		}
	}

}
