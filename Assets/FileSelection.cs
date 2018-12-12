using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SFB;
using System;

public class FileSelection : MonoBehaviour {
	public Button selectBtn;
	public TMP_InputField filePathDisplay;
	
	public event Action<string> pathSelected;
	void Start () {
		selectBtn.onClick.AddListener(selectBtnClicked);
	}

    private void selectBtnClicked()
    {
        var path = StandaloneFileBrowser.OpenFilePanel("Select Model","","",false);
		Debug.Log(path[0]);
		pathSelected.Invoke(path[0]);
    }
}
