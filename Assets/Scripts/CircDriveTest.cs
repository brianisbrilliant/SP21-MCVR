using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CircDriveTest : MonoBehaviour
{
    [SerializeField]
    LinearMapping map;

    [SerializeField]
    bool bicyclist = true;

    [SerializeField]
    Animator anim;


    // Update is called once per frame
    void Update()
    {
        if(!bicyclist) this.transform.Rotate(map.value * 1080 * Time.deltaTime, 0, 0);
        else {
            anim.speed = map.value * 4;
        }
        // if the value of the map changes - change the speed of the animator.
        
    }
}
