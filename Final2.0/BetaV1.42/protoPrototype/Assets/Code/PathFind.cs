using UnityEngine;
using System.Collections;

enum CharacterState
{
    Idle = 0,
    Walking = 1,
    Trotting = 2,
    Running = 3,
    Jumping = 4,
}

public class PathFind : MonoBehaviour
{

    public AnimationClip idleAnimation;
    public AnimationClip walkAnimation;
    public AnimationClip runAnimation;
    public AnimationClip jumpPoseAnimation;

    public float walkMaxAnimationSpeed;
    public float trotMaxAnimationSpeed;
    public float runMaxAnimationSpeed;
    public float jumpAnimationSpeed;
    public float landAnimationSpeed;

    public ArrayList buildingList;
 
    // Use this for initialization
    void Start()
    {
        landAnimationSpeed  = 1.0f;
        jumpAnimationSpeed  = 1.15f;
        runMaxAnimationSpeed  = 1.0f;
        trotMaxAnimationSpeed  = 1.0f;
        walkMaxAnimationSpeed  = 0.75f;

        buildingList = new ArrayList();

        Object temp = GameObject.Find("Building");
        buildingList.Add(buildingList);

        while (temp != null)
        {
            temp = GameObject.Find("Building");

            if (!buildingList.Contains(temp))
            {
                buildingList.Add(temp);
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        int temp = 0;
        temp = Random.Range(1, buildingList.Count);
    }
}
