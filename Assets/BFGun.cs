using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class BFGun : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "InteractUI");
    public Transform bulletSpawn;

    private Interactable interactable;
    private SteamVR_Input_Sources hand;
    private bool canShoot = true;
    private bool fire = false;


    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable.attachedToHand) {
            hand = interactable.attachedToHand.handType;

            if(fireAction[hand].stateDown) fire = true;
            if(fireAction[hand].stateUp) fire = false;

            if(fire && canShoot) {
                Fire();
            }
        } else {
            fire = false;
        }
    }

    void Fire() {
        Debug.Log("Pow!");
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.position = bulletSpawn.transform.position;
        bullet.transform.rotation = bulletSpawn.transform.rotation;
        bullet.transform.localScale = Vector3.one * 0.1f;
        // bullet.transform.Translate(Vector3.forward, Space.Self);
        Rigidbody rb = bullet.AddComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.AddRelativeForce(Vector3.forward * 30, ForceMode.Impulse);
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        canShoot = false;
        yield return new WaitForSeconds(0.1f);
        canShoot = true;
    }
}
