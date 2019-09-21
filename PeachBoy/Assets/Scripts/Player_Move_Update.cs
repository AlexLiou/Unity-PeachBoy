using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Update : MonoBehaviour {

    public AudioClip slashSound;
    public AudioClip jumpSound;
    private AudioSource source;
    private float volLowRange = 0.5f;
    private float volHighRange = 1.0f;

    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    private float moveX;
    private float moveY;

    [Tooltip("Only change this if your character is having problems jumping when they shouldn't or not jumping at all.")]
    public float distToGround = 1.0f;
    private bool inControl = true;

    [Tooltip("Everything you jump on should be put in a ground layer. Without this, your player probably* is able to jump infinitely")]
    public LayerMask GroundLayer;



    void Awake(){
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inControl)
        {
            PlayerMove();
        }
        
    }

    void PlayerMove()
    {
        //QUIT
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        //ANIMATIONS
        if (Input.GetButtonDown("Jump"))
        {
            
            source.PlayOneShot(jumpSound, 1.0f);
            GetComponent<Animator>().SetBool("IsJumping", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsJumping", false);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            
            source.PlayOneShot(slashSound, 3.0f);
            GetComponent<Animator>().SetBool("IsSlashing", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsSlashing", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetBool("IsThrowing", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsThrowing", false);
        }
        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }

        //PLAYER DIRECTION
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);

    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distToGround, GroundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;

    }

    public void SetControl(bool b)
    {
        inControl = b;
    }
}
