using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private bool hasJumpedLastUpdate;
    private bool started;
    private int evolutionStage;
    [SerializeField]
    private float gravMagnitude;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        hasJumpedLastUpdate = false;
        animator = GetComponent<Animator>();
        animator.SetInteger("evolutionStage", 0);
        evolutionStage = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(Input.GetAxis("Jump"));
        if (Input.GetAxis("Jump") == 1)
        {
            started = true;
            if (!hasJumpedLastUpdate)
            {
                gravMagnitude = -gravMagnitude;
                hasJumpedLastUpdate = true;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Evolve();
        }
    }


    void FixedUpdate()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        if (started)
        {
            body.velocity = new Vector2(0f, -gravMagnitude);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasJumpedLastUpdate = false;
    }

    public void Evolve()
    {
        if (evolutionStage == 0)
        {
            evolutionStage = 1;
            animator.SetInteger("evolutionStage", 1);
        }
        else if (evolutionStage == 1)
        {
            evolutionStage = 2;
            animator.SetInteger("evolutionStage", 2);
        }
    }
}
