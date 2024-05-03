using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishPlayer : StateMachineBehaviour
{
    [SerializeField] private string animation;
    [SerializeField] Player_SO player;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponentInParent<PlayerController>().ChangeAnimation(animation, 0, stateInfo.length);
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        player.isTransforming = false;
        player.canMove = true;
    }
}
