using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingText : MonoBehaviour
{
    public float bounceForce = 5f;
    public float speed = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0f);
    }

    void Update()
    {
        if (transform.position.x < -5)
        {
            rb.velocity = new Vector2(speed, 0f);
        }
        else if (transform.position.x > 5)
        {
            rb.velocity = new Vector2(-speed, 0f);
        }
    }
}