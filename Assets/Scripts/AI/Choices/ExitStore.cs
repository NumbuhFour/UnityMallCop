using UnityEngine;
using System.Collections;

public class ExitStore : Choice {

	// Use this for initialization
	public override void Start () {
		base.Start();
		GameObject entr = GameObject.FindGameObjectWithTag("Entrance");	
		Vector3 pos = entr.transform.position;
		BoxCollider coll = entr.GetComponent<BoxCollider>();
		Vector3 min = pos + coll.center - coll.size/2;
		Vector3 max = pos + coll.center + coll.size/2;
		Vector3 point = new Vector3(Random.Range(min.x, max.x),
		                            Random.Range(min.y, max.y),
		                            Random.Range(min.z, max.z));
		agent.SetDestination(point);
	}
	
	// Update is called once per frame
	void Update () {
		if(this.ReachedDestination){
			this.done = true;
		}
	}
}
