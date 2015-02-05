using UnityEngine;
using System.Collections;

public class Choice : MonoBehaviour {

	protected NavMeshAgent agent;
	protected bool done = false;

	public bool IsDone { get { return done; } }

	// Use this for initialization
	public virtual void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public bool ReachedDestination{
		get { return agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance==0; }
	}
}
