using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private Transform player;
    private Vector3 temPos;

    [SerializeField]
    private float minX = 60, maxX = -90;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (!player) return;

        temPos = transform.position;
        temPos.x = player.position.x;

        if (temPos.x < minX) temPos.x = minX;
        if (temPos.x > maxX) temPos.x = maxX;

        transform.position = temPos;
    }
}
