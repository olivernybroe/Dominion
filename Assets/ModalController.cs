using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ModalController : MonoBehaviour
{
	public string Title;

	public string ButtonFooterTitle;

	public string InputPlaceholder;
	
	public string InputText;
	
	public Button.ButtonClickedEvent OnClick = new Button.ButtonClickedEvent();

	public Button FooterButton;

	public InputField BodyInput;

	public Text BodyText;

	public Text HeaderText;

	// Use this for initialization
	void Start ()
	{
		HeaderText.text = Title;
		FooterButton.onClick = OnClick;
		BodyInput.placeholder.GetComponent<Text>().text = InputPlaceholder;
		BodyText.text = InputText;
		FooterButton.GetComponentInChildren<Text>().text = ButtonFooterTitle;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
