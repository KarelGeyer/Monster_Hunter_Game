using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private int speed = 15;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision happend");
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
