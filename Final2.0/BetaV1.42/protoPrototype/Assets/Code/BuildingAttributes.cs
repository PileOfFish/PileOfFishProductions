using UnityEngine;
using System.Collections;

public class BuildingAttributes : MonoBehaviour 
{
    public int buildingHealth;
    public GameObject buildingContainer;
    public GameObject resource;
    public GameObject ifPlant_Health;
    public GameObject gameOverState;
    public GameObject monster;
    public GameObject destructionEffect;
    public GameObject fire;
    public GameObject targetController;
    public float resourceGainTimer;
    private float timer;
    private bool doOnce;
    public int resourcePerSecond;
    public GameObject lastObject;

	// Use this for initialization
	void Start () 
    {
        buildingContainer = GameObject.Find("Buildings");
        buildingHealth = 1000;
        //resourceGainTimer = 3.0f;
       // resource = GameObject.Find("dynamic money text");
        ifPlant_Health = GameObject.Find("dynamic plant text");
        gameOverState = GameObject.Find("plant game over");
       // monster = GameObject.Find("Player");
        targetController = GameObject.Find("Targets");
        timer = 0.0f;
        doOnce = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        monster = GameObject.Find("Player");
		resource = GameObject.Find("dynamic money text");
		if (buildingHealth <= 900 && !doOnce && !this.gameObject.CompareTag("PileOFish"))
        {
			Vector3 tempVec = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + (this.gameObject.transform.localScale.y * 4), this.gameObject.transform.position.z);
            fire = Instantiate(destructionEffect, tempVec, Quaternion.identity) as GameObject;
            doOnce = true;
        }

        if (buildingHealth <= 0)
        {
            if (this.gameObject.name == "Plant")
            {      
                gameOverState.GetComponent<GUIText>().text = "The Plant Was Destroyed Game Over";
                monster.GetComponent<AIFollow>().Stop();
                monster.GetComponent<Animation>().animation.Stop();
            }
            if (lastObject != null)
            {
                Vector3 yup = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.2f, this.gameObject.transform.position.z);
                GameObject rubble = Instantiate(lastObject, yup, Quaternion.identity) as GameObject;
            }
            buildingContainer.gameObject.GetComponent<BuildingCollector>().removeBuild(this.gameObject, false);
            new WaitForSeconds(1);
            Destroy(fire);
            Destroy(this.gameObject);
        }

        if (this.gameObject.name == "Bank")
        {
            timer += Time.deltaTime;

            if (timer > resourceGainTimer)
            {
                resource.GetComponent<ResourceManager>().currentMoney += resourcePerSecond;
                timer = 0.0f;
            }
        }
        else if (this.gameObject.name == "Plant")
        {
            ifPlant_Health.GetComponent<PlantMonitor>().currentHealth = buildingHealth;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered");
        GameObject airstrike = GameObject.Find("AStrike(Clone)");

        if (airstrike != null)
        {
            if (other == airstrike.collider)
            {
                //Debug.Log("airstrike build");
                buildingHealth -= airstrike.GetComponent<Airstrike>().damage;
            }
        }
    }
}
