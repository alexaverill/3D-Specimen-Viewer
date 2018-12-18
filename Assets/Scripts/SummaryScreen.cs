using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SummaryScreen : MonoBehaviour {
	public Button addNewSpecimenButton;
	public CanvasGroup thisCanvasGroup;
	// Use this for initialization
	public event Action newSpecimenClicked;
	void Start () {
		addNewSpecimenButton.onClick.AddListener(()=>newSpecimenClicked.Invoke());
		//hideWindow();
		//load in all current specimens 
	}
	public void showWindow()
	{
		thisCanvasGroup.alpha = 1f;
		thisCanvasGroup.blocksRaycasts = true;
	}
	public void hideWindow(){
		thisCanvasGroup.alpha = 0f;
		thisCanvasGroup.blocksRaycasts = false;
	}
	private void newSpecimenBtnClicked()
    {
        Debug.Log("Clicked");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
