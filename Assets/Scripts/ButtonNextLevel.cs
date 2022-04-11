using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class ButtonNextLevel : MonoBehaviour
{
    [SerializeField]
    HoverButton button;

    [Tooltip("The Build Index of the scene that you would like to load.")]
    [SerializeField]
    int levelIndex = 0;

    void Start()
    {
        Debug.Log("Listening...");
        button.onButtonDown.AddListener(OnButtonDown);
    }

    void OnButtonDown(Hand fromHand)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
