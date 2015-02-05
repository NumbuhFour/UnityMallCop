using UnityEngine;
using System.Collections;

public class MouseSelect : MonoBehaviour {
	
	public string selectionLayerName;
	private int selectionLayer;
	public LayerMask detectLayer;

	// Use this for initialization
	void Start () {
		selectionLayer = LayerMask.NameToLayer(selectionLayerName);
	}
	
	private GameObject lastHit = null;
	private int lastLayer = -1;
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetAxisRaw("Point") > 0){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit,100, detectLayer.value)){
			if(lastHit){
					SetLayerRecursively(lastHit, lastLayer);
				}
				lastHit = hit.transform.gameObject;
				lastLayer = lastHit.layer;
				SetLayerRecursively(lastHit, selectionLayer);
				
			}else if(lastHit != null){
				SetLayerRecursively(lastHit, lastLayer);
				lastHit = null;
				lastLayer = -1;
			}
		//}
	}
	
	void SetLayerRecursively(GameObject obj, int newLayer)
	{
		if (null == obj)
		{
			return;
		}
		
		obj.layer = newLayer;
		
		foreach (Transform child in obj.transform)
		{
			if (null == child)
			{
				continue;
			}
			SetLayerRecursively(child.gameObject, newLayer);
		}
	}
}
