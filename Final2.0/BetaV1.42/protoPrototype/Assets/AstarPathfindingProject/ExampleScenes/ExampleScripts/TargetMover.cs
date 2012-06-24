using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour {
	
	/** Mask for the raycast placement */
	public LayerMask mask;
	
	//public Transform target;

    public GameObject creator;
    public GameObject buildingHolder;
    private GameObject buttons;
    public GameObject buttonItem1;
    public GameObject buttonItem2;
    public GameObject buttonItem3;
    public GameObject buttonItem4;
    public GameObject buttonItem5;
    public Vector3 lastTarget;
    public GameObject monster;
    public int airstrikeLimit;
    public int roadBlockLimit;
    public int PileOFishLimit;
    public int mineLimit;
    public int radarLimit;
    public int turretLimit;
    public int airstrikeCounter;
    public int roadBlockCounter;
    public int PileOFishCounter;
    public int mineCounter;
    public int radarCounter;
    public int turretCounter;
    public int airstrikeResource;
    public int roadBlockResource;
    public int PileOFishResource;
    public int mineResource;
    public int radarResource;
    public int turretResource;
    private int currentResource;
    public GameObject attachedObject;
    public GameObject resourceManager;
    public GameObject AoE;
    public GameObject attachedArea;
    public GameObject tempArea;
    private GameObject tempObject;
    float rad;
    bool doOnce;
	
	/** Determines if the target position should be updated every frame or only on double-click */
	public bool onlyOnDoubleClick;
	
	Camera cam;
	
	public void Start () {
		//Cache the Main Camera
		cam = Camera.main;
        buttons = GameObject.Find("GUI");
        buildingHolder = GameObject.Find("Buildings");
        //monster = GameObject.Find("Player");
        //resourceManager = GameObject.Find("dynamic money text");
        airstrikeCounter = 0;
        roadBlockCounter = 0;
        PileOFishCounter = 0;
        mineCounter = 0;
        radarCounter = 0;
        turretCounter = 0;
        currentResource = 0;
        doOnce = false;
        tempArea = null;
	}
	
	public void OnGUI () 
    {	
		if (onlyOnDoubleClick && cam != null && Event.current.type == EventType.MouseDown 
            && Event.current.clickCount == 1 && buttons.GetComponent<GUICollector>().buttonActive()) 
        {
			UpdateTargetPosition ();
		}
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (tempArea != null)
            {
                Destroy(tempObject);
                Destroy(tempArea);
            }
        }
        resourceManager = GameObject.Find("dynamic money text");
		monster = GameObject.Find("Player");
		currentResource = resourceManager.GetComponent<ResourceManager>().currentMoney;

        GameObject temp = buttons.GetComponent<GUICollector>().getActiveButtons();

        if (temp != null)
        {
            if (temp.name == "button1" && currentResource >= airstrikeResource && airstrikeCounter < airstrikeLimit)
            {
                if (!doOnce)
                {
                    tempArea = Instantiate(AoE, new Vector3(900, 0, 900), Quaternion.identity) as GameObject;
                    tempObject = Instantiate(buttonItem1, new Vector3(0, 900, 0), Quaternion.identity) as GameObject;
                    rad = tempObject.GetComponent<SphereCollider>().radius;
                    Vector3 tempVector = tempObject.transform.localScale;
                    Vector3 areaVector = new Vector3(rad * (tempVector.x * 2), 0.0f, rad * (tempVector.z * 2));
                    tempArea.transform.localScale = areaVector;
                    Color redArea = Color.yellow;
                    redArea.a = 0.4f;
                    tempArea.renderer.material.color = redArea;
                    doOnce = true;
                }

                RaycastHit hit;
                if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask))
                {
                    Vector3 tempTemp = hit.point;
                    tempArea.transform.position = tempTemp;
                }
            }
            else if (temp.name == "button4" && currentResource >= mineResource && airstrikeCounter < mineLimit ||
                     temp.name == "button2" && currentResource >= roadBlockResource && roadBlockCounter < roadBlockLimit ||
                     temp.name == "button3" && currentResource >= PileOFishResource && PileOFishCounter < PileOFishLimit)
            {
                if (!doOnce)
                {
                    tempArea = Instantiate(AoE, new Vector3(900, 0, 900), Quaternion.identity) as GameObject;
                    tempObject = Instantiate(buttonItem2, new Vector3(0, 900, 0), Quaternion.identity) as GameObject;
                    rad = tempObject.GetComponent<SphereCollider>().radius;
                    Vector3 tempVector = tempObject.transform.localScale;
                    Vector3 areaVector = new Vector3(rad, 0.0f, rad);
                    tempArea.transform.localScale = areaVector;
                    Color redArea = Color.yellow;
                    redArea.a = 0.4f;
                    tempArea.renderer.material.color = redArea;
                    doOnce = true;
                }

                RaycastHit hit;
                if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask))
                {
                    if (!hit.collider.isTrigger)
                    {
                        Vector3 tempTemp = hit.point;
                        tempTemp.y += 0.5f;
                        tempArea.transform.position = tempTemp;
                        Color redArea2 = Color.yellow;
                        redArea2.a = 0.4f;
                        tempArea.renderer.material.color = redArea2;
                    }
                    else
                    {
                        Vector3 tempTemp = hit.point;
                        tempTemp.y += 0.5f;
                        tempArea.transform.position = tempTemp;
                        Color redArea2 = Color.red;
                        redArea2.a = 0.4f;
                        tempArea.renderer.material.color = redArea2;
                    }
                }
            }
            else if (temp.name == "button5" && currentResource >= radarResource && radarCounter < radarLimit)
            {
                if (!doOnce)
                {
                    tempArea = Instantiate(AoE, new Vector3(900, 0, 900), Quaternion.identity) as GameObject;
                    tempObject = Instantiate(buttonItem4, new Vector3(0, 900, 0), Quaternion.identity) as GameObject;
                    rad = tempObject.GetComponent<SphereCollider>().radius;
                    Vector3 tempVector = tempObject.transform.localScale;
                    Vector3 areaVector = new Vector3(rad * (tempVector.x * 2), 0.0f, rad * (tempVector.z * 2));
                    tempArea.transform.localScale = areaVector;
                    Color redArea = Color.yellow;
                    redArea.a = 0.4f;
                    tempArea.renderer.material.color = redArea;
                    doOnce = true;
                }

                RaycastHit hit;
                if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask))
                {
                    if (hit.collider.isTrigger)
                    {
                        Vector3 tempTemp = hit.point;
                        tempTemp.y += 0.5f;
                        tempArea.transform.position = tempTemp;
                        Color redArea2 = Color.yellow;
                        redArea2.a = 0.4f;
                        tempArea.renderer.material.color = redArea2;
                    }
                    else
                    {
                        Vector3 tempTemp = hit.point;
                        tempTemp.y += 0.5f;
                        tempArea.transform.position = tempTemp;
                        Color redArea2 = Color.red;
                        redArea2.a = 0.4f;
                        tempArea.renderer.material.color = redArea2;
                    }
                }
            }
            else if (temp.name == "button6" && currentResource >= turretResource && turretCounter < turretLimit)
            {
                if (!doOnce)
                {
                    tempArea = Instantiate(AoE, new Vector3(900, 0, 900), Quaternion.identity) as GameObject;
                    tempObject = Instantiate(buttonItem5, new Vector3(0, 900, 0), Quaternion.identity) as GameObject;
                    rad = tempObject.GetComponent<SphereCollider>().radius;
                    Vector3 tempVector = tempObject.transform.localScale;
                    Vector3 areaVector = new Vector3(rad * (tempVector.x * 2), 0.0f, rad * (tempVector.z * 2));
                    tempArea.transform.localScale = areaVector;
                    Color redArea = Color.yellow;
                    redArea.a = 0.4f;
                    tempArea.renderer.material.color = redArea;
                    doOnce = true;
                }

                RaycastHit hit;
                if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask))
                {
                    if (hit.collider.isTrigger)
                    {
                        Vector3 tempTemp = hit.point;
                        tempTemp.y += 0.5f;
                        tempArea.transform.position = tempTemp;
                        Color redArea2 = Color.yellow;
                        redArea2.a = 0.4f;
                        tempArea.renderer.material.color = redArea2;
                    }
                    else
                    {
                        Vector3 tempTemp = hit.point;
                        tempTemp.y += 0.5f;
                        tempArea.transform.position = tempTemp;
                        Color redArea2 = Color.red;
                        redArea2.a = 0.4f;
                        tempArea.renderer.material.color = redArea2;
                    }
                }
            }
        }
        else
        {
            doOnce = false;
        }
	}

   void OnMouseDown()
   {
       Debug.Log("Called");

       if(tempArea != null)
       {
           Debug.Log("Happened");
           Destroy(tempObject);
           Destroy(tempArea);
       }
   }
	
	public void UpdateTargetPosition () 
    {
		//Fire a ray through the scene at the mouse position and place the target where it hits
        GameObject temp = buttons.GetComponent<GUICollector>().getActiveButtons();

		RaycastHit hit;
		if (Physics.Raycast	(cam.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity, mask)) 
        {
            //Debug.Log(hit.distance);
            if (hit.collider.isTrigger && !hit.collider.gameObject.CompareTag("Radar") && !hit.collider.gameObject.CompareTag("Turret"))
            {
                if (temp.name == "button1" && currentResource >= airstrikeResource)
                {
                    if (airstrikeCounter < airstrikeLimit)
                    {
                        GameObject areaEffect = Instantiate(AoE, hit.point, Quaternion.identity) as GameObject;
                        GameObject buttonEffect = Instantiate(buttonItem1, hit.point, Quaternion.identity) as GameObject;
                        float rad = buttonEffect.GetComponent<SphereCollider>().radius;
                        Vector3 buttonVector = buttonEffect.transform.localScale;
                        Vector3 areaVector = new Vector3(rad * (buttonVector.x * 2), 0.0f, rad * (buttonVector.z * 2));
                        areaEffect.transform.localScale = areaVector;
                        Color redArea = Color.yellow;
                        redArea.a = 0.4f;
                        areaEffect.renderer.material.color = redArea;
                        attachedArea = areaEffect;
                        GameObject tempButton = GameObject.Find("button1");
                        tempButton.GetComponent<GUIButtonAttributes>().onCoolDown = true;
                        buttons.GetComponent<GUICollector>().deactivateAll();
                        airstrikeCounter++;
                        resourceManager.GetComponent<ResourceManager>().currentMoney -= airstrikeResource;
                    }
                    else
                    {
                        buttons.GetComponent<GUICollector>().deactivateAll();
                    }
                }
                else if (temp.name == "button5" && currentResource >= radarResource)
                {
                    if (radarCounter < radarLimit)
                    {
                        GameObject areaEffect = Instantiate(AoE, hit.point, Quaternion.identity) as GameObject;
                        attachedObject = hit.collider.gameObject;
                        GameObject buttonEffect = Instantiate(buttonItem4, hit.point, Quaternion.identity) as GameObject;
                        float rad = buttonEffect.GetComponent<SphereCollider>().radius;
                        Vector3 buttonVector = buttonEffect.transform.localScale;
                        Vector3 areaVector = new Vector3(rad*(buttonVector.x*2), 0.0f, rad*(buttonVector.z*2));
                        areaEffect.transform.localScale = areaVector;
                        Color redArea = Color.yellow;
                        redArea.a = 0.4f;
                        areaEffect.renderer.material.color = redArea;
                        attachedArea = areaEffect;
                        GameObject tempButton = GameObject.Find("button5");
                        tempButton.GetComponent<GUIButtonAttributes>().onCoolDown = true;
                        buttons.GetComponent<GUICollector>().deactivateAll();
                        radarCounter++;
                        resourceManager.GetComponent<ResourceManager>().currentMoney -= radarResource;
                    }
                    else
                    {
                        buttons.GetComponent<GUICollector>().deactivateAll();
                    }
                }
                else if (temp.name == "button6" && currentResource >= turretResource)
                {
                    if (turretCounter < turretLimit)
                    {
                        GameObject areaEffect = Instantiate(AoE, hit.point, Quaternion.identity) as GameObject;
                        attachedObject = hit.collider.gameObject;
                        GameObject buttonEffect = Instantiate(buttonItem5, hit.point, Quaternion.identity) as GameObject;
                        float rad = buttonEffect.GetComponent<SphereCollider>().radius;
                        Vector3 buttonVector = buttonEffect.transform.localScale;
                        Vector3 areaVector = new Vector3(rad * (buttonVector.x * 2), 0.0f, rad * (buttonVector.z * 2));
                        areaEffect.transform.localScale = areaVector;
                        Color redArea = Color.yellow;
                        redArea.a = 0.4f;
                        areaEffect.renderer.material.color = redArea;
                        attachedArea = areaEffect;
                        GameObject tempButton = GameObject.Find("button6");
                        tempButton.GetComponent<GUIButtonAttributes>().onCoolDown = true;
                        buttons.GetComponent<GUICollector>().deactivateAll();
                        turretCounter++;
                        resourceManager.GetComponent<ResourceManager>().currentMoney -= turretResource;
                    }
                    else
                    {
                        buttons.GetComponent<GUICollector>().deactivateAll();
                    }
                }
            }
            else if (hit.collider || !hit.collider.gameObject.CompareTag("Radar") || !hit.collider.gameObject.CompareTag("Turret"))
            {
                if (hit.collider.isTrigger == false)
                {
                    if (temp.name == "button2" && currentResource >= roadBlockResource)
                    {
                        if (roadBlockCounter < roadBlockLimit)
                        {
                            buildingHolder.GetComponent<BuildingCollector>().addBlock(hit.point);
                            GameObject tempButton = GameObject.Find("button2");
                            tempButton.GetComponent<GUIButtonAttributes>().onCoolDown = true;
                            buttons.GetComponent<GUICollector>().deactivateAll();
                            roadBlockCounter++;
                            resourceManager.GetComponent<ResourceManager>().currentMoney -= roadBlockResource;
                        }
                        else
                        {
                            buttons.GetComponent<GUICollector>().deactivateAll();
                        }
                    }
                    else if (temp.name == "button3" && currentResource >= PileOFishResource)
                    {
                        if (PileOFishCounter < PileOFishLimit)
                        {
                            Debug.Log("Placed Fish");
                            //monster.GetComponent<AIFollow>().Stop();
                            GameObject buttonEffect = Instantiate(buttonItem3, hit.point, Quaternion.identity) as GameObject;
                            //lastTarget = creator.GetComponent<TargetCollector>().top;
                            buildingHolder.GetComponent<BuildingCollector>().addFish(hit.point);
                            //creator.GetComponent<TargetCollector>().targets[0].transform.position = hit.point;
                            creator.GetComponent<TargetCollector>().addTargetToFront(hit.point);
                            GameObject tempButton = GameObject.Find("button3");
                            tempButton.GetComponent<GUIButtonAttributes>().onCoolDown = true;
                            buttons.GetComponent<GUICollector>().deactivateAll();
                            //monster.GetComponent<AIFollow>().PathToTarget(hit.point);
                            //monster.GetComponent<AIFollow>().Resume();
                            PileOFishCounter++;
                            resourceManager.GetComponent<ResourceManager>().currentMoney -= PileOFishResource;
                        }
                        else
                        {
                            buttons.GetComponent<GUICollector>().deactivateAll();
                        }
                    }
                    else if (temp.name == "button4" && currentResource >= mineResource)
                    {
                        if (mineCounter < mineLimit)
                        {
                            monster.GetComponent<Attack_Building>().doOnce = false;
                            Vector3 tempVect = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
                            GameObject buttonEffect = Instantiate(buttonItem2, tempVect, Quaternion.identity) as GameObject;
                            buttonEffect.name = buttonEffect.name + mineCounter.ToString();
                            GameObject tempButton = GameObject.Find("button4");
                            tempButton.GetComponent<GUIButtonAttributes>().onCoolDown = true;
                            buttons.GetComponent<GUICollector>().deactivateAll();
                            mineCounter++;
                            resourceManager.GetComponent<ResourceManager>().currentMoney -= mineResource;
                        }
                        else
                        {
                            buttons.GetComponent<GUICollector>().deactivateAll();
                        }
                    }
                }

                if (temp.name == "button1" && currentResource >= airstrikeResource)
                {
                    if (airstrikeCounter < airstrikeLimit)
                    {
                        GameObject areaEffect = Instantiate(AoE, hit.point, Quaternion.identity) as GameObject;
                        GameObject buttonEffect = Instantiate(buttonItem1, hit.point, Quaternion.identity) as GameObject;
                        float rad = buttonEffect.GetComponent<SphereCollider>().radius;
                        Vector3 buttonVector = buttonEffect.transform.localScale;
                        Vector3 areaVector = new Vector3(rad * (buttonVector.x * 2), 0.0f, rad * (buttonVector.z * 2));
                        areaEffect.transform.localScale = areaVector;
                        Color redArea = Color.yellow;
                        redArea.a = 0.4f;
                        areaEffect.renderer.material.color = redArea;
                        attachedArea = areaEffect;
                        GameObject tempButton = GameObject.Find("button1");
                        tempButton.GetComponent<GUIButtonAttributes>().onCoolDown = true;
                        buttons.GetComponent<GUICollector>().deactivateAll();
                        airstrikeCounter++;
                        resourceManager.GetComponent<ResourceManager>().currentMoney -= airstrikeResource;
                    }
                    else
                    {
                        buttons.GetComponent<GUICollector>().deactivateAll();
                    }
                }
            }

            if (temp != null)
            {
                temp.audio.Play();
            }
            buttons.GetComponent<GUICollector>().deactivateAll();
		}
	}
	
}
