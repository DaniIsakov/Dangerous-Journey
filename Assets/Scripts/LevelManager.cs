using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static string LastLevel;
    Scene scene;
    
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        LastLevel = scene.name;
        
        


    }
    
    // Update is called once per frame
    void Update()
    {
      
       

    }

    
}
