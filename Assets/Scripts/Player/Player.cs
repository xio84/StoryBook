using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public Transform groundCheckTransform = null;
    
    [SerializeField] private LayerMask ground;
    [SerializeField] private float groundRememberPeriod = 0.1f;
    [SerializeField] private float jumpPressedRememberPeriod = 0.1f;
    [SerializeField] private float jumpVelocity = 5f;
    //[SerializeField] private float jumpDropModifier = 0.5f;

    [SerializeField] private float accModifier = 0.3f;
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private float fHorizontalDampingWhenStopping = 0.5f;
    [SerializeField] private float fHorizontalDampingWhenTurning = 0.5f;
    //[SerializeField] private float fHorizontalDampingAir = 0.1f;
    [SerializeField] private float fHorizontalDampingBasic = 0.5f;

    private Animator animator;

    //private bool jumpKeyUp;
    private float horizontalInput, groundRememberTime,jumpPressedRememberTime;
    private Rigidbody getRigidbody = null;
    private Collider getCollider;
    //private int superJumpsRemaining;
    private int jumpLeft;
    private bool canMove;
    private bool faceLeft;
    private float distToGround;

    // Keypad Canvas Object
    public Canvas CanvasObject;
    public SpriteRenderer m_sprite;

    // Start is called before the first frame update
    void Start()
    {
        getCollider = GetComponent<Collider>();
        getRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        CanvasObject.enabled = false;
        canMove = true;
        faceLeft = true;

        distToGround = getCollider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
            if (horizontalInput < 0 && !faceLeft)
            {
                m_sprite.flipX = false;
                faceLeft = !faceLeft;
            }
            else if (horizontalInput > 0 && faceLeft)
            {
                m_sprite.flipX = true;
                faceLeft = !faceLeft;
            }

            jumpPressedRememberTime -= Time.deltaTime;
            groundRememberTime -= Time.deltaTime;

            if (Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
            {
                // Landing on the ground
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsDoubleJumping", false);
                groundRememberTime = groundRememberPeriod;
                jumpLeft = 1;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (groundRememberTime > 0f)
                {
                    // First jump
                    animator.SetBool("IsJumping", true);
                    animator.SetBool("IsDoubleJumping", false);
                }
                else if (jumpLeft > 0)
                {
                    // Second jump
                    animator.SetBool("IsJumping", false);
                    animator.SetBool("IsDoubleJumping", true);
                }
                jumpPressedRememberTime = jumpPressedRememberPeriod;
            }

            //if (Input.GetKeyUp(KeyCode.Space))
            //{
            //    jumpKeyUp = true;
            //}
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            CanvasObject.enabled = !CanvasObject.enabled;
            canMove = !canMove;
        }
    }

    // FixedUpdate is called once every physics update
    private void FixedUpdate()
    {
        float fHorizontalVelocity = getRigidbody.velocity.x;
        if ((Mathf.Sign(horizontalInput)) != Mathf.Sign(fHorizontalVelocity)|| Mathf.Abs(fHorizontalVelocity)<maxSpeed) fHorizontalVelocity += horizontalInput*accModifier;

        if (!gameObject.GetComponent<Grapple>().isGrappling)
        {
            //if (groundRememberTime < 0f)
            //{
            //    fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingAir, Time.deltaTime * 10f);
            //}
            //else 
            
            if(Mathf.Abs(horizontalInput) < 0.01f)
            {
                fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenStopping, Time.deltaTime * 10f);
            }
            else if ((Mathf.Sign(horizontalInput)) != Mathf.Sign(fHorizontalVelocity))
            {
                fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenTurning, Time.deltaTime * 10f);
            }
            else 
            {
                fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingBasic, Time.deltaTime * 10f);
            }
        }
        //getRigidbody.velocity = new Vector3(fHorizontalVelocity, getRigidbody.velocity.y);
        getRigidbody.AddForce(new Vector3(fHorizontalVelocity - getRigidbody.velocity.x,0), ForceMode.VelocityChange);


        if (jumpPressedRememberTime > 0f) { 
            if (groundRememberTime > 0f)
            {
                // First jump
                getRigidbody.velocity = new Vector3(getRigidbody.velocity.x, jumpVelocity);
                jumpPressedRememberTime = 0f;
                groundRememberTime = 0f;
            } 
            else if (jumpLeft > 0)
            {
                // Second jump
                getRigidbody.velocity = new Vector3(getRigidbody.velocity.x, jumpVelocity);
                jumpPressedRememberTime = 0f;
                groundRememberTime = 0f;
                jumpLeft--;
            }
        }
        //if (jumpKeyUp)
        //{
        //    if (getRigidbody.velocity.y > 0)
        //   {
        //        getRigidbody.velocity = new Vector3(getRigidbody.velocity.x, getRigidbody.velocity.y * jumpDropModifier, getRigidbody.velocity.z);
        //    }
        //    jumpKeyUp = false;
        //}
    }
}
