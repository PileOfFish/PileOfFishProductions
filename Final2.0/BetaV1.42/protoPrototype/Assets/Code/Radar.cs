using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour 
{
    public int health;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerStay(Collider other)
    {
        Debug.Log("hit");
        health -= 5;

        other.GetComponent<AIFollow>().speed = 0;
        if (health <= 0)
        {
            other.GetComponent<AIFollow>().speed = 2;
        }
    }
}
