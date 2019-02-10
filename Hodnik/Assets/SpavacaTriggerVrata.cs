using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpavacaTriggerVrata : MonoBehaviour {

	public Text text;

	void Start() {
		text.transform.position=new Vector3(Screen.width/2,Screen.height/2,0);
	}

	void OnTriggerEnter(Collider other) {
		text.text="Pritisnite F da uđete u spavaću sobu";
	}

	void OnTriggerStay(Collider other) {
		if(Input.GetKeyDown(KeyCode.F)) {
			//mijenjaj scenu
			Debug.Log("nova scena");
		}
	}

	void OnTriggerExit(Collider other) {
		text.text="";
	}
}