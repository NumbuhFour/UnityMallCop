using UnityEngine;
using System.Collections;

public class SpawnPeople : MonoBehaviour {

	public GameObject spawn;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp("s")){
			GameObject spawned = (GameObject)GameObject.Instantiate(spawn,spawnPoint.position,spawnPoint.rotation);
			spawned.AddComponent<BasicAI>();
		}
	}
}
