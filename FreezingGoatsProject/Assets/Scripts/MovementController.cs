using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    public string controllerSuffix = "";
    public float speed;                //Floating point variable to store the player's movement speed.
    public bool honk;
    public bool yeet;

    public GoatController goatController;
    public InteractionController interactionController;

    float moveHorizontal;
    bool jump;

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

        if((float)Input.GetAxis("Fire" + controllerSuffix)==1.0f)
        {
            honk = true;
            
        }

        if (Input.GetButtonDown("Interact" + controllerSuffix))
        {
            yeet = true;
            //Debug.Log(yeet);

        }
       
    }
    void FixedUpdate()
    {
        goatController.Move(moveHorizontal * Time.fixedDeltaTime, jump);
        interactionController.Honk(honk);
       //Debug.Log(moveHorizontal + " controller: " + controllerSuffix);
        jump = false;
        honk = false;
        yeet = false;
      
      
    }
}