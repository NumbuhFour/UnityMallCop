using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	protected NavMeshAgent agent;
	private Choice currentChoice;

	protected Choice CurrentChoice{
		get { return currentChoice; }
	}
	
	protected void RemoveChoice(){
		Destroy(currentChoice);
		currentChoice = null;
	}
	
	protected void SetChoice<T>() where T : Choice{
		if(currentChoice) Destroy (currentChoice);
		currentChoice = gameObject.AddComponent<T>();
	}

	// Use this for initialization
	public virtual void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
