using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animControl;
    public float speed;
    private Transform target;
    private Transform Boss2;
    public Renderer BossStart;
    private Rigidbody2D rb;
    private bool StartGame = false;
    private Renderer thisRend;

    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;
    private bool isInChaseRange;
    private bool isInAttackRange;
    private Vector2 movement;
    public Vector3 dir;



    public void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        Boss2 = GameObject.FindWithTag("Boss2").transform;
        thisRend = this.GetComponent<Renderer>();
        
    }
    

    public void Update()
    {
        animControl.SetBool("isMoving", isInChaseRange);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        if (shouldRotate)
        {
            animControl.SetFloat("X", dir.x);
            animControl.SetFloat("Y", dir.y);
        }


        if (Boss2.transform.position.y > 0.23f && !StartGame)
        {
            thisRend.material.color = new Color(1, 1, 1, 0f);

        }
        if (Boss2.transform.position.y == (0.23f) && !StartGame)
        {

            thisRend.material.color = new Color(1, 1, 1, 1f);
            BossStart.material.color = new Color(1, 1, 1, 0f);
            StartGame = true;
        }

      

        if (Vector2.Distance(transform.position, target.position) < 8 && StartGame)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
           
        }

    }

    public void StartShow()
    {
        

    }
   
    

}

