using UnityEngine;
using System.Collections;

public class AttachSelectorOverlay : MonoBehaviour {

	public GameObject selectorPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] patrons = GameObject.FindGameObjectsWithTag("Patron");
		
		foreach(GameObject p in patrons){
			if(p.layer == LayerMask.NameToLayer("Selection") && p.GetComponent<SelectorFollow>() == null){
				AddSelector(p);
			}
		}
	}
	
	private void AddSelector(GameObject target){
		SelectorFollow sel = target.AddComponent<SelectorFollow>();
		
		GameObject selPrefab = (GameObject)Instantiate(selectorPrefab);
		selPrefab.transform.SetParent(this.transform);
		
		sel.rect = selPrefab.GetComponent<RectTransform>();
		
		sel.Update();
	}
}
