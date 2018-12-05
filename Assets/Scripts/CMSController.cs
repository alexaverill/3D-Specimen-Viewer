using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CMSController : MonoBehaviour {
	 /// <summary>
	 /// This class will control user input, allow for addition of points, and bring up the user interface to add data
	 ///</summary>
	// Use this for initialization
	public GameObject touchMarkPrefab;
	public GameObject ModelHolder; 
	public InputControllerScript inputController;
	[Header("----- Specimen Specific ----- ")]
	public List<TouchData> touchPoints = new List<TouchData>();
	public SpecimenClass specimen = new SpecimenClass();
	[Header("-----UI Elements -----")]
	public TouchPointDataEntry touchDataEntryWindow;
	public Button saveSpecimentBtn;
	public bool inEditWindow = false;
	void Start () {

		//Mesh myMesh = FastObjImporter.Instance.ImportFile("/home/alex/Unity/SpecimenViewer/Assets/StreamingAssets/test.obj");
		saveSpecimentBtn.onClick.AddListener(saveButtonClicked);

		inputController.objClicked += editTouchPoint;

		touchDataEntryWindow.editingFinished += touchEditWindowReturned;
		touchDataEntryWindow.editingCanceled += touchEditWindowCanceled;
		touchDataEntryWindow.hideWindow();
	}

    private void saveButtonClicked()
    {
		specimen.name = "Alex Testing";
		specimen.description = "A fun test of skill";
		specimen.touchPointData = touchPoints;
        JSON.writeSpecimen(specimen);
    }

    private void touchEditWindowCanceled()
    {
        inEditWindow = false;
		inputController.setEditMode(false);
    }

    private void touchEditWindowReturned(TouchData obj)
    {
		touchPoints.Add(obj);
        inEditWindow = false;
		inputController.setEditMode(false);
    }

    // Update is called once per frame
    void Update () {
		if(inEditWindow){
			return;
		}

	}
	private void editTouchPoint(Vector3 position,GameObject inObj){
		//inputController.setEditMode(true);
		//inEditWindow = true;
		//position = new Vector3(position.x,position.y, position.z);
		GameObject tmpGameObject = Instantiate(touchMarkPrefab,inObj.transform,true);
		tmpGameObject.transform.localPosition = position;
		tmpGameObject.transform.localRotation = inObj.transform.localRotation;
		//touchDataEntryWindow.showWindow(position);
	}
}
