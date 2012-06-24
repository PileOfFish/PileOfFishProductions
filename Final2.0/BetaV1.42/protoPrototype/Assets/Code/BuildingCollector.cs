using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingCollector : MonoBehaviour 
{
    public List<GameObject> buildings;
    public List<GameObject> banks;
    public int              counter;
    public int              bankCounter;
    public GameObject       temp;
    public GameObject       roadBlock;
    public GameObject       fishPile;
    private GameObject      targetCount;
    public int percentBuildingLoss;
    public int percentBuildingBonus;
    public int percentBuildingBonusAmount;
    public int bonusPerBuilding;
    private int startingAmount;
    private int endingAmount;
    public GameObject monster;

	// Use this for initialization
	void Start () 
    {
	    buildings = new List<GameObject>();
        banks = new List<GameObject>();
        counter = transform.childCount;
        bankCounter = 1;
        targetCount = GameObject.Find("Main Camera");
        monster = GameObject.Find("Player");
        makeList();
	}
	
	// Update is called once per frame
	void Update () 
    {
        endingAmount = transform.childCount;
	}

    private void makeList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            temp = GameObject.Find("Building" + (i+1));
            buildings.Add(temp);
        }

        for (int j = 0; j < bankCounter; j++)
        {
            temp = GameObject.Find("Bank" + j);
            banks.Add(temp);
        }
    }

    public void removeBuild(GameObject obj, bool bank)
    {
        Debug.Log("Removed" + obj.name);
        if (bank)
        {
            banks.Remove(obj);
        }
        else if (obj.CompareTag("RoadBlock"))
        {
            targetCount.GetComponent<TargetMover>().roadBlockCounter -= 1;
            //monster.GetComponent<Attack_Building>().inAction = false;
            buildings.Remove(obj);
            //Debug.Log("Entered");
        }
        else if(obj.CompareTag("PileOFish"))
        {
            targetCount.GetComponent<TargetMover>().PileOFishCounter -= 1;
            //monster.GetComponent<Attack_Building>().inAction = false;
            buildings.Remove(obj);
        }
        else
        {
            buildings.Remove(obj);
        }
    }

    public void addBlock(Vector3 location)
    {
        GameObject wall = Instantiate(roadBlock, location, Quaternion.identity) as GameObject;
        wall.transform.parent = this.gameObject.transform;
        wall.name = "Block" + (counter+1).ToString();
        counter++;
        wall.collider.isTrigger = true;
        buildings.Add(wall);
    }

    public void addFish(Vector3 location)
    {
        Debug.Log("created fish");
        GameObject fish = Instantiate(fishPile, location, Quaternion.identity) as GameObject;
        fish.transform.parent = this.gameObject.transform;
        fish.name = "Building" + (counter + 1).ToString();
        counter++;
        fish.collider.isTrigger = true;
        buildings.Add(fish);
    }
}
