using UnityEngine;
using System.Collections;

public class PlantMonitor : MonoBehaviour 
{
    public int currentHealth;

	// Use this for initialization
	void Start () 
    {
        currentHealth = 5;
	}
	
	// Update is called once per frame
	void Update () 
    {
        guiText.text = currentHealth.ToString();

        if (currentHealth <= 0)
        {
            Application.LoadLevel(5);
			audio.Play();
        }
	}
}
