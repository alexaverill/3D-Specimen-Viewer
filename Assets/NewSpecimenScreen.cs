﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class NewSpecimenScreen : MonoBehaviour {
	
	public event Action<SpecimenClass> specimenEditingFinished;

	private string title;
	private string desc;

	public TMP_InputField titleInput;
	public TMP_InputField descriptionInput;

	public Button continueBtn;
	public CanvasGroup thisCanvasGroup;
	public CanvasGroup panelCG;
	public float animationRate = 1f;
	public FileSelection fileInput;
	
	public InputControllerScript inputController;
	public GameObject touchMarkPrefab;
	public GameObject ModelHolder; 
	[Header("----- Specimen Specific ----- ")]
	public List<TouchData> touchPoints = new List<TouchData>();
	public SpecimenClass specimen = new SpecimenClass();
	[Header("-----UI Elements -----")]
	public TouchPointDataEntry touchDataEntryWindow;
	public Button saveSpecimentBtn;
	public bool inEditWindow = true;
	void Start () {
		hideWindow();

		saveSpecimentBtn.onClick.AddListener(saveBtnClicked);
		inputController.objClicked += editTouchPoint;

		touchDataEntryWindow.editingFinished += touchEditWindowReturned;
		touchDataEntryWindow.editingCanceled += touchEditWindowCanceled;

		continueBtn.onClick.AddListener(continueClicked);
		titleInput.onEndEdit.AddListener(titleEdited);
		descriptionInput.onEndEdit.AddListener(descEdited);
		fileInput.pathSelected += handleFileSelected;
		fileInput.randomAction += ()=> Debug.Log("Random Action");
		inputController.setRotatable(true);
	}

    private void saveBtnClicked()
    {
        specimenEditingFinished.Invoke(specimen);
    }

    private void handleFileSelected(string obj)
    {
		specimen.filePath = obj;
       inputController.setModel(obj);
    }

    private void descEdited(string desc)
    {
        specimen.description = desc;
    }

    private void titleEdited(string titleIn)
    {
		specimen.name = titleIn;
    }

    private void continueClicked()
    {
       //editingFinished.Invoke(title,desc);
	   //hide window; 
	   inputController.setRotatable(true);
	   hideWindow();
    }

    public void showWindow(){
		Sequence inSequence = DOTween.Sequence();
		inSequence.Append(thisCanvasGroup.DOFade(1.0f,animationRate));
		inSequence.Append(panelCG.transform.DOMoveX(400, animationRate));
		inSequence.Play();
		thisCanvasGroup.blocksRaycasts = true;
		//add in swipe in animation
	}
	public void hideWindow(){
		Sequence outSequence = DOTween.Sequence();
		outSequence.Append(panelCG.transform.DOMoveX(-700, animationRate));
		outSequence.Append(thisCanvasGroup.DOFade(0.0f,animationRate));
		thisCanvasGroup.blocksRaycasts = false;
		//add in swipe out animation
	}
	private void touchEditWindowCanceled()
    {
        inEditWindow = false;
		inputController.setRotatable(true);
    }

    private void touchEditWindowReturned(TouchData obj)
    {
		touchPoints.Add(obj);
		specimen.touchPointData = touchPoints;
        inEditWindow = false;
		inputController.setRotatable(true);
    }
	private void editTouchPoint(Vector3 position,GameObject inObj){
		inputController.setRotatable(false);
		GameObject tmpGameObject = Instantiate(touchMarkPrefab,inObj.transform,true);
		tmpGameObject.transform.localPosition = position;
		tmpGameObject.transform.localRotation = inObj.transform.localRotation;
		touchDataEntryWindow.showWindow(position);
	}
}
