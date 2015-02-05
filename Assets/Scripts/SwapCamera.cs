using UnityEngine;
using System.Collections;

public class SwapCamera : MonoBehaviour {
	
	public GameObject[] cams;
	private int camIndex = 0;
	private bool wasPressed = false;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < cams.Length; i++){
			cams[i].SetActive(false);	
			cams[i].tag = "";
		}
		cams[camIndex].SetActive(true);
		cams[camIndex].tag = "MainCamera";
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("SwapCamera") > 0) wasPressed = true;
		else if(wasPressed){
			Swap();
			wasPressed = false;
		}
	}
	
	void Swap(){
		cams[camIndex].SetActive(false);
		cams[camIndex].tag = "";
		camIndex ++;
		if(camIndex >= cams.Length) camIndex = 0;
		cams[camIndex].SetActive(true);
		cams[camIndex].tag = "MainCamera";
	}
}
