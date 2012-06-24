using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUICollector : MonoBehaviour 
{
    public List<GameObject> buttons;

	void Start () 
    {
        buttons = new List<GameObject>();
        makeButtons();
	}
	
	void Update () 
    {
	
	}

    private void makeButtons()
    {
        buttons.Add(GameObject.Find("button1"));
        buttons.Add(GameObject.Find("button2"));
        buttons.Add(GameObject.Find("button3"));
        buttons.Add(GameObject.Find("button4"));
        buttons.Add(GameObject.Find("button5"));
        buttons.Add(GameObject.Find("button6"));
        buttons.Add(GameObject.Find("button7"));
        buttons.Add(GameObject.Find("button8"));
    }

    public GameObject getActiveButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].GetComponent<GUIButtonAttributes>().buttonOn)
            {
                return buttons[i];
            }
        }

        return null;
    }

    public void deactivateButtons(GameObject ignore)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i] != ignore)
            {
                buttons[i].GetComponent<GUIButtonAttributes>().buttonOn = false;
            }
        }
    }

    public bool buttonActive()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].GetComponent<GUIButtonAttributes>().buttonOn)
            {
                return true;
            }
        }

        return false;
    }

    public void deactivateAll()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<GUIButtonAttributes>().buttonOn = false;
        }
    }
}
