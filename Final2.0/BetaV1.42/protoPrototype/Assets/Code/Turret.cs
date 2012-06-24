using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{
    private float timer;
    public int ammoCapacity;
    public int ammoPerSec;
    public bool activation;
    public float damagePerSec;
    public int damageAmount;
    public GameObject attachedBuilding;
    public GameObject attachedArea;
    private GameObject targetMover;
    public GameObject monster;
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

            if (timer > damagePerSec)
            {
                if(ammoCapacity <= 0)
                {
                    targetMover.GetComponent<TargetMover>().turretCounter -= 1;
                    monster.GetComponent<Attack_Building>().inAction = false;
                    Color myColor = Color.white;
                    color.renderer.material.color = myColor;
                    Destroy(attachedArea);
                    Destroy(this.gameObject);
                }
                else
                {
                    monster.GetComponent<MonsterHealth>().health -= damageAmount;
                    timer = 0.0f;
                    ammoCapacity -= ammoPerSec;
                }
            }
        }

        if (attachedBuilding == null)
        {
            targetMover.GetComponent<TargetMover>().turretCounter -= 1;
            monster.GetComponent<Attack_Building>().inAction = false;
            Color myColor = Color.white;
            color.renderer.material.color = myColor;
            Destroy(attachedArea);
            Destroy(this.gameObject);
        }
	}
}
