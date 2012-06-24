using UnityEngine;
using System.Collections;

public class MonsterHealth : MonoBehaviour 
{
    public int health;
	public GameObject nextLevelBut;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (health <= 0)
        {
            nextLevelBut.transform.Translate(1,0,0);
			Destroy(this.gameObject);
        }
	
	}
}
