using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animControl;
    public AudioSource DoorSound;

    // Start is called before the first frame update
    void Start()
    {
        BossLifeScript.BossDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            animControl.SetBool("Open", true);

        }
        if(BossLifeScript.BossDoor == true)
        {
            animControl.SetBool("Open2", true);

        }
    }
}
