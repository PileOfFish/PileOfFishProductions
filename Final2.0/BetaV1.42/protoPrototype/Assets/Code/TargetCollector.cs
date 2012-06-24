using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetCollector : MonoBehaviour 
{
    public List<GameObject> targets;
    public GameObject       temp;
    public GameObject       target;
    public int              counter;
    public GameObject       monster;
    public Vector3          top;
    private GameObject      targetMover;

	void Start () 
    {
        targets = new List<GameObject>();
        makeList();
        monster = GameObject.Find("Player");
        targetMover = GameObject.Find("Main Camera");
	}
	
	void Update () 
    {
	    counter = targets.Count;
        top = targets[0].transform.position;
	}

    private void makeList()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            targets.Add(GameObject.Find("Target" + i));
        }
        //targets.Add(GameObject.Find("Target3"));
    }

    public void addTarget(Vector3 location, int priority)
    {
        GameObject newTarget = Instantiate(target, location, Quaternion.identity) as GameObject;
        newTarget.transform.parent = this.gameObject.transform;
        newTarget.name = newTarget.name + (counter).ToString();
        newTarget.collider.isTrigger = true;
        targets.Insert(priority, newTarget);
    }

    public void addTargetToLast(Vector3 location)
    {
        GameObject newTarget = Instantiate(target, location, Quaternion.identity) as GameObject;
        newTarget.transform.parent = this.gameObject.transform;
        newTarget.name = newTarget.name + (counter).ToString();
        newTarget.collider.isTrigger = true;
        targets.Add(newTarget);
    }

    public void addTargetToFront(Vector3 location)
    {
        GameObject newTarget = Instantiate(target, location, Quaternion.identity) as GameObject;
        newTarget.transform.parent = this.gameObject.transform;
        newTarget.name = newTarget.name + (counter).ToString();
        newTarget.collider.isTrigger = true;
        targets.Insert(0, newTarget);
    }

    public void switchTargets(int index1, int index2)
    {
        GameObject tempObject = null;

        tempObject = targets[index1];
        //tempObject.transform.position = targets[index2].transform.position;
        targets[index1] = targets[index2];
        targets[index2] = tempObject;
    }

    public void removeTarget(GameObject obj)
    {
        //Debug.Log("Hit");
        if(obj.CompareTag("PileOFish"))
        {
            targetMover.GetComponent<TargetMover>().PileOFishCounter -= 1;
        }
        targets.Remove(obj);
        Destroy(obj);
    }
}
