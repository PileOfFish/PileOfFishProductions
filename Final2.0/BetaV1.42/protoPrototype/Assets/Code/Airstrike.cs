using UnityEngine;
using System.Collections;

public class Airstrike : MonoBehaviour 
{
    public int damage;
    public float duration;
    private float timer;
    private GameObject targetCount;
    public GameObject monster;
    public GameObject attachedArea;

	// Use this for initialization
	void Start () 
    {
        timer = 0.0f;
        targetCount = GameObject.Find("Main Camera");
        monster = GameObject.Find("Player");
        attachedArea = targetCount.GetComponent<TargetMover>().attachedArea;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if (timer > duration)
        {
            targetCount.GetComponent<TargetMover>().airstrikeCounter -= 1;
            monster.GetComponent<Attack_Building>().inAction = false;
            Destroy(attachedArea);
            Destroy(this.gameObject);
        }
	}
}
