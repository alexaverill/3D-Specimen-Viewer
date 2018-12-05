using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour {

	public Camera mainCamera;
	public float rotationSpeed = 10;
	private Vector2 screenSize;
	private Vector2 screenCenter;
	private bool rotating = true;
	private Vector3 rotationType = new Vector3(0,1,0);
	Vector3 mousePressedPosition = new Vector3();
	float xDist = 0;
	float yDist = 0;

	public GameObject touchPrefab;
	List<GameObject> touchPointObjects = new List<GameObject>();
	void Start () {
		screenSize = new Vector2(Screen.width,Screen.height);
		screenCenter = new Vector2(screenSize.x/2, screenSize.y/2);
		//load in touch points and tie them into the UI
		//right now load in random touch points.
		Vector3 pos = new Vector3(-4.1f, 6.06f, -.42f);
		GameObject tmp = Instantiate(touchPrefab,transform);
		tmp.transform.localPosition = pos;
		touchPointObjects.Add(tmp);

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButton(0)){
			if(Input.mousePosition.x < mousePressedPosition.x){
				xDist = (mousePressedPosition.x - Input.mousePosition.x)/screenSize.x;
				transform.Rotate(0,rotationSpeed * xDist, 0);
			}else{
				xDist =  -(Input.mousePosition.x-mousePressedPosition.x)/screenSize.x;
				transform.Rotate(0,rotationSpeed * xDist, 0);
			}
			if(Input.mousePosition.y < mousePressedPosition.y){
				yDist = -(mousePressedPosition.y - Input.mousePosition.y)/screenSize.y;
				transform.Rotate(rotationSpeed * yDist,0, 0);
			}else{
				yDist =  (Input.mousePosition.y-mousePressedPosition.y)/screenSize.y;
				transform.Rotate(rotationSpeed * yDist,0, 0);
			}
		}
		if(Input.GetMouseButtonDown(0)){
			rotating = false;
			mousePressedPosition = Input.mousePosition;
								RaycastHit hit;
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			  Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log(hit.transform.gameObject.tag);
				
				// Do something with the object that was hit by the raycast.
			}
		}
	}
}
