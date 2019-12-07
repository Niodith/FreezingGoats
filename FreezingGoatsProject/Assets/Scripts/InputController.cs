﻿using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public string controllerSuffix = "";
    public float speed;                //Floating point variable to store the player's movement speed.
    public bool honk;
    

    public GoatController goatController;
    public InteractionController interactionController;

    float moveHorizontal;
    bool jump;
    bool yeet;
    float yeetDuration = 0f;

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        moveHorizontal = Input.GetAxisRaw("Horizontal" + controllerSuffix) * speed;

        if (Input.GetButtonDown("Jump" + controllerSuffix))
        {
            jump = true;
        }

        if(Input.GetAxis("Scream" + controllerSuffix)>=0.7f)
        {
            honk = true; 
        }

        if (Input.GetButton("Interact" + controllerSuffix))
        {
            yeetDuration += Time.deltaTime;
            Debug.Log("yeet charging"); 
        }

        if (Input.GetButtonUp("Interact" + controllerSuffix))
        {
            yeet = true;
            Debug.Log( "yeet num:" + controllerSuffix +" duration " + yeetDuration);

        }

    }
    void FixedUpdate()
    {
        goatController.Move(moveHorizontal * Time.fixedDeltaTime, jump);
        jump = false;

        interactionController.Honk(honk);
        honk = false;

        if (yeet)
        {
            interactionController.Yeet(yeetDuration);
            yeetDuration = 0f;
            yeet = false;
        }
       //Debug.Log(moveHorizontal + " controller: " + controllerSuffix);
      
      
    }
}