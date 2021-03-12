using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTrigger : MonoBehaviour
{
    public Transform target;                    // this is the player
    public float waitInterval = 1f;             // how often do we look for the player?
    public float resetInterval = 30f;           // when should we play the animation again?
    public float triggerDistance = 5f;
    public Animator anim;
    public AudioSource aud;
    
    private bool animationIsRunning = false;    // is the animation running right now?

    void Start()
    {
        if(anim == null) {
            anim = this.GetComponent<Animator>();
        }

        if(aud == null) {
            aud = this.GetComponent<AudioSource>();
        }

        StartCoroutine(LookForTarget());
    }

    IEnumerator LookForTarget() {
        while(true) {
            yield return new WaitForSeconds(waitInterval);
            float distance = Vector3.Distance(this.transform.position, target.transform.position);
            Debug.Log("Distance from player is " + distance);
            if(distance < triggerDistance) {
                PlayAnimation();
            }
        }
    }

    void PlayAnimation() {
        if(animationIsRunning) {
            return;
        } else {
            // settrigger
            anim.SetTrigger("PlayerIsNear");
            // playaudio
            aud.Play();
            // set anim bool to true.
            animationIsRunning = true;
            // start the reset timer
            StartCoroutine(ResetAnim());
        }
    }

    IEnumerator ResetAnim () {
        yield return new WaitForSeconds(resetInterval);
        animationIsRunning = false;
    }

}
