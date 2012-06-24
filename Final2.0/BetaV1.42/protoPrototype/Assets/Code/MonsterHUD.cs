using UnityEngine;
using System.Collections;

public class MonsterHUD : MonoBehaviour 
{
    public GameObject monster;

	// Use this for initialization
	void Start () 
    {
       // monster = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
        monster = GameObject.Find("Player");
		guiText.text = monster.GetComponent<MonsterHealth>().health.ToString();
	}
}
