using UnityEngine;
using System.Collections;

public class MovementInterference : MonoBehaviour 
{
    public GameObject radar;
    GameObject tempChild;
    private float timer;
    private float colorTimer;

	// Use this for initialization
	void Start () 
    {
        radar = null;
        timer = 0.0f;
        colorTimer = 0.0f;
        tempChild = GameObject.Find("Root_Joint");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (radar == null)
        {
            this.gameObject.GetComponent<Attack_Building>().slowEffect = false;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        radar = null;
        timer += Time.deltaTime;

        if (other.gameObject.CompareTag("Radar"))
        {
            //Debug.Log("Hit");
            if (timer >= 1.0f)
            {
                other.audio.Stop();
                other.audio.Play();
                timer = 0.0f;
            }
            other.audio.Play();
            radar = other.gameObject;
            radar.GetComponent<RadarDish>().activation = true;
            this.gameObject.GetComponent<AIFollow>().speed = radar.GetComponent<RadarDish>().slowSpeedTo;
            this.gameObject.GetComponent<Attack_Building>().slowEffect = true;
            this.gameObject.GetComponent<Attack_Building>().slowEffectSpeed = radar.GetComponent<RadarDish>().slowSpeedTo;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Radar"))
        {
            colorTimer += Time.deltaTime;

            if (colorTimer > 1.0f)
            {
                Color myColor = Color.white;
                tempChild.renderer.material.color = myColor;
                colorTimer = 0.0f;
            }
            else if (colorTimer > 0.5f)
            {
                Color myColor = Color.blue;
                tempChild.renderer.material.color = myColor;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        radar = null;

        if (other.gameObject.CompareTag("Radar"))
        {
            other.audio.Stop();
            radar = other.gameObject;
            radar.GetComponent<RadarDish>().activation = false;
            this.gameObject.GetComponent<AIFollow>().speed = this.gameObject.GetComponent<Attack_Building>().monsterSpeed;
            this.gameObject.GetComponent<Attack_Building>().slowEffect = false;
            Color myColor = Color.white;
            tempChild.renderer.material.color = myColor;
        }
    }
}
