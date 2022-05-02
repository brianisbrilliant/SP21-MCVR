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
    [Tooltip("For Emily, when true, instead of setting a trigger, just set the anim.speed to 0.")]
    public bool pausePlay = false;

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
                if(pausePlay) {
                    anim.speed = 1;
                } else {
                    anim.SetTrigger(enterTriggerName);
                }
                if(aud != null) aud.Play();
            }
        } else {
            if(pausePlay) {
                anim.speed = 1;
            } else {
                anim.SetTrigger(enterTriggerName);
            }
            if(aud != null) aud.Play();
        }
    }

    void OnTriggerExit(Collider other) {
        if(restrictedToPlayer) {
            if(other.gameObject.CompareTag(playerTag)) {
                if(pausePlay) {
                    anim.speed = 0;
                } else {
                    anim.SetTrigger(exitTriggerName);
                }
                if(aud != null) aud.Stop();
            }
        } else {
            if(pausePlay) {
                anim.speed = 0;
            } else {
                anim.SetTrigger(exitTriggerName);
            }
            if(aud != null) aud.Stop();
        }
    }
}
