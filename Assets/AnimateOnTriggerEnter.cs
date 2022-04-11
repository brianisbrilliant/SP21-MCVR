using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnTriggerEnter : MonoBehaviour
{
    [Tooltip("The animator that you want to control.")]
    public Animator anim;

    public string enterTriggerName = "OnEnter";
    public string exitTriggerName = "OnExit";

    [Tooltip("Should the trigger only respond to the player?")]
    public bool restrictedToPlayer = true;
    public string playerTag = "Player";

    void Start() {
        if(anim == null) {
            anim = GetComponent<Animator>();
        }
    }

    void OnTriggerEnter(Collider other) {
        if(restrictedToPlayer) {
            if(other.gameObject.CompareTag(playerTag)) {
                anim.SetTrigger(enterTriggerName);
            }
        } else {
            anim.SetTrigger(enterTriggerName);
        }
    }

    void OnTriggerExit(Collider other) {
        if(restrictedToPlayer) {
            if(other.gameObject.CompareTag(playerTag)) {
                anim.SetTrigger(exitTriggerName);
            }
        } else {
            anim.SetTrigger(exitTriggerName);
        }
    }
}
