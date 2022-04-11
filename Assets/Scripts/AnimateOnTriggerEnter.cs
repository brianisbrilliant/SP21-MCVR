using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnTriggerEnter : MonoBehaviour
{
    [Tooltip("The animator that you want to control.")]
    public Animator anim;

    public string enterTriggerName = "OnEnter";
    public string exitTriggerName = "OnExit";

    public AudioSource aud;

    [Tooltip("Should the trigger only respond to the player?")]
    public bool restrictedToPlayer = true;
    public string playerTag = "Player";

    void Start() {
        if(anim == null) {
            anim = GetComponent<Animator>();
        }
        if(aud == null) {
            aud = GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other) {
        if(restrictedToPlayer) {
            if(other.gameObject.CompareTag(playerTag)) {
                anim.SetTrigger(enterTriggerName);
                if(aud != null) aud.Play();
            }
        } else {
            anim.SetTrigger(enterTriggerName);
            if(aud != null) aud.Play();
        }
    }

    void OnTriggerExit(Collider other) {
        if(restrictedToPlayer) {
            if(other.gameObject.CompareTag(playerTag)) {
                anim.SetTrigger(exitTriggerName);
                if(aud != null) aud.Stop();
            }
        } else {
            anim.SetTrigger(exitTriggerName);
            if(aud != null) aud.Stop();
        }
    }
}
