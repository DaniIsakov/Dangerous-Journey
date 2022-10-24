using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLifeScript : MonoBehaviour
{
    public static float LifeBar = 0.5f;
    private Animator anim;
    public static bool BossDoor = false;



    void Start()
    {
        
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        print(LifeBar);
        if(LifeBar == 1.0f)
        {
            anim.SetInteger("LifeBar", 1);
            LifeBar += 0.5f;
        }
        if (LifeBar == 2.0f)
        {
            anim.SetInteger("LifeBar", 2);
            LifeBar += 0.5f;

        }
        if (LifeBar == 3.0f)
        {
            anim.SetInteger("LifeBar", 3);
            LifeBar += 0.5f;

        }
        if (LifeBar == 4.0f)
        {
            anim.SetInteger("LifeBar", 4);
            LifeBar += 0.5f;

        }
        if (LifeBar == 5.0f)
        {
            anim.SetInteger("LifeBar", 5);
            LifeBar = 6f;
        }
        if (LifeBar == 6)
        {
            anim.SetInteger("LifeBar", 5);
            BossDoor = true;
        }


    }
}
