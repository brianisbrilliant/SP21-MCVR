using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWhenNear : MonoBehaviour
{
    [Tooltip("The animator that you want to control.")]
    public Animator anim;

    public string closeTriggerName = "OnEnter";
    public string farTriggerName = "OnExit";

    public AudioSource aud;

    public Transform target;
    public float close = 3f, far = 5f;

    // to make this run only once.
    private bool closeTriggered = false, farTriggered = true;

    void Start() {
        if(anim == null) {
            anim = GetComponent<Animator>();
        }
        if(aud == null) {
            aud = GetComponent<AudioSource>();
        }
    }


    void Update() {
        float distance = Vector3.Distance(this.transform.position, target.transform.position);

        if(distance < close && !closeTriggered) {
            anim.SetTrigger(closeTriggerName);
            if(aud != null) aud.Play();
            closeTriggered = true;
            farTriggered = false;
        }

        if(distance > far && !farTriggered) {
            anim.SetTrigger(farTriggerName);
            if(aud != null) aud.Stop();
            farTriggered = true;
            closeTriggered = false;
        }
    }

}

