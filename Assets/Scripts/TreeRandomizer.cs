using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // randomize rotation on vertical axis
        this.transform.Rotate(0,Random.Range(-180f,180f),0);
        // randomize value of current color.
        Renderer rend = this.GetComponent<Renderer>();
        float h, s, v;

        Color.RGBToHSV(rend.material.color, out h, out s, out v);
        Color newColor = Color.HSVToRGB(h, s, Random.Range(0.4f,0.9f));
        rend.material.color = newColor;

    }
}
