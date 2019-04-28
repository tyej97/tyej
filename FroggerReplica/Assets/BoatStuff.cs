using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatStuff : MonoBehaviour
{
    public Rigidbody2D rb;

    public float minSpeed = 3f;
    public float maxSpeed = 6f;

    float speed = 1f;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy(this.gameObject);
        }
    }
}
