using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMush : MonoBehaviour
{
    public GameObject MushToSpawn;
    Vector2 Spawn;
    public Animator BossAnim;
    

    
    void Start()
    {

    }

   
    void Update()
    {
        RandomOne();
        if(GameObject.FindGameObjectsWithTag("BossMush").Length == 0)
        {
            if(GameObject.FindGameObjectsWithTag("Start").Length == 0 && BossLifeScript.LifeBar < 5)
            {
               SpawnMush();


            }


        }

    }

    Vector2 GetSpawnPoint()
    {
        float y = Random.Range(1.25f, -3.46f);
        float x = Random.Range(1.25f, 1.55f);

        return new Vector2(x, y);


    }
    Vector2 GetSpawnPoint2()
    {
        float y = Random.Range(1.17f, -3.43f);
        float x = Random.Range(-1.53f, -1.53f);

        return new Vector2(x, y);


    }
    Vector2 GetSpawnPoint3()
    {
        float y = Random.Range(1.15f, 1.15f);
        float x = Random.Range(-1.53f, 0.06f);

        return new Vector2(x, y);


    }
    Vector2 GetSpawnPoint4()
    {
        float y = Random.Range(1.31f, -3.77f);
        float x = Random.Range(0.06f, 0.06f);

        return new Vector2(x, y);


    }
    Vector2 GetSpawnPoint5()
    {
        float y = Random.Range(-3.79f, -3.79f);
        float x = Random.Range(-1.09f, 0.64f);

        return new Vector2(x, y);


    }



    public void SpawnMush()
    {

        Instantiate(MushToSpawn, Spawn, Quaternion.identity);
        Destroy(GameObject.FindGameObjectWithTag("BossMush"), 8);
    }

    private void RandomOne()
    {
        int S = Random.Range(1, 5);

        if(S == 1)
        {
            Spawn = GetSpawnPoint();
        }
        if (S == 2)
        {
            Spawn = GetSpawnPoint2();
        }
        if (S == 3)
        {
            Spawn = GetSpawnPoint3();
        }
        if (S == 4)
        {
            Spawn = GetSpawnPoint4();
        }
        if (S == 5)
        {
            Spawn = GetSpawnPoint5();
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    

    }
