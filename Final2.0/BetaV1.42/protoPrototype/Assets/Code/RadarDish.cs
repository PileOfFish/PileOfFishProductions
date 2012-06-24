using UnityEngine;
using System.Collections;

public class RadarDish : MonoBehaviour 
{
    public int slowSpeedTo;
    private float timer;
    public int batteryLife;
    public bool activation;
    public float drainPerSec;
    public int drainAmount;
    public GameObject attachedBuilding;
    public GameObject attachedArea;
    private GameObject targetMover;
    private GameObject monster;
    GameObject color;

	// Use this for initialization
	void Start () 
    {
        timer = 0.0f;
        activation = false;
        targetMover = GameObject.Find("Main Camera");
        monster = GameObject.Find("Player");
        attachedBuilding = targetMover.GetComponent<TargetMover>().attachedObject;
        attachedArea = targetMover.GetComponent<TargetMover>().attachedArea;
        color = GameObject.Find("Root_Joint");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (activation)
        {
            timer += Time.deltaTime;

            if (timer > drainPerSec)
            {
                if (batteryLife <= 0)
                {
                    monster.GetComponent<Attack_Building>().slowEffect = false;
                    targetMover.GetComponent<TargetMover>().radarCounter -= 1;
                    monster.GetComponent<Attack_Building>().inAction = false;
                    Color myColor = Color.white;
                    color.renderer.material.color = myColor;
                    Destroy(attachedArea);
                    Destroy(this.gameObject);
                }
                else
                {
                    batteryLife -= drainAmount;
                }
                timer = 0.0f;
            }
        }

        if (attachedBuilding == null)
        {
            monster.GetComponent<Attack_Building>().slowEffect = false;
            targetMover.GetComponent<TargetMover>().radarCounter -= 1;
            monster.GetComponent<Attack_Building>().inAction = false;
            Color myColor = Color.white;
            color.renderer.material.color = myColor;
            Destroy(attachedArea);
            Destroy(this.gameObject);
        }
	}
}
