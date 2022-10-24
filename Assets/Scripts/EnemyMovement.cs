 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private static Animator anim;
    private Vector2 movement;
    public Vector3 dir;
    private bool StartGame = false;
    private Renderer thisRend;
    private Transform Boss2;
    public Renderer BossStart;

    private bool isInChaseRange;
    private bool isInAttackRange;

    public AudioSource GotHeated;
    public AudioSource DeathSound;

    private void Start()
    {
        BossLifeScript.LifeBar = 0.5f;
        shouldRotate = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        Boss2 = GameObject.FindWithTag("Boss2").transform;
        thisRend = this.GetComponent<Renderer>();

    }

    private void Update()
    {
        if(target.transform.position.x != 0.09f)
        {
            StartGame = true;
        }
        if (target.transform.position.y != -1.97f)
        {
            StartGame = true;
        }

        if (Boss2.transform.position.y > 0.23f && !StartGame)
        {
            thisRend.material.color = new Color(1, 1, 1, 0f);

        }
        if (Boss2.transform.position.y == (0.23f) && !StartGame)
        {

            thisRend.material.color = new Color(1, 1, 1, 1f);
            BossStart.material.color = new Color(1, 1, 1, 0f);

            shouldRotate = true;
        }

        if (StartGame)
        {
            anim.SetBool("isMoving", isInChaseRange);


        }
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        if (shouldRotate && StartGame)
        {
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
        }
        if (BossLifeScript.LifeBar > 5)
        {
            anim.SetBool("Death", true);
            speed = 0;
        }
        if(BossLifeScript.LifeBar == 1)
        {
            StartCoroutine(LifeBar());
        }
        if (BossLifeScript.LifeBar == 2)
        {
            StartCoroutine(LifeBar());
        }
        if (BossLifeScript.LifeBar == 3)
        {
            StartCoroutine(LifeBar());
        }
        if (BossLifeScript.LifeBar == 4)
        {
            StartCoroutine(LifeBar());
        }

    }

    private void FixedUpdate()
    {
        if(isInChaseRange && StartGame)
        {
            moveCharacter(movement);
        }
        if (StartGame)
        {
            rb.velocity = Vector2.zero;
        }

        


    }


    private void moveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("LoseScene");
        }

    }
    public static void Hearth()
    {
        anim.SetBool("Hearth", true);
        anim.SetBool("Hearth", false);


    }
    public static void LifeManage()
    {

        anim.SetBool("Hearth", false);


    }
    public IEnumerator LifeBar()
    {
        speed = 0;
        anim.SetBool("Hearth", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("Hearth", false);
        speed = 0.4f;


    }

}
