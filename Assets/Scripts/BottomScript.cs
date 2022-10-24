using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BottomScript : MonoBehaviour
{

    public AudioSource Click;
    




    public void Exit()
    {
        Application.Quit();
        Click.Play(1);

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
        Click.Play(1);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("SoundBack"));
        Click.Play(1);
        SoundScript.Background.volume = 0.3f;


    }
    public void Retry()
    {
        SceneManager.LoadScene(LevelManager.LastLevel);
        Click.Play(1);

    }
    public void Next()
    {
        if(LevelManager.LastLevel == "Level 1")
        {
            SceneManager.LoadScene("Level 2");
            Click.Play(1);

        }
        if (LevelManager.LastLevel == "Level 2")
        {
            SceneManager.LoadScene("Level 3");
            Click.Play(1);

        }
        if (LevelManager.LastLevel == "Level 3")
        {
            SceneManager.LoadScene("Level 4");
            Click.Play(1);

        }
        if (LevelManager.LastLevel == "Level 4")
        {
            SceneManager.LoadScene("Level 5 Boss");
            Click.Play(1);
        }
        
    }

}
