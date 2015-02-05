using UnityEngine;
using System.Collections;

public class BrowseStore : Choice {

	// Use this for initialization
	public override void Start () {
		base.Start();
		agent.SetDestination(PickBrowsePoint());
	}
	
	// Update is called once per frame
	void Update () {
		if(this.ReachedDestination){
			this.done = true;
		}
	}
	
	Vector3 PickBrowsePoint(){
		GameObject[] areas = GameObject.FindGameObjectsWithTag("ShelfHitspot");
		GameObject choice = areas[Random.Range(0,areas.Length)];
		Vector3 pos = choice.transform.position;
		BoxCollider coll = choice.GetComponent<BoxCollider>();
		Vector3 min = pos + coll.center - coll.size/2;
		Vector3 max = pos + coll.center + coll.size/2;
		Vector3 point = new Vector3(Random.Range(min.x, max.x),
		                            Random.Range(min.y, max.y),
		                            Random.Range(min.z, max.z));
    	return point;
	}
}
