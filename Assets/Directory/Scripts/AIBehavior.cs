using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AINav))]
public class AIBehavior : MonoBehaviour
{
    AINav aINav;
    NavMeshAgent navMeshAgent;
    SpriteRenderer[] sr;

    [SerializeField] float chaseSpeed;
    [SerializeField] float patrolSpeed;
    [SerializeField] float chargeSpeed;


    [SerializeField] float stamina;
    [SerializeField] float drainRate;
    [SerializeField] float recoveryRate;

    bool isCharging;

    [SerializeField] private Animator animator;
    private string currentAnimation = "";

    void Start()
    {
        aINav = gameObject.GetComponent<AINav>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        sr = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    
    void Update()
    {
        if(aINav.seesPlayer)
        {
            if(isCharging)
            {
                ChargeAtPlayer();
                DrainStamina();
            }
            else
            {
                GiveChase();
            }
        }
        else
        {
            Patrol();
        }

        if(!isCharging)
        {
            RecoverStamina();
        }

        FlipSprite();
        CheckAnimation();
    }

    void GiveChase()
    {
        animator.speed = 2;
        navMeshAgent.speed = chaseSpeed;
    }

    void ChargeAtPlayer()
    {
        animator.speed = 3;
        navMeshAgent.speed = chargeSpeed;  
    }

    void Patrol()
    {
        animator.speed = 1;
        navMeshAgent.speed = patrolSpeed;
    }

    void DrainStamina()
    {
        if (stamina > 0)
        {
            stamina -= drainRate * Time.deltaTime;
        }
        else
        {
            isCharging = false;
        }
    }

    void RecoverStamina()
    {
        if(stamina < 100)
        {
            stamina += recoveryRate * Time.deltaTime;
        }
        else
        {
            isCharging = true;
        }
        
    }


    void FlipSprite()
    {
        if (navMeshAgent.velocity.x > 0.1f)
        {
            foreach (SpriteRenderer spriteRenderer in sr)
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (navMeshAgent.velocity.x < -0.1f)
        {
            foreach (SpriteRenderer spriteRenderer in sr)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    public void ChangeAnimation(string animation, float crossfade = 0.2f, float time = 0)
    {
        if (time > 0) StartCoroutine(Wait());
        else Validate();

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(time - crossfade);
            Validate();
        }

        void Validate()
        {
            if (currentAnimation != animation)
            {
                currentAnimation = animation;

                if(currentAnimation == "")
                {
                    CheckAnimation();
                }
                else
                {
                    animator.CrossFade(animation, crossfade);
                }
                        
                
            }
        }
        
    }

    private void CheckAnimation()
    {
        if(currentAnimation == "Damage")
        {
            return;
        }

        if (navMeshAgent.velocity != Vector3.zero)
        {
            ChangeAnimation("Walk");
        }
        else
        {
            ChangeAnimation("Idle");
        }
    }

    public void DamageAnimation()
    {
        ChangeAnimation("Damage");
    }
}
