using UnityEngine;
using System.Collections;

public enum ButtonState
{
	normal,
	hover,
	armed
};

[System.Serializable]
public class ButtonTextures
{
	public Texture normal = null;
	public Texture hover = null;
	public Texture armed = null;
	public ButtonTextures() {}
	
	public Texture this [ButtonState state]
	{
		get
		{
			switch(state)
			{
				case ButtonState.normal:
					return normal;
				case ButtonState.hover:
					return hover;
				case ButtonState.armed:
					return armed;
				default:
					return null;
			}
		}
	}
}

[RequireComponent(typeof(GUITexture))]
[AddComponentMenu("GUI/Button")]
public class GUIButtonAttributes : MonoBehaviour
{
	public bool buttonOn;
    public bool onCoolDown;
    private float masterCoolDown;
    public int priorityNum;
    public float coolDownTimer;
    private GameObject collector;
	public GameObject messagee;
	public string message = "ButtonPressed";
	public ButtonTextures textures;
	
	protected int state = 0;
	protected GUITexture myGUITexture;
	
	void Start () 
    {
        buttonOn = false;
        onCoolDown = false;
        masterCoolDown = 0.0f;
        collector = GameObject.Find("GUI");
		myGUITexture = GetComponent(typeof(GUITexture)) as GUITexture;
		SetButtonTexture(ButtonState.normal);
	}
	
	void Update () 
    {
        if (buttonOn && !onCoolDown)
        {
            guiTexture.color = Color.black;
        }

        if(onCoolDown)
        {
            masterCoolDown += Time.deltaTime;
            guiTexture.color = Color.red;
            buttonOn = false;
            if (masterCoolDown > coolDownTimer)
            {
                guiTexture.color = Color.grey;
                onCoolDown = false;
                masterCoolDown = 0.0f;
            }
        }

        if (!buttonOn && !onCoolDown && guiTexture.color != Color.yellow)
        {
            guiTexture.color = Color.gray;
        }
	}
	void SetButtonTexture(ButtonState state)
	{
		myGUITexture.texture=textures[state];
	}
	
	void Reset() 
	{
		messagee = gameObject;
		message = "ButtonPressed";
	}
		
	void OnMouseEnter()
	{
		if (!onCoolDown)
		{

			state++;
			if(state == 1)
				SetButtonTexture(ButtonState.hover);
		}
	}
	void OnMouseDown()
	{
		if (!onCoolDown)
		{
            buttonOn = true;
			state++;
			if (state == 2)
				SetButtonTexture(ButtonState.armed);
		}
	}
	
	void OnMouseUp()
	{
		if (state == 2)
		{
			state--;
			if(messagee !=null)
				messagee.SendMessage(message,this);
		}
		else
		{
			state--;
			if(state < 0)
				state = 0;
		}
		SetButtonTexture(ButtonState.normal);
	}
	
	void OnMouseExit()
	{
		//SetButtonTexture(ButtonState.normal);
		print ("FUCK ME ");
		if (buttonOn && !onCoolDown)
		{
			if(state > 0)
				state--;
				//SetButtonTexture(ButtonState.normal);
		}
		/*else if (!onCoolDown)
		{
			print ("FUCK ME ");
			if(state == 0)
				SetButtonTexture(ButtonState.normal);
		}*/
	}
}


/*public class GUIButtonAttributes : MonoBehaviour 
{
    public bool buttonOn;
    public bool onCoolDown;
    private float masterCoolDown;
    public int priorityNum;
    public float coolDownTimer;
    private GameObject collector;

	void Start () 
    {
        buttonOn = false;
        onCoolDown = false;
        masterCoolDown = 0.0f;
        collector = GameObject.Find("GUI");
	}
	
	void Update () 
    {
        if (buttonOn && !onCoolDown)
        {
            guiTexture.color = Color.black;
        }

        if(onCoolDown)
        {
            masterCoolDown += Time.deltaTime;
            guiTexture.color = Color.red;
            if (masterCoolDown > coolDownTimer)
            {
                guiTexture.color = Color.grey;
                onCoolDown = false;
                masterCoolDown = 0.0f;
            }
        }

        if (!buttonOn && !onCoolDown && guiTexture.color != Color.yellow)
        {
            guiTexture.color = Color.gray;
        }
	}

    void OnMouseEnter()
    {
        if (!onCoolDown)
        {
            guiTexture.color = Color.yellow;
        }
    }

    void OnMouseExit()
    {
        if (buttonOn && !onCoolDown)
        {
            guiTexture.color = Color.black;
        }
        else if (!onCoolDown)
        {
            guiTexture.color = Color.gray;
        }
    }

    void OnMouseDown()
    {
        if (!onCoolDown)
        {
            buttonOn = true;
            //onCoolDown = true;
            collector.GetComponent<GUICollector>().deactivateButtons(this.gameObject);
            guiTexture.color = Color.black;
        }
    }

    void OnMouseUp()
    {
        //guiTexture.color = Color.red;
    }
}
 */