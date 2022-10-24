using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseBT;
    public GameObject TextGO;
    public AudioSource Click;



    void Start()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseBT.SetActive(true);


    }

    void Update()
    {
        
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseBT.SetActive(false);
        TextGO.transform.localScale = new Vector2(0, 0);
        Click.Play(1);

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseBT.SetActive(true);
        TextGO.transform.localScale = new Vector2(1, 1);
        Time.timeScale = 1f;
        Click.Play(1);

    }
    public void Exit()
    {
        Application.Quit();
        Click.Play(1);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("SoundBack"));
        Click.Play(1);
        SoundScript.Background.volume = 0.3f;


    }

    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1f;
        Click.Play(1);
        BossLifeScript.LifeBar = 0.5f;


    }



}
