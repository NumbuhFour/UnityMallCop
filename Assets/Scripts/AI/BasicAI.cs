using UnityEngine;
using System.Collections;

public class BasicAI : AI {

	/*
	 AI to browse the store intermittently, then checkout and leave.	
	*/

	public int delay = 0;
	
	private enum States {BROWSING,PAYING,LEAVING};
	private States state = States.BROWSING;

	// Use this for initialization
	public override void Start () {
		base.Start();
		this.SetChoice<BrowseStore>();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.CurrentChoice && this.CurrentChoice.IsDone) {
			if(state == States.BROWSING){
				RemoveChoice();
				delay = Random.Range(50,200);
			}else if(state == States.LEAVING){
				Destroy (this.gameObject);
			}
		}
	}
	
	private void DelayEnded(){
		if(state == States.BROWSING){
			if(Random.Range(0,100) < 0){
				state = States.PAYING;
				this.SetChoice<ExitStore>();
			}else {
				this.SetChoice<BrowseStore>();
			}
		}
	}
	
	void FixedUpdate() {
		if(delay > 0){
			delay --;
			if(delay <= 0){
				DelayEnded();
			}
		}
	}
}
