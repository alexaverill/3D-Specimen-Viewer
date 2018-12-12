using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NewSpecimenScreen : MonoBehaviour {
	
	private string title;
	private string desc;

	public TMP_InputField titleInput;
	public TMP_InputField descriptionInput;

	public Button continueBtn;
	public CanvasGroup thisCanvasGroup;
	public FileSelection fileInput;
	public event Action<string> fileSelected;
	public event Action<string,string> editingFinished;
	void Start () {
		hideWindow();
		continueBtn.onClick.AddListener(continueClicked);
		titleInput.onEndEdit.AddListener(titleEdited);
		descriptionInput.onEndEdit.AddListener(descEdited);
		fileInput.pathSelected += (e) => fileSelected.Invoke(e);
	}

    private void descEdited(string arg0)
    {
        desc = arg0;
    }

    private void titleEdited(string arg0)
    {
        title = arg0;
    }

    private void continueClicked()
    {
        editingFinished.Invoke(title,desc);
    }

    public void showWindow(){
		thisCanvasGroup.alpha = 1f;
		thisCanvasGroup.blocksRaycasts = true;
	}
	public void hideWindow(){
		thisCanvasGroup.alpha = 0f;
		thisCanvasGroup.blocksRaycasts = false;
	}

}
