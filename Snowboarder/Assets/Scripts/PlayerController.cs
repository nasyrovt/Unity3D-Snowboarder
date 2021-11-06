using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1;
    [SerializeField] float speedChangeRate = 0.02f;
    Rigidbody2D rb2D;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        //Push up increases speed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed += speedChangeRate;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed -= speedChangeRate;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torqueAmount);
        }
    }
}
