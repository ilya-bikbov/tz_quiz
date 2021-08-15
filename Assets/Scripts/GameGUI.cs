using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour
{
    private Text targetTextField;
    private GameObject restartButton;
    private Button restartButtonComp;
    private Text restartButtonText;
    public void setTargetText(string txt)
    {
        targetTextField.text = txt;
    }
    public void activeRestartButton(bool state)
    {
        restartButton.SetActive(state);

    }
    void Awake() 
    {
        targetTextField = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        restartButton = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        restartButtonComp = this.gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Button>();
        restartButtonText = restartButton.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        restartButtonText.text = "Restart";

        restartButtonComp.onClick.AddListener(restartOnClick);
    }

    void Start()
    {
    }

    void Update()
    {
    }

    void restartOnClick(){
        Application.LoadLevel(Application.loadedLevel);
	}
}
