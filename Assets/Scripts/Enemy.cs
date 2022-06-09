using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private readonly string rock = "Rock";

    [SerializeField]
    private GameObject bullet;
    private GameObject shootBullet;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        speed = Random.Range(4, 10);
    }

    private void Start()
    {
        StartCoroutine(ShootBullets());
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);   
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(rock))
        {
            if(sr.flipX == true)
            {
                sr.flipX = false;
            } else
            {
                sr.flipX = true;
            }

            speed = -speed;
        }
    }

    IEnumerator ShootBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 15));

            if (sr.flipX == true)
            {
                shootBullet = Instantiate(bullet);
                shootBullet.transform.position = transform.position;
            }
        }
    }
}
