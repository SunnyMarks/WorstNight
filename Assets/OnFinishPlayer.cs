using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishPlayer : StateMachineBehaviour
{
    [SerializeField] private string animation;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInParent<PlayerController>().ChangeAnimation(animation, 0, stateInfo.length);

    }
}
