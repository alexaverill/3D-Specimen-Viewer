using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TouchPointDataEntry : MonoBehaviour {

	public event Action<TouchData> editingFinished;
	public event Action editingCanceled;
	public TouchData data = new TouchData();
	public TMP_InputField titleInput;
	public TMP_InputField descriptionInput;
	public Button saveButton;
	public Button cancelBtn;
	public CanvasGroup thisCanvasGroup;
	private string title;
	private string content;
	public void showWindow(Vector3 pos){
		resetWindow();
		data.xPos = pos.x; // think of a cleaner way after over your cold
		data.yPos = pos.y;
		data.zPos = pos.z; 
		thisCanvasGroup.alpha = 1f;
		thisCanvasGroup.blocksRaycasts = true;
	}

    private void resetWindow()
    {
        titleInput.text = "";
		descriptionInput.text ="";
		data = new TouchData();
    }

    public void hideWindow(){
		thisCanvasGroup.alpha = 0f;
		thisCanvasGroup.blocksRaycasts = false;
	}
	// Use this for initialization
	void Start () {
		saveButton.onClick.AddListener(saveBtnClicked);
		cancelBtn.onClick.AddListener(cancelBtnClicked);
		titleInput.onEndEdit.AddListener(titleEdited);
		descriptionInput.onEndEdit.AddListener(descEdited);
		thisCanvasGroup = GetComponent<CanvasGroup>();
	}

    private void titleEdited(string arg0)
    {
        data.title = arg0;
    }

    private void descEdited(string arg0)
    {
        data.description = arg0;
    }

    private void saveBtnClicked()
    {
        //fill out data then emit it as signal. 
		editingFinished.Invoke(data);
		hideWindow();
    }

    private void cancelBtnClicked()
    {
        editingCanceled.Invoke();
		hideWindow();
    }
}
