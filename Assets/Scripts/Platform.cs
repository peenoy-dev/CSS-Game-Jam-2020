using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : Entity
{
    [SerializeField]
    private float speed;
    private int lifeSpan;
    private int timeAlive;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(-speed, 0f);
        lifeSpan = 2 * 50;
        timeAlive = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeAlive++;
        if (timeAlive >= lifeSpan)
        {
            Destroy(this.gameObject);
        }
    }
}
