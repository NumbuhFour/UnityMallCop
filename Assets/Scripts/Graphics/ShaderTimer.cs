using UnityEngine;
using System.Collections;

public class ShaderTimer : MonoBehaviour {

	public int delta = 1;
	public float time = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Shader.SetGlobalFloat("_Timer",time);
		time += delta;
	}
}
