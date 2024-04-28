using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishRat : StateMachineBehaviour
{
    [SerializeField] private string animation;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInParent<AIBehavior1>().ChangeAnimation(animation, 0.2f, stateInfo.length);

    }
}
