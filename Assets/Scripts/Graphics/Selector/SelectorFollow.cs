using UnityEngine;
using System.Collections;

public class SelectorFollow : MonoBehaviour {

	private Transform followed;
	public Vector3 offset = new Vector3(0.8f,1.5f,0.0f);
	
	public RectTransform rect;
	
	private Vector2 dims;
	private Vector2 position;
	
	private Vector2 midPos2;
	private Vector2 topPos2;
	private Vector2 rightPos2;
	// Use this for initialization
	void Start () {
		//followed = this.GetComponent<Transform>();
		//rect = this.GetComponent<RectTransform>();
		dims = rect.offsetMax - rect.offsetMin;
	}
	
	// Update is called once per frame
	public void Update () { //Unity does not seem to have a concise way of going from World to UI space
		if(followed == null) followed = this.GetComponent<Transform>();
		if(followed.gameObject == null || followed.gameObject.layer != LayerMask.NameToLayer("Selection")) {
			Destroy(rect.gameObject);
			Destroy (this);
		}
		
		Camera cam = Camera.main;
		Vector3 midPos = RectTransformUtility.WorldToScreenPoint(cam,followed.position + new Vector3(0,offset.y,0));
		rect.position = midPos;
		midPos2 = FindCurPos();
		//Debug.Log (rect.TransformPoint(midPos) + " " + midPos2);
		//position = new Vector2(midPos.x, midPos.y);
		
		Vector3 topPos = RectTransformUtility.WorldToScreenPoint(cam,followed.position + new Vector3(0,offset.y*2,0));
		rect.position = topPos;
		topPos2 = FindCurPos();
		float height = topPos2.y - midPos2.y;
		
		Vector3 rightVec = Vector3.Cross(cam.transform.up, cam.transform.forward).normalized;
		Vector3 rightPos = RectTransformUtility.WorldToScreenPoint(cam,followed.position + new Vector3(0,offset.y,0) + offset.x*rightVec);
		rect.position = rightPos;
		rightPos2 = FindCurPos();
		rect.position = midPos;
		float width = rightPos2.x - midPos2.x;
		
		dims.x = width;
		dims.y = height;
		//Debug.Log("Width: " + dims.x + " " + rect.offsetMax + " " +rect.offsetMin);
		//rect.anchoredPosition = position;
		RecalcSize();
	}
	
	//private Vector2 curDim;
	private void RecalcSize(){
		//if(curDim == Vector2.zero) 
		//	curDim = rect.offsetMax-rect.offsetMin;
		Vector2 pos = FindCurPos();//rect.offsetMin + curDim/2;
		
		//Vector2 rad = dims/2;
		//Vector2 minTest = rect.offsetMin;
		//minTest.y = rect.offsetMax.y-curDim.y/4;
		//rect.offsetMin = minTest;
		rect.offsetMax = pos+dims;//+curDim/2;
		rect.offsetMin = pos-dims;//curDim/2;
	}
	
	private Vector2 FindCurPos(){
		Vector2 tempDim = rect.offsetMax-rect.offsetMin;
		Vector2 pos = rect.offsetMin + tempDim/2;
		return pos;
	}
}
