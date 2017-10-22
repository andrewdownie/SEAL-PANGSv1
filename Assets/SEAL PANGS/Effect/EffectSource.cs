using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EffectSource {
	//NOTE: this would have to be changed to network id for multiplayer? (unless everything is 100% server side?)
	[SerializeField]
	GameObject player;
	[SerializeField]
	string source;

	public GameObject CreatingPlayer{
		get{return player;}
	}
	public string Source{
		get{return source;}
	}

	public EffectSource(GameObject player, string source){
		this.source = source;
		this.player = player;
	}
}
