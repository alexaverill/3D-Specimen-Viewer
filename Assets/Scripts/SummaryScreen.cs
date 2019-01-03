using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SummaryScreen : MonoBehaviour {
	public Button addNewSpecimenButton;
	public CanvasGroup thisCanvasGroup;
	public CanvasGroup titleArea;
	public CanvasGroup specimenListArea;

	public float animationDuration = 1f;
	// Use this for initialization
	public event Action newSpecimenClicked;
	void Start () {
		addNewSpecimenButton.onClick.AddListener(newClicked);//()=>newSpecimenClicked.Invoke());
		//hideWindow();
		//load in all current specimens 
	}

    private void newClicked()
    {
		
        newSpecimenClicked.Invoke();
    }

    public void showWindow()
	{
		Sequence inSequence = DOTween.Sequence();
		inSequence.Append(titleArea.transform.DOMoveX(0,animationDuration));
		inSequence.Join(thisCanvasGroup.DOFade(1.0f,animationDuration));
		inSequence.Play();
		
		thisCanvasGroup.blocksRaycasts = true;
	}
	public void hideWindow(){
		
		Sequence outSequence = DOTween.Sequence();
		outSequence.Append(titleArea.transform.DOMoveX(-650,animationDuration));
		outSequence.Join(thisCanvasGroup.DOFade(0.0f,animationDuration/2));
		outSequence.Play();
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
