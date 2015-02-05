using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	private int entrants = 0;
	private Animator anim;
	
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	void OnTriggerEnter(Collider c){
		entrants++;
		if(entrants == 1){
			anim.SetBool("Open", true);
		}
	}
	
	void OnTriggerExit(Collider c){
		entrants--;
		if(entrants == 0){
			anim.SetBool("Open", false);
		}
	}
}
