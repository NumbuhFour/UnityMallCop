using UnityEngine;
using System.Collections;

public class RenderWeird : MonoBehaviour {

	public Shader shader;

	// Use this for initialization
	void Start () {
		this.camera.SetReplacementShader(shader, "");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
