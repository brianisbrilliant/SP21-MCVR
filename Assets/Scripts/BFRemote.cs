using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class BFRemote : MonoBehaviour
{
    // this gets actions as defined in the inputs.
    public SteamVR_Action_Boolean jumpAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("platformer", "Jump");

    private Renderer rend;
    private SteamVR_Input_Sources hand; // tell me more about this
    private Interactable interactable;

    private bool jump;      // just mirrors the jumpaction, or changes it from a steamvr boolean to a unity boolean.

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {   
        // if this remote is being held
        if(interactable.attachedToHand) {
            // what does this line do? What hand types are there?
            hand = interactable.attachedToHand.handType;
            // is this equivalent to "getkeydown" or "getkey"?
            if(jumpAction[hand].stateDown) {
                rend.material.color = Color.blue;
                Debug.Log("Turning <color=blue>Blue!</color>");
            }
            if(jumpAction[hand].stateUp) {
                rend.material.color = Color.white;
            }
        } 
        else {
            // is there a way to talk "On hand detach?"
                // with throwable there is an event for that.
            // so that I don't have to reset the renderer every frame?

        }

        
    }
}
