using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour 
{
    public int currentMoney;

	// Use this for initialization
	void Start () 
    {
        //currentMoney = 100;
	}
	
	// Update is called once per frame
	void Update () 
    {
        guiText.text = currentMoney.ToString(); 
	}
}
