using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Text : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator animTutorial;
    public GameObject StartOBJ;



    public void Start()
    {
        PlayerScript.stopTouch = false;
        if (LevelManager.LastLevel == "Level 1")
        {
            StartCoroutine(TextStartFirst());
        }
        if (LevelManager.LastLevel == "Level 2")
        {
            StartCoroutine(TextStart());
        }
        if (LevelManager.LastLevel == "Level 3")
        {
            StartCoroutine(TextStart());
        }
        if (LevelManager.LastLevel == "Level 4")
        {
            StartCoroutine(LightningAware());
        }
        if (LevelManager.LastLevel == "Level 5 Boss")
        {
            StartCoroutine(TextBoss());
        }
    }

   
    void Update()
    {




    }

    IEnumerator TextBoss()
    {

        yield return new WaitForSeconds(3.5f);
        anim1.SetBool("Aware", true);
        yield return new WaitForSeconds(2);
        anim1.SetBool("Aware", false);
        anim2.SetBool("Start", true);
        yield return new WaitForSeconds(3);
        PlayerScript.stopTouch = true;
        Destroy(StartOBJ);

       


    }
    IEnumerator TextStart()
    {
        anim2.SetBool("Start", true);
        yield return new WaitForSeconds(3);
        PlayerScript.stopTouch = true;


    }

    IEnumerator TextStartFirst()
    {
        yield return new WaitForSeconds(1);
        anim3.SetBool("Start", true);
        yield return new WaitForSeconds(3);
        anim4.SetBool("Start", true);
        yield return new WaitForSeconds(3);
        anim1.SetBool("Aware", true);
        yield return new WaitForSeconds(3);
        animTutorial.SetBool("TutoStart", true);
        yield return new WaitForSeconds(4);
        anim2.SetBool("Start", true);
        yield return new WaitForSeconds(3);

        PlayerScript.stopTouch = true;

    }
    IEnumerator LightningAware()
    {
        yield return new WaitForSeconds(1);
        anim1.SetBool("Aware", true);
        yield return new WaitForSeconds(3);
        anim3.SetBool("Start", true);
        yield return new WaitForSeconds(3);
        anim2.SetBool("Start", true);
        yield return new WaitForSeconds(3);

        PlayerScript.stopTouch = true;
    }



}
