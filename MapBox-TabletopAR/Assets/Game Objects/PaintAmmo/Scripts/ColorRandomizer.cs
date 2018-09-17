using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour {
    [SerializeField]
    private Color[] colors = new Color[] {
        new Color(255.0f/255.0f, 31.0f/255.0f, 63.0f/255.0f, 1),
        new Color(17.0f/255.0f, 255.0f/255.0f, 10.0f/255.0f, 1),
        new Color(0.0f/255.0f, 127.0f/255.0f, 255.0f/255.0f, 1),
        new Color(255.0f/255.0f, 115.0f/255.0f, 0.0f/255.0f, 1),
        new Color(220.0f/255.0f, 0.0f/255.0f, 244.0f/255.0f, 1),
        Color.black
    };


	// Use this for initialization
	void Start () {
        UpdateColor();
	}
	
    private void UpdateColor() {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.shader = Shader.Find("_Color");
        Color randomColor = colors[Random.Range(0, colors.Length)];
        renderer.material.SetColor("_Color", randomColor);
        renderer.material.shader = Shader.Find("Specular");
        renderer.material.SetColor("_SpecColor", randomColor);
    }
}
