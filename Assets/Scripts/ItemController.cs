using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class ItemController : MonoBehaviour {

public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
	public Camera mainCamera;
	public Camera renderCamera; 
	public GameObject itemToControl;
	public float rotationSpeed;
	private Vector2 screenSize;
	private Vector2 screenCenter;
	private bool rotating = true;
	private Vector3 rotationType = new Vector3(0,1,0);
	Vector3 mousePressedPosition = new Vector3();
	float xDist = 0;
	float yDist = 0;
	void Start () {
		screenSize = new Vector2(Screen.width,Screen.height);
		screenCenter = new Vector2(screenSize.x/2, screenSize.y/2);
		        //Fetch the Raycaster from the GameObject (the Canvas)
        //m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		//setting up basic rotation based on clicks.
		if(Input.GetMouseButton(0)){
			if(Input.mousePosition.x < mousePressedPosition.x){
				xDist = (mousePressedPosition.x - Input.mousePosition.x)/screenSize.x;
				itemToControl.transform.Rotate(0,rotationSpeed * xDist, 0);
			}else{
				xDist =  -(Input.mousePosition.x-mousePressedPosition.x)/screenSize.x;
				itemToControl.transform.Rotate(0,rotationSpeed * xDist, 0);
			}
			if(Input.mousePosition.y < mousePressedPosition.y){
				yDist = -(mousePressedPosition.y - Input.mousePosition.y)/screenSize.y;
				itemToControl.transform.Rotate(rotationSpeed * yDist,0, 0);
			}else{
				yDist =  (Input.mousePosition.y-mousePressedPosition.y)/screenSize.y;
				itemToControl.transform.Rotate(rotationSpeed * yDist,0, 0);
			}
		}
		if(Input.GetMouseButtonDown(0)){
			rotating = false;
			mousePressedPosition = Input.mousePosition;
			//raycast to try to see if we are touching a touchpoint
			// RaycastHit hit;
			// Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			//   Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
			// if (Physics.Raycast(ray, out hit)) {
			// 	Debug.Log(hit.transform.gameObject.tag);
				
			// 	// Do something with the object that was hit by the raycast.
			// }
			m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            // foreach (RaycastResult result in results)
            // {
			// 	if(result.gameObject.tag == "RenderTexture"){
			// 		Debug.Log("Hit " + result.gameObject.name);
			// 		RaycastHit hit;
					
			// 		Ray ray = renderCamera.ViewportPointToRay();
			// 		if (Physics.Raycast(ray, out hit)) {
			// 			Debug.Log(hit.transform.gameObject.tag);
						
			// 			// Do something with the object that was hit by the raycast.
			// 		}
			// 	}
                
            // }
			// if(Input.mousePosition.x < screenCenter.x){
			// 	//rotate left;
			// 	Debug.Log("rotate left");
			// 	rotationType.x = 1;
				
			// }else{
			// 	//rotate right
			// 	rotationType.x = -1;
			// }
			// if(Input.mousePosition.y < screenCenter.y){
			// 	//rotate down
			// 	rotationType.y = 1;
			// }else{
			// 	//rotate up
			// 	rotationType.y = -1;
			// }
		}
		if(Input.GetMouseButtonDown(1)){
			//cancel rotation
			rotating = true;
			rotationType = new Vector3(0,1,0);
		}
		if(rotating){
			Debug.Log (rotationType * (Time.deltaTime*10));
			//itemToControl.transform.Rotate(rotationType);
		}
	}
}
