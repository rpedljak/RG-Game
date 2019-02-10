using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class LoginCheck : MonoBehaviour {
	
	public InputField username;
	public Text usernameText;
	public InputField password;
	public List<String> igraciUsername;
	public List<String> igraciPassword;

	void Start() {
		string dirname=Path.GetDirectoryName(Path.GetFullPath("spisak_igraca.csv"))+"\\Assets\\spisak_igraca.csv";
		igraciUsername=File.ReadAllLines(dirname).Skip(1).Select(v => dajUsername(v)).ToList();
		igraciPassword=File.ReadAllLines(dirname).Skip(1).Select(v => dajPassword(v)).ToList();
	}

	void Update() {
		if(Input.GetKey(KeyCode.Return)) {
			checkLogin();
		}
	}

	public void checkLogin() {
		int ima=0;
		for(int i=0; i<igraciUsername.Count; i++) {
			if(igraciUsername[i]==username.text && igraciPassword[i]==password.text) {
				ima=1;
				usernameText.text="";
				SceneManager.LoadScene("Hodnik");
			}
		}
		if(ima==0) usernameText.text="POGREŠAN USERNAME/PASSWORD!";
	}

	public String dajUsername(String csvLine) {
		csvLine.Substring(csvLine.Length-3);
		String[] values=csvLine.Split(';');
		return values[0];
	}

	public String dajPassword(String csvLine) {
		csvLine.Substring(csvLine.Length-3);
		String[] values=csvLine.Split(';');
		return values[1];
	}
}
