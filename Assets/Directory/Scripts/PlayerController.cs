using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;



public class PlayerController : MonoBehaviour
{
    public SpriteRenderer[] sr;
    public InputActionReference move;
    //public InputActionReference run;
    public LayerMask terrainLayer;
    CharacterController characterController;
    [SerializeField] Player_SO player;

    public Vector3 moveDir;
    public float speed;
    private float groundDist;
    
    private float gravity = -9.81f;
    [SerializeField] float gravityMultiplier = 3.0f;
    private float velocity;

    //public bool isSprinting;
    public float sprintSpeed;

    public static Action isSprintingEvent;

    [SerializeField] private Animator animator;
    private string currentAnimation = "";

    [SerializeField] private List<GameObject> horizontalSpheres;
    [SerializeField] private List<GameObject> forwardSpheres;

    [SerializeField] float fowardRayDist;
    [SerializeField] float horizontalRayDist;

    public LayerMask wallLayer;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        sr = GetComponentsInChildren<SpriteRenderer>();

    }

   
    void Update()
    {
        if(player.canMove)
        {
            ApplyMovement();
        }
        
        CheckAnimation();
        ApplyFacingDirection();
        
    }

    private void ChangeAnimation(string animation, float crossfade = 0.2f)
    {
        if(currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossfade);
        }
    }

    private void CheckAnimation()
    {
        if(moveDir != new Vector3(0,-1,0) && player.canMove)
        {
            ChangeAnimation("Walk");
        }
        else
        {
            ChangeAnimation("Idle");
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        player.isSprinting = context.started || context.performed;
    }


    void ApplyMovement()
    {
        moveDir = move.action.ReadValue<Vector2>();
        //Debug.Log(move.action.ReadValue<Vector2>());
        //Debug.Log(moveDir);



        if (moveDir.y > 0)
        {
            foreach(GameObject o in forwardSpheres)
            {
                RaycastHit hit;
                if(Physics.Raycast(o.transform.position, Vector3.forward, out hit, fowardRayDist, wallLayer))
                {
                    if(hit.collider)
                    {
                        moveDir.y = 0;
                    }
                }
            }
        }
        if (moveDir.x > 0)
        {
            foreach (GameObject o in horizontalSpheres)
            {
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, Vector3.right, out hit, horizontalRayDist, wallLayer))
                {
                    if (hit.collider)
                    {
                        moveDir.x = 0;
                    }
                }
            }
        }
        if (moveDir.x < 0)
        {
            foreach (GameObject o in horizontalSpheres)
            {
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, Vector3.left, out hit, horizontalRayDist, wallLayer))
                {
                    if (hit.collider)
                    {
                        moveDir.x = 0;
                    }
                }
            }
        }



        if (player.isSprinting && player.stamina > 0 && moveDir != new Vector3(0,0,0))
        {
            moveDir = new Vector3(moveDir.x * sprintSpeed, 0, moveDir.y * sprintSpeed);
            animator.speed = 3;
            isSprintingEvent?.Invoke();
        }
        else
        {
            animator.speed = 1;
            moveDir = new Vector3(moveDir.x * speed, 0, moveDir.y * speed);
        }
        
        ApplyGravity(); // needs to be here
        characterController.Move(moveDir * Time.deltaTime);
        
    }

    void ApplyFacingDirection()
    {
        if (moveDir.x != 0 && moveDir.x < 0)
        {
            foreach (SpriteRenderer spriteRenderer in sr)
            {
                spriteRenderer.flipX = true;
            }
        }
        else if (moveDir.x != 0 && moveDir.x > 0)
        {
            foreach (SpriteRenderer spriteRenderer in sr)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    void ApplyGravity()
    {
        if (characterController.isGrounded && velocity < 0.0f)
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }

        moveDir.y = velocity;
    }
    
    void groundPosition()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }
    }



}
