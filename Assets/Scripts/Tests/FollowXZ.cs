using UnityEngine;
using System.Collections;

public class FollowXZ : MonoBehaviour {

	public Transform follow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(follow.position.x, this.transform.position.y, follow.position.z);
	}
}
