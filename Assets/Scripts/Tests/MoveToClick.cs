using UnityEngine;
using System.Collections;

public class MoveToClick : MonoBehaviour {

	private NavMeshAgent agent;
	
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Point") > 0){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit,100)){
				agent.SetDestination(hit.point);
			}
		}
	}
}
