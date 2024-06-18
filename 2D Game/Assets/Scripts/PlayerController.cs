using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    [Tooltip("Tick to allow the player to face the correct way when moving.")]
    public bool isFliping=false;
    [Header("Jump Settings")]
    public float jumpForce = 5f;
    private float numOfJumps=0;
    private float maxJumps=2;
    private bool isJumping=false;

    [Header("Ground Settings")]
    [Tooltip("Create a 'Ground' Layer and assign it here and to all Ground Game Objects")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    private bool isGrounded;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    [Header("Input Settings")]
    [Tooltip("Attach the Input Actions Map from the Project files.")]
    public PlayerInputActions playerInputActions;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isMoving=false;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        playerInputActions = new PlayerInputActions();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerInputActions.Player.Enable();
        playerInputActions.Player.Move.performed += OnMove;
        playerInputActions.Player.Move.canceled += OnMove;
        playerInputActions.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        playerInputActions.Player.Move.performed -= OnMove;
        playerInputActions.Player.Move.canceled -= OnMove;
        playerInputActions.Player.Jump.performed -= OnJump;
        playerInputActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        
        if (isGrounded || numOfJumps<=maxJumps)
        {
            numOfJumps++;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            if(animator!=null)
            {
                if(numOfJumps==1)
                {
                    animator.SetBool("isJumping",true);
                }
                else if(numOfJumps==2)
                {
                    animator.SetBool("isDoubleJumping",true);
                }
            }
        }

    }
    private void FixedUpdate()
    {
        PlayerAnimations();

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Move the player
        Vector2 movement = moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.AddForce(movement, ForceMode2D.Impulse);

        if(isFliping & moveInput.x>0)
        {
            spriteRenderer.flipX=false;
        }
        else if(isFliping & moveInput.x<0)
        {
            spriteRenderer.flipX=true;
        }
        
    }

    private void PlayerAnimations()
    {
        if(animator!=null)
        {
            isMoving=moveInput!=Vector2.zero;
            animator.SetBool("isMoving",isMoving);
            if(rb.velocity.y<0)
            {
                animator.SetBool("isDoubleJumping",false);
            }
            if(isGrounded && rb.velocity.y<=0)
            {
                animator.SetBool("isJumping",false);
                numOfJumps=0;
            }
        }
    }
}