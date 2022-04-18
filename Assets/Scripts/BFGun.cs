using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;
using TMPro;

public class BFGun : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "InteractUI");
    public SteamVR_Action_Boolean reloadAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "teleport");
    public Transform bulletSpawn;

    private Interactable interactable;
    private PlaySound aud;
    private SteamVR_Input_Sources hand;
    private bool canShoot = true;
    private bool fire = false;

    [Header("Gun Stuff")]
    public int clipSize = 12;
    public int totalAmmo = 1000;
    public int currentClip = 1;
    [Range(0.01f, 1)]
    public float fireInterval = .5f;

    [Header("UI Stuff")]
    public TextMeshPro ammoDisplay;
    public TextMeshPro chargeIndicator;
    public Color[] colors;




    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        aud = GetComponent<PlaySound>();
        currentClip = clipSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable.attachedToHand) {
            hand = interactable.attachedToHand.handType;

            if(fireAction[hand].stateDown) fire = true;
            if(fireAction[hand].stateUp) fire = false;

            if(fire && canShoot) {
                TryToFire();
            }

            if(reloadAction[hand].stateDown) Reload();

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
        currentClip -= 1;
        ammoDisplay.text = currentClip.ToString() + " / " + totalAmmo.ToString();
        aud.PlayOneShotSound();
        StartCoroutine(Wait());
    }

    void TryToFire() {
        if(currentClip > 0) {
            Fire();
        } else {
            // play click of empty clip.
        }
    }

    void Reload() {
        if(currentClip >= clipSize) {
            StartCoroutine(Wait());
            return;
            // clip is full
        }

        if(totalAmmo > 0) {
            if(totalAmmo >= clipSize) {
                currentClip = 0;
                currentClip += clipSize;
                totalAmmo -= clipSize;
            } else {
                currentClip += totalAmmo;
                totalAmmo = 0;
            }

            ammoDisplay.text = currentClip.ToString() + " / " + totalAmmo.ToString();
            StartCoroutine(Wait());
        } else  {
            // you have no more ammo
            ammoDisplay.text = "Out of Ammo";
        }

        

    }

    IEnumerator Wait() {
        if(currentClip <= 0) {
            chargeIndicator.text = "Reload!";
            chargeIndicator.color = colors[0];
            yield break;
        }
        
        canShoot = false;
        float timer = 0;
        while(timer < fireInterval) {
            timer += Time.deltaTime;
            int chargeAmount = (int)((timer / fireInterval) * 10);
            chargeIndicator.text = new string ('|', chargeAmount);
            if(chargeAmount > 4) {
                chargeIndicator.color = colors[1];
            } else {
                chargeIndicator.color = colors[0];
            }
            
            yield return null;
        }
        canShoot = true;
        chargeIndicator.text = new string ('|', 10);
        chargeIndicator.color = colors[2];
    }
}