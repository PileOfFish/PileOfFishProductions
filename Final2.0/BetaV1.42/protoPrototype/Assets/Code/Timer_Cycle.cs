using UnityEngine;
using System.Collections;

public class Timer_Cycle : MonoBehaviour {

    float timer;
    public GameObject gameOverText;
    public GameObject timerText;
    public GameObject monster;
    float gameOver;
    public float levelTime;
	public GameObject nextLevelBut;
	// Use this for initialization
	void Start () 
    {
        timer = 0.0f;
        gameOver = 0.0f;
        gameOverText = GameObject.Find("day/night victory");
        //monster = GameObject.Find("Player");
        //timerText = GameObject.Find("dynamic timer text");
	}
	
	// Update is called once per frame
	void Update () 
    {
       	
		timerText = GameObject.Find("dynamic timer text");
		monster = GameObject.Find("Player");
		timer += Time.deltaTime;
        gameOver += Time.deltaTime;

        if (timer > 1.0f)
        {
            transform.Rotate((float)180/levelTime, 0.0f, 0.0f);
            timer = 0.0f;
        }

        if (levelTime - gameOver >= 0)
        {
            timerText.GetComponent<Timer>().timer = levelTime - gameOver;
        }

        if (gameOver > levelTime && GameObject.Find("Plant") != null)
        {
            //gameOverText.active = true;
			nextLevelBut.transform.Translate(1,0,0);
            gameOverText.GetComponent<GUIText>().text = "You Survived The Day Victory Is Yours!";
            monster.GetComponent<AIFollow>().Stop();
            if (monster.GetComponent<AIFollow>().speed <= 0)
            {
                Destroy(monster);
            }
            gameOver = 0.0f;
        }
	}
}
