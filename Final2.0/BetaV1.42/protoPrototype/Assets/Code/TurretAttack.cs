using UnityEngine;
using System.Collections;

public class TurretAttack : MonoBehaviour 
{
    public GameObject turret;
    GameObject tempChild;
    private float timer;
    private float colorTimer;

    // Use this for initialization
    void Start()
    {
        turret = null;
        timer = 0.0f;
        colorTimer = 0.0f;
        tempChild = GameObject.Find("Root_Joint");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        turret = null;
        timer += Time.deltaTime;

        if (other.gameObject.CompareTag("Turret"))
        {
            //Debug.Log("Hit");
            if (timer >= 1.0f)
            {
                other.audio.Stop();
                other.audio.Play();
                timer = 0.0f;
            }
            other.audio.Play();
            turret = other.gameObject;
            turret.GetComponent<Turret>().activation = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Turret"))
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
                Color myColor = Color.red;
                tempChild.renderer.material.color = myColor;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        turret = null;

        if (other.gameObject.CompareTag("Turret"))
        {
            other.audio.Stop();
            turret = other.gameObject;
            turret.GetComponent<Turret>().activation = false;
            Color myColor = Color.white;
            tempChild.renderer.material.color = myColor;
        }
    }
}
