using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonAnimControl : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    HoverButton button;

    [SerializeField, Tooltip("Enter the name of the trigger in your Animator Controller that you would like to trigger.")]
    string triggerName = "NextAnimation";

    void Start() {
        Debug.Log("Listening...");
        button.onButtonDown.AddListener(OnButtonDown);
    }

    void OnButtonDown(Hand fromHand) {
        if(anim != null) {
            anim.SetTrigger(triggerName);
        } else {
            Debug.Log("There is no animator attached to this script!");
        }
    }
}
