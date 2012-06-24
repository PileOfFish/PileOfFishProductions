using UnityEngine;
using System.Collections;

public class GUITextAttributes : MonoBehaviour 
{
    private GameObject collector;

    void Start()
    {
        collector = GameObject.Find("GUI");
    }

    void OnMouseEnter()
    {
        if (!transform.parent.GetComponent<GUIButtonAttributes>().onCoolDown)
        {
            transform.parent.guiTexture.color = Color.yellow;
        }
    }

    void OnMouseExit()
    {
        if (!transform.parent.GetComponent<GUIButtonAttributes>().onCoolDown && transform.parent.GetComponent<GUIButtonAttributes>().buttonOn)
        {
            transform.parent.guiTexture.color = Color.black;
        }
        else if (!transform.parent.GetComponent<GUIButtonAttributes>().onCoolDown)
        {
            guiTexture.color = Color.gray;
        }
    }

    void OnMouseDown()
    {
        if (!transform.parent.GetComponent<GUIButtonAttributes>().onCoolDown)
        {
            transform.parent.GetComponent<GUIButtonAttributes>().buttonOn = true;
            collector.GetComponent<GUICollector>().deactivateButtons(transform.parent.gameObject);
            transform.parent.guiTexture.color = Color.black;
        }
    }

    void OnMouseUp()
    {
        //transform.parent.guiTexture.color = Color.red;
    }
}
