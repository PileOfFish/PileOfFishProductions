using UnityEngine;
using System.Collections;

public class PileOFish : MonoBehaviour 
{
    //public int fishAmount;
    private float timer;
    public GameObject targetMover;
    public GameObject monster;
    private bool firstOccurence;

	// Use this for initialization
	void Start () 
    {
        targetMover = GameObject.Find("Targets");
        monster = GameObject.Find("Player");
        timer = 0.0f;
        firstOccurence = true;
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    void OnTriggerEnter(Collider other)
    {
	}
        /*if (firstOccurence && other.CompareTag("Player"))
        {
            Debug.Log("Fish Collider");
            monster.GetComponent<AIFollow>().Stop();
            (collider as SphereCollider).radius = 1;
            //Vector3 lastTarget = targetMover.GetComponent<TargetCollector>().top;
            //targetMover.GetComponent<TargetCollector>().targets[0].transform.position = this.gameObject.transform.position;
            //targetMover.GetComponent<TargetCollector>().addTargetToFront(this.gameObject.transform.position);
        }
    }

    void OnTriggerExit(Collider other)
    {
        this.gameObject.GetComponent<AIFollow>().target = targetMover.GetComponent<TargetCollector>().targets[0].transform;
        monster.GetComponent<AIFollow>().PathToTarget(targetMover.GetComponent<TargetCollector>().targets[0].transform.position);
        monster.GetComponent<AIFollow>().Resume();
        firstOccurence = false;*/
}
