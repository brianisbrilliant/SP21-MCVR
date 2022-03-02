// This script randomizes the speed of the Animator Controller 
// so that multiple instances do not move in perfect sync.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleSpeed : StateMachineBehaviour
{
    [SerializeField]
    Vector2 range = new Vector2(0.9f, 1.1f);

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.speed = Random.Range(0.9f,1.1f);
    }
}
