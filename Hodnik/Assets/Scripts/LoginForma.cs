using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginForma : MonoBehaviour {

	public InputField username;
	public Text usernameText;
	public InputField password;

	// Use this for initialization
	void Start () {
		password.inputType = InputField.InputType.Password;
		usernameText.text="";
		username.Select();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Tab) && username.isFocused) {
			password.Select();
		}

		if(Input.GetKeyUp(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift) && password.isFocused) {
			username.Select();
		}
	}
}
