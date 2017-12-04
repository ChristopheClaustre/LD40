using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_answer : StateMachineBehaviour {
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.gameObject.GetComponent<ONEPartieIManager>().IsPlayerPlayed)
        {
            if(!animator.gameObject.GetComponent<ONEPartieIManager>().isTheGoodAnswer())
            {
                animator.SetInteger("Chance", animator.GetInteger("Chance") - 1);
            }
            else
            {
                if(animator.gameObject.GetComponent<ONEPartieIManager>().IsPlayerWin)
                {
                    animator.SetBool("isReadyForPart2", true);
                }
            }
            animator.SetBool("isAnswered", true);
        }
        //Set to false game manager flags
        animator.gameObject.GetComponent<ONEPartieIManager>().IsPlayerPlayed = false;
        animator.gameObject.GetComponent<ONEPartieIManager>().IsPlayerWin = false;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
