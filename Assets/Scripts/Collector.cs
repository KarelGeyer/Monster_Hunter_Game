using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private readonly string enemy = "Enemy";
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemy))
        {
            Destroy(collision.gameObject);
        }
    }
}
