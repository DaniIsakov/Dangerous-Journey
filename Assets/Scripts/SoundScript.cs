using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundScript : MonoBehaviour
{
    public static AudioSource Background;
    string sceneName;
    Scene currentScene;
    public Animator anim;


    private void Awake()
    {
       DontDestroyOnLoad(this.gameObject);


        
        
    }


    void Start()
    {
        anim.SetBool("False", true);


    }



    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "MainMenu")
        {
            anim.SetBool("Valume", false);
            Background.volume = 0.3f;

        }
        if(sceneName == "Level 1")
        {
            anim.SetBool("Valume", true);
            Background.volume = 0.05f;
        }
        

    }
}
