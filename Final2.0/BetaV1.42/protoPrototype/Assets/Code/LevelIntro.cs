using UnityEngine;
using System.Collections;

public class LevelIntro : MonoBehaviour
{
	public GameObject monster;
	public GameObject sun;
	public GameObject timeText;
	public GameObject moneyText;
	
	void OnMouseDown()
    {
		gameObject.SetActiveRecursively(false);
		monster.SetActiveRecursively(true);
		sun.SetActiveRecursively(true);
		timeText.SetActiveRecursively(true);
		moneyText.SetActiveRecursively(true);
	}
	
}
