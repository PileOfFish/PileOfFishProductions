using UnityEngine;
using System.Collections;

public class LandMine : MonoBehaviour 
{
    public int damage;
    public Transform explosion;
    private float timer;
    private float fireTimer;
    public bool destroyMe;
    private GameObject targetCount;
    public GameObject monster;

	// Use this for initialization
	void Start () 
    {
        renderer.material.color = Color.gray;
        timer = 0.0f;
        fireTimer = 0.0f;
        explosion = this.gameObject.transform.Find("Fireworks");
        explosion.active = false;
        destroyMe = false;
        targetCount = GameObject.Find("Main Camera");
        monster = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if (destroyMe)
        {
            fireTimer += Time.deltaTime;
        }

        if (destroyMe && fireTimer > 0.6f)
        {
            Debug.Log(targetCount.GetComponent<TargetMover>().mineCounter);
            targetCount.GetComponent<TargetMover>().mineCounter -= 1;
            Debug.Log(targetCount.GetComponent<TargetMover>().mineCounter);
            monster.GetComponent<Attack_Building>().inAction = false;
            Destroy(this.gameObject);
        }

        if (timer > 0.75f)
        {
            renderer.material.color = Color.red;
            timer = 0.0f;
        }
        else if(timer > 0.25f)
        {
            renderer.material.color = Color.gray;
        }
	}
}
