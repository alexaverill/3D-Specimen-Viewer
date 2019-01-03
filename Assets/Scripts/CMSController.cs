using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CMSController : MonoBehaviour {
	 /// <summary>
	 /// This class will control  which screen is visible, as well as reading and writing to the JSON data file
	 ///</summary>
	// Use this for initialization
	List<SpecimenClass> specimenList;// = new List<SpecimenClass>();
	[Header("----- UI Screens -----")]
	public SummaryScreen summary;
	public NewSpecimenScreen newSpecimen;
	void Awake () {
		specimenList = JSON.readSpecimens();
		//Debug.Log(specimenList[0]);
		summary.newSpecimenClicked += handleNewButtonClicked;
		newSpecimen.specimenEditingFinished += handleEditingFinished;
		//reset();
		summary.showWindow();
	}

    private void handleEditingFinished(SpecimenClass specimen)
    {
		specimenList.Add(specimen);
        JSON.writeSpecimen(specimenList);
    }

    private void handleNewButtonClicked()
    {
        summary.hideWindow();
		newSpecimen.showWindow();
    }

    private void reset(){
		newSpecimen.hideWindow();
		summary.hideWindow();
	}
    // private void saveButtonClicked()
    // {
	// 	specimen.touchPointData = touchPoints;
    //     JSON.writeSpecimen(specimen);
    // }



    // Update is called once per frame
    // void Update () {
	// 	if(inEditWindow){
	// 		return;
	// 	}

	// }

}
