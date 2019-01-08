using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerScript : MonoBehaviour {

	public event Action<Vector3,GameObject> objClicked;
	public GameObject rotatingObject;
	// Use this for initialization
	public bool isRotatable = true;
	public Camera mainCamera;
	public float rotationSpeed = 10;
	private Vector2 screenSize;
	private Vector2 screenCenter;
	private bool rotating = true;
	private Vector3 rotationType = new Vector3(0,1,0);
	Vector3 mousePressedPosition = new Vector3();
	Vector2 mousePositionDelta = new  Vector2(0,0);
	float xDist = 0;
	float yDist = 0;
	void Start () {
		screenSize = new Vector2(Screen.width,Screen.height);
		screenCenter = new Vector2(screenSize.x/2, screenSize.y/2);
		//createMeshFromFile
		rotatingObject = new GameObject("Rotating Object");

	}
	public void setModel(string path){
		setRotatable(false);
		Mesh rotatingMesh = FastObjImporter.Instance.ImportFile(path);//Application.dataPath + "/StreamingAssets/test.obj");
		MeshFilter mf = rotatingObject.AddComponent<MeshFilter>();
		mf.mesh = rotatingMesh;
		Material mat = new Material(Shader.Find("Standard"));
		MeshRenderer mr = rotatingObject.AddComponent<MeshRenderer>();
		mr.material = mat;
		rotatingObject.AddComponent<MeshCollider>();
		rotatingObject.transform.position = new Vector3(0,0,0);
		rotatingObject.tag = "Specimen";
		
	}
	public void setRotatable(bool val){
		isRotatable = val;
	}
	void Update () {
		if(rotatingObject == null || !isRotatable){
			return;
		}

		if(Input.GetMouseButton(0)){
			mainCamera.transform.LookAt(rotatingObject.transform);
    		//mainCamera.transform.Translate(Vector3.right * Time.deltaTime);
			Vector3 rotationVector = new Vector3();
			Vector2 currDiff = new Vector2(0,0);
			currDiff.x = Input.mousePosition.x-mousePressedPosition.x;
			currDiff.y = Input.mousePosition.y-mousePressedPosition.y;
			if(currDiff.x > mousePositionDelta.x){
				rotationVector += Vector3.up;
			}
			if(currDiff.x< mousePositionDelta.x ){
				rotationVector += Vector3.down;
			}
			if(currDiff.y > mousePositionDelta.y){
				rotationVector += Vector3.left;
			}
			if(currDiff.y < mousePositionDelta.y){
				rotationVector += Vector3.right;
			}
			mousePositionDelta = currDiff;
			// if(Input.mousePosition.x > mousePressedPosition.x){
			// 	rotationVector += Vector3.left;
			// 	//rotationVector = rotationVector * Vector3.right;
			// 	//mainCamera.transform.Translate(Vector3.right * Time.deltaTime * rotationSpeed);
			// 	// xDist = (mousePressedPosition.x - Input.mousePosition.x)/screenSize.x;
			// 	// mainCamera.transform.Rotate(0,rotationSpeed * xDist, 0);
			// }else{
			// 	rotationVector += Vector3.right;
			// 	//mainCamera.transform.Translate(Vector3.left * Time.deltaTime* rotationSpeed);
			// 	// xDist =  -(Input.mousePosition.x-mousePressedPosition.x)/screenSize.x;
			// 	// mainCamera.transform.Rotate(0,rotationSpeed * xDist, 0);
			// }
			// if(Input.mousePosition.y < mousePressedPosition.y){
			// 	rotationVector += Vector3.down;
			// 	//mainCamera.transform.Translate(Vector3.down * Time.deltaTime* rotationSpeed);
			// 	// yDist = -(mousePressedPosition.y - Input.mousePosition.y)/screenSize.y;
			// 	// mainCamera.transform.Rotate(rotationSpeed * yDist,0, 0);
			// }else{
			// 	rotationVector += Vector3.up;
			// 	//mainCamera.transform.Translate(Vector3.up * Time.deltaTime* rotationSpeed);
			// 	// yDist =  (Input.mousePosition.y-mousePressedPosition.y)/screenSize.y;
			// 	// mainCamera.transform.Rotate(rotationSpeed * yDist,0, 0);
			// }
			mainCamera.transform.RotateAround(rotatingObject.transform.position,rotationVector, rotationSpeed * Time.deltaTime);
		}
		if(Input.GetMouseButtonDown(1)){
			rotating = false;
			mousePressedPosition = Input.mousePosition;
			RaycastHit hit;
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			  Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log(hit.transform.gameObject.tag);
				if(hit.transform.gameObject.tag == "Specimen"){
					Debug.Log(hit.point);
					//load new touchpoint and then open editor
					Debug.Log("Add New TouchPoint");
					objClicked.Invoke(hit.point,rotatingObject);
					
				}
			}
		}
	}
}
