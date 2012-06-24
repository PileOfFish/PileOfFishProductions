using UnityEngine;
using System.Collections;

public class Attack_Building : MonoBehaviour 
{
    public GameObject obj;
    public GameObject lastTarget;
    public GameObject targetContainer;
    public bool doOnce;
    private GameObject targetCount;
    public int monsterSpeed;
    public int slowEffectSpeed;
    public bool trigger;
    public bool slowEffect;
    private bool loadOnce_Forever;
    private float timer;
    public float timeTillNewTarget;
    public bool inAction;
    public bool lovesFish;

    void Start ()
    {
        targetContainer = GameObject.Find("Targets");
        targetCount = GameObject.Find("Main Camera");
        Random.seed = 2;
        doOnce = false;
        trigger = false;
        slowEffect = false;
        slowEffectSpeed = 0;
        loadOnce_Forever = false;
        obj = targetContainer.GetComponent<TargetCollector>().targets[0];
        timer = 0.0f;
        inAction = false;
        lovesFish = false;
    }

    void Update()
    {
        if (!inAction)
        {
            timer += Time.deltaTime;
        }

        if (timer >= timeTillNewTarget)
        {
            Debug.Log("changed target");
            Random.seed = 1;
            int temp = Random.Range(0, targetContainer.GetComponent<TargetCollector>().targets.Count);
            Debug.Log(temp);
            //Vector3 position = targetContainer.GetComponent<TargetCollector>().targets[temp].transform.position;
            this.gameObject.GetComponent<AIFollow>().Stop();
            targetContainer.GetComponent<TargetCollector>().switchTargets(temp, 0);
            this.gameObject.GetComponent<AIFollow>().target = targetContainer.GetComponent<TargetCollector>().targets[0].transform;
            this.gameObject.GetComponent<AIFollow>().PathToTarget(targetContainer.GetComponent<TargetCollector>().targets[0].transform.position);
            this.gameObject.GetComponent<AIFollow>().Resume();
            timer = 0.0f;
        }

        if (targetContainer.GetComponent<TargetCollector>().targets.Count == 0)
        {
            Debug.Log("changed target cause 0");
            Vector3 position = new Vector3(Random.Range(-25.0f, 25.0f), 1, Random.Range(-25.0f, 25.0f));
            targetContainer.GetComponent<TargetCollector>().addTargetToFront(position);
            this.gameObject.GetComponent<AIFollow>().PathToTarget(position);
            this.gameObject.GetComponent<AIFollow>().Resume();
        }

        if (!loadOnce_Forever)
        {
            obj = targetContainer.GetComponent<TargetCollector>().targets[0];
            loadOnce_Forever = true;
        }

        if (this.gameObject.GetComponent<AIFollow>().speed <= 0)
        {
            animation.Play("attack", PlayMode.StopAll);
        }
        else
        {
            animation.Play("walk", PlayMode.StopAll);
        }

        inAction = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (!slowEffect)
        {
            this.gameObject.GetComponent<AIFollow>().speed = monsterSpeed;
        }

        Debug.Log("inactive");
        inAction = false;
    }

    void OnTriggerStay(Collider other)
    {
        inAction = true;
        trigger = false;
        GameObject airstrike = null;
        GameObject landMine = null;
        GameObject radar = null;

        if (other.gameObject.CompareTag("target"))
        {
            Debug.Log("Removed Target");
            targetContainer.GetComponent<TargetCollector>().removeTarget(obj);
            if (targetContainer.GetComponent<TargetCollector>().targets.Count != 0)
            {
                obj = targetContainer.GetComponent<TargetCollector>().targets[0];
                Vector3 temp = obj.transform.position;
                this.gameObject.GetComponent<AIFollow>().PathToTarget(temp);
                this.gameObject.GetComponent<AIFollow>().Resume();
                trigger = true;
            }
        }
        
        if(other != null)
        {
            Debug.Log("Not a target");
            if (other.gameObject.CompareTag("airstrike") && !doOnce)
            {
                //Debug.Log("Airstrike collider");
                airstrike = other.gameObject;
                other.audio.Play();
                this.gameObject.GetComponent<MonsterHealth>().health -= airstrike.GetComponent<Airstrike>().damage;
                doOnce = true;
                trigger = true;
            }
            else if (other.gameObject.CompareTag("airstrike"))
            {
                trigger = true;
            }

            if (other.gameObject.CompareTag("LandMine") && !doOnce)
            {
                Debug.Log("LandMine");
                landMine = other.gameObject;
                landMine.GetComponent<LandMine>().explosion.active = true;
                this.gameObject.GetComponent<MonsterHealth>().health -= landMine.GetComponent<LandMine>().damage;
                landMine.GetComponent<LandMine>().destroyMe = true;
                doOnce = true;
                trigger = true;
            }

            if (!trigger && other.GetComponent<BuildingAttributes>() != null)
            {
                //Debug.Log(trigger);
                Debug.Log("Building Collider");
                other.GetComponent<BuildingAttributes>().buildingHealth -= 5;
                //audio.Play();

                if (other.GetComponent<BuildingAttributes>().buildingHealth <= 0)
                {
                    if (!slowEffect)
                    {
                        this.gameObject.GetComponent<AIFollow>().speed = monsterSpeed;
                    }
                    else
                    {
                        this.gameObject.GetComponent<AIFollow>().speed = slowEffectSpeed;
                    }
                    //Destroy(obj);
                    return;
                }
                else
                {
                    this.gameObject.GetComponent<AIFollow>().speed = 0;
                }
            }
        }
    }
}
