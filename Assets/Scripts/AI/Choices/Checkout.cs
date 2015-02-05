using UnityEngine;
using System.Collections;

public class Checkout : Choice {

	public int avoid;

	// Use this for initialization
	public override void Start () {
		base.Start();
		avoid = agent.avoidancePriority = Random.Range(0, 100);
		
		GameObject area = GameObject.FindGameObjectWithTag("CheckoutCounter");
		Vector3 pos = area.transform.position;
		BoxCollider coll = area.GetComponent<BoxCollider>();
		Vector3 min = pos + coll.center - coll.size/2;
		Vector3 max = pos + coll.center + coll.size/2;
		Vector3 point = new Vector3(Random.Range(min.x, max.x),
		                            Random.Range(min.y, max.y),
		                            Random.Range(min.z, max.z));
		
		agent.SetDestination(point);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
