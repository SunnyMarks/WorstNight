using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinish : StateMachineBehaviour
{
    [SerializeField] private string animation;

    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInParent<AIBehavior>().ChangeAnimation(animation, 0.2f, stateInfo.length);

    }


}
