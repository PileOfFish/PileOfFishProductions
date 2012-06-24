using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour 
{
    public GameObject buttonController;
    float angle;
    public float rotationSpeed;

	// Use this for initialization
	void Start () 
    {
        buttonController = GameObject.Find("GUI");
        angle = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        GameObject temp = buttonController.GetComponent<GUICollector>().getActiveButtons();

        if (temp != null)
        {
            if (temp.name == "button7")
            {
                angle -= 90.0f;
                if (angle < -270.0f)
                {
                    angle = 0.0f;
                }
                //this.gameObject.transform.Rotate(0.0f, -90.0f, 0.0f);
                iTween.RotateTo(this.gameObject, Vector3.up * angle, rotationSpeed);
                buttonController.GetComponent<GUICollector>().deactivateAll();
            }
            else if (temp.name == "button8")
            {
                angle += 90.0f;
                if (angle > 271.0f)
                {
                    angle = 0.0f;
                }
                //this.gameObject.transform.Rotate(0.0f, 90.0f, 0.0f);
                iTween.RotateTo(this.gameObject, Vector3.up * angle, rotationSpeed);
                buttonController.GetComponent<GUICollector>().deactivateAll();
            }
        }
	}
}
