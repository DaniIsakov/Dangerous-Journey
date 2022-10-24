using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public AudioSource MushPick;

    private void Start()
    {
        MushPick.Pause();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Destroy(gameObject);
            MushPick.Play(1);

        }
    }
}
