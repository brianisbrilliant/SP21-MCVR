using UnityEngine;
using Valve.VR.InteractionSystem;       // for using Hand for rumble

public class ButtonTest : MonoBehaviour
{
    [SerializeField]
    private Transform cubeSpawn;

    public void OnButtonDown() {
        Debug.Log("The button has been pressed!");
        BuildCube();
        // fromHand.TriggerHapticPulse(1000);
    }

    public void OnButtonUp() {
        Debug.Log("The Button has been let go.");
    }

    private void BuildCube() {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = Vector3.one * 0.5f;
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
