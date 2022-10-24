using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    public static bool stopTouch = false;
    public float swipeRange;
    public float tapRange;

    public Animator animControl;

    public AudioSource RuningSound;
    public AudioSource MushPick;
    public AudioSource BlockLand;

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Scene scene = SceneManager.GetActiveScene();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) == true) //לבדיקות בלבד
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            //rb.AddForce(new Vector2(200, 0));
            //transform.Translate(+1, 0, 0);
            
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true) //לבדיקות בלבד
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            //rb.AddForce(new Vector2(-200, 0));
            //transform.Translate(-1, 0, 0);


        }
        if (Input.GetKey(KeyCode.UpArrow) == true) //לבדיקות בלבד
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
            //rb.AddForce(new Vector2(0, 200));
        }
        if (Input.GetKey(KeyCode.DownArrow) == true) //לבדיקות בלבד
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            //rb.AddForce(new Vector2(0, -200));
        }



        Swipe();



    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (stopTouch == true)
            {

                if (Distance.x < -swipeRange)
                {
                    stopTouch = false;
                    rb.AddForce(new Vector2(-4000, 0) * Time.deltaTime);
                    transform.localScale = new Vector2(-0.5f, 0.5f);
                    animControl.SetBool("Left", true);
                    RuningSound.Play(1);

                }
                else if (Distance.x > swipeRange)
                {
                    stopTouch = false;
                    rb.AddForce(new Vector2(4000, 0) * Time.deltaTime);
                    transform.localScale = new Vector2(0.5f, 0.5f);
                    animControl.SetBool("Right", true);
                    RuningSound.Play(1);

                }
                else if (Distance.y > swipeRange)
                {
                    stopTouch = false;
                    rb.AddForce(new Vector2(0, 4000) * Time.deltaTime);
                    animControl.SetBool("Back", true);
                    RuningSound.Play(1);


                }
                else if (Distance.y < -swipeRange)
                {
                    stopTouch = false;
                    rb.AddForce(new Vector2(0, -4000) * Time.deltaTime);
                    animControl.SetBool("Front", true);
                    RuningSound.Play(1);

                }

            }

            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Block"))
        {
            stopTouch = true;
            animControl.SetBool("Right", false);
            animControl.SetBool("Left", false);
            animControl.SetBool("Front", false);
            animControl.SetBool("Back", false);
            RuningSound.Pause();
            BlockLand.Play(1);
        }
        if(collision.gameObject.tag == ("Electric"))
        {
            SceneManager.LoadScene("LoseScene");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == ("Background"))
        {
            
            SceneManager.LoadScene("LoseScene");


        }
        if (collision.gameObject.tag == ("Door"))
        {

            SceneManager.LoadScene("WinScene");

        }
        if (collision.gameObject.tag == ("Finish"))
        {

            SceneManager.LoadScene("Finish");

        }
        if(collision.gameObject.tag == "BossMush")
        {
            BossLifeScript.LifeBar += 0.5f;
            MushPick.Play(1);

        }


    }

}