using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour 
{
   public int levelNum;
	public int priorityNum;
    //private GameObject collector;
	
	
	void Start () 
   	{
        
   		//collector = GameObject.Find("GUI");
		//levelNum = 1;
		
	}
	
	void OnLevelWasLoaded(int level)
	{
		if(level == 1)
		{
			levelNum = 1;
		}
		if(level == 2)
		{
			levelNum = 2;
		}
		if(level == 3)
		{
			levelNum = 3;
		}
		if(level == 4)
		{
			levelNum = 4;
		}
			
	}
	
	
    void OnMouseDown()
    {
		Debug.Log ("Button Clicked and Stuff");
        if(levelNum == 1)
		{
			Application.LoadLevel(2);
		}
		if(levelNum == 2)
		{
			Application.LoadLevel(3);
		}
		if(levelNum == 3)
		{
			Application.LoadLevel(4);
		}
		if(levelNum == 4)
		{
			Application.LoadLevel(5);	
		}
     
        
        
    }

}
