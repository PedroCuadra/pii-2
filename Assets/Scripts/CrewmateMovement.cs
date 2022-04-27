using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CrewmateMovement : MonoBehaviour
{
    public float jumpForce = 10f;
    public float speed = 10f;
    
    private Rigidbody2D rb;

    public Animator crewmateBaseAnimator;

    bool isGrounded = false;
    bool isJumping  = false;
    bool isTouchingCeiling = false;
    bool isTouchingWall = false;

    public int maxJump = 1;
    private int jumps = 0;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    //bool lastFacingRight = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        
        float s = 0;
        if(Input.GetKey(KeyCode.A)) s = -1f;
        if(Input.GetKey(KeyCode.D)) s = 1f;
        rb.velocity = new Vector2(s * speed, rb.velocity.y);
        crewmateBaseAnimator.SetBool("isWalking", s != 0);
        crewmateBaseAnimator.SetBool("isJumping", isJumping);

        if(s > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if(s < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void Jump(){
        if(!isGrounded && jumps >= maxJump)
            return;

        rb.velocity = Vector2.up * jumpForce;
        isGrounded = false;
        isJumping = true;
        jumps ++;
    }


    void OnCollisionEnter2D(Collision2D collision){

        // get the point of contact
        ContactPoint2D contact = collision.contacts[0];
        
        // get the normal vector of the collided surface
        Vector2 normal = contact.normal;

        // if the normal is pointing up we
        // know the collision is at the bottom 
        // of the character so we know we're grounded
        isGrounded = normal.y >= 0.1f;

        if(isGrounded){
            jumps=0; 
            isJumping = false;
        }

        // if the normal is pointing down we know the collision
        // is at the top of the character so we reached a ceiling
        isTouchingCeiling = normal.y <= -0.1f;

        // If the normal is pointing left or right, the character
        // is touching a wall
        isTouchingWall = Mathf.Abs(normal.x) > 0.1f;
    }

    void FixedUpdate(){
        crewmateBaseAnimator.SetBool("isJumping", isJumping);
        //crewmateBaseAnimator.SetBool("isGrounded", isGrounded);
        //crewmateBaseAnimator.SetBool("isTouchingCeiling", isTouchingCeiling);
        //crewmateBaseAnimator.SetBool("isTouchingWall", isTouchingWall);
    }

}
