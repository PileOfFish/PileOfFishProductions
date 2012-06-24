using UnityEngine;
using System.Collections;

public class LevelButton : MonoBehaviour
{
	public int levelInt;
	
	void OnMouseDown()
    {
		Application.LoadLevel(levelInt);
	}
	
}
