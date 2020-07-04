﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{

    public GameObject player;
    private Rigidbody2D rbody;

    void Start()
    {
        rbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rbody.velocity = Vector2.zero;

            Vector2 force = new Vector2(100, 180);
            if (Input.mousePosition.x < Screen.width/2)
            {
                rbody.angularVelocity = 100;
                force.x = -force.x;
            } else
            {
                rbody.angularVelocity = -100;
            }

            rbody.AddForce(force);
        }
    }
}
