using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float Speed;
    public float runSpeed;
    public float walkSpeed;

    public float JumpForce;
    public float Health = 100f;

    public Rigidbody2D Body;
    public Animator animator;
    public CharacterController2D controller;


    public float horizontalMove;
    public bool Jumping = false;
    public bool crouch = false;
    public float timer = 400.0f;


    public float togle;
    public int EscapeTogle;
    public GameObject player;
    public GameObject PlayerSprite;
    public AudioSource Jump;
    public AudioSource Die;

    // Start is called before the first frame update
    void Start()
    {
        Health = 100f;

        Speed = walkSpeed;
        animator.SetBool("Shrink", false);
        animator.SetBool("Grow", false);
    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            togle = 1 -togle;
        }

        if (togle == 0)
        {
            Speed = runSpeed;
            animator.SetBool("Sprinting", false);
        }
        if (togle == 1)
        {
            animator.SetBool("Sprinting", true);
            Speed = walkSpeed;
        }

       

        if (Mathf.Abs(horizontalMove) == 0.0f)
        {
            togle = 0;
        }


        if (Input.GetKey(KeyCode.Mouse0))
        {   
            animator.SetBool("Grow", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {        
            animator.SetBool("Grow", false);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
           animator.SetBool("Shrink", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            animator.SetBool("Shrink", false);
        }


        //Control maths

        if (horizontalMove < 0)
        {
            PlayerSprite.transform.rotation = Quaternion.Euler(0, 180, 0); // Flip the sprite
        }
        else if (horizontalMove > 0)
        {
            PlayerSprite.transform.rotation = Quaternion.Euler(0, 0, 0); // Reset the sprite
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * Speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            Jumping = true;
            animator.SetBool("Jumping", true);
            Jump.Play();

        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }      
    }
    public void Onlanding()
    {
        animator.SetBool("Jumping", false);
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, Jumping);
        Jumping = false;
    }
}
