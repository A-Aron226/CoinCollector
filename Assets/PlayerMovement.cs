using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1; //adjusted to 2.5 to match walking animation
    [SerializeField] float jumpForce = 10;
    [SerializeField] float groundCheck = 1; //adjusted to 1.2 in unity
    [SerializeField] LayerMask environmentOnly; //checks for certain layer to collide with
    [SerializeField] Animator anim;
    [SerializeField] PlayerStats stats;
    
    Rigidbody rb;
    float forwardMovementInput, rightMovementInput;
    bool onGround = false;

    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        stats.currentHealth = stats.maxHealth;
        stats.coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        onGround = (Physics.Raycast(transform.position, Vector3.up * -1, groundCheck, environmentOnly));
        /* the simplified version of this loop: if (Physics.Raycast(transform.position, Vector3.up * -1, groundCheck))
        {
            onGround = true;
        }*/

        forwardMovementInput = Input.GetAxis("Vertical"); //uses W and S keys for forward movement
        rightMovementInput = Input.GetAxis("Horizontal"); //uses A and D keys for side movement

        var movementVector = new Vector3(rightMovementInput, 0, forwardMovementInput);

        anim.SetFloat("speed", movementVector.magnitude); //animation transition
        anim.transform.forward = movementVector; //to make animation turn based on direction

        if (Input.GetButtonDown("Jump") && onGround) //When the jump button has been pressed
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }

        if (stats.currentHealth <= 0 || transform.position.y <= -5)
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (stats.coinCount == 5)
        {
            SceneManager.LoadScene("WinScene");
        }

        /*if (Input.GetButtonDown("Submit")) //Debug test to check if health works
        {
            anim.SetTrigger("hit");
            stats.currentHealth -= 1;

            if (stats.currentHealth < 0)
            {
                stats.currentHealth = 10;
            }
        }*/

        Debug.DrawLine(transform.position, transform.position + transform.up * -groundCheck, Color.red); 
        //Draws the start position, end position then add the direction and multiply by length (in that order)
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            anim.SetTrigger("hit");
        }
    }

    private void FixedUpdate()
    {
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camForward.Normalize();

        camRight.y = 0;
        camRight.Normalize();

        Vector3 forwardRelative = forwardMovementInput * camForward;
        Vector3 rightRelative = rightMovementInput * camRight;


        Vector3 movementVector = (forwardRelative + rightRelative).normalized * speed;
        movementVector.y = rb.velocity.y; //personal note: use normalize to fix diagonal movement or any form of movement. Use this script as reference in the future

        rb.velocity = movementVector;

        //rb.AddForce(movementVector * speed, ForceMode.Force); Differnt movement use if you don't want to use velocity.
    }
}
