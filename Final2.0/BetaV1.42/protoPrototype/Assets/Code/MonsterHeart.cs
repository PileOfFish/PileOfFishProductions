using UnityEngine;
using System.Collections;

public class MonsterHeart : MonoBehaviour {
	
	public Texture FullHeart;
	public Texture ThreeQuarters;
	public Texture HalfHeart;
	public Texture OneQuarter;
	public Texture Empty;
	
	public GameObject monster;
	
	public int StartHealth;
	
	protected GUITexture myGUITexture;

	// Use this for initialization
	void Start () {
		//monster = GameObject.Find("Player");
		StartHealth = monster.GetComponent<MonsterHealth>().health;
		myGUITexture = GetComponent(typeof(GUITexture)) as GUITexture;
		myGUITexture.texture = FullHeart;
	}
	
	// Update is called once per frame
	void Update () {
		if(monster.GetComponent<MonsterHealth>().health <= (StartHealth * .75)) myGUITexture.texture = ThreeQuarters;
		if(monster.GetComponent<MonsterHealth>().health <= (StartHealth * .50)) myGUITexture.texture = HalfHeart;
		if(monster.GetComponent<MonsterHealth>().health <= (StartHealth * .25)) myGUITexture.texture = OneQuarter;
		if(monster.GetComponent<MonsterHealth>().health <= 0) myGUITexture.texture = Empty;
		//if(monster.GetComponent<MonsterHealth>().health < (StartHealth/2)) myGUITexture.texture = HalfHeart;
	}
}
