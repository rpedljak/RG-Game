using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotKretanje : MonoBehaviour {

	float speed=1.5f;
	float rotSpeed=150;
	float rot=0f;
	float gravitacija=8;

	public GameObject cam1;
	public GameObject cam2;

	AudioListener cam1AL;
	AudioListener cam2AL;

	int sceneIndex;

	Vector3 moveDir=Vector3.zero;
	CharacterController controller;
	Animator anim;

	void Start() {
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();

		cam1AL=cam1.GetComponent<AudioListener>();
		cam2AL=cam2.GetComponent<AudioListener>();
		
		cameraPositionChange(0);
	}

	void Update() {
		if(Input.GetKey(KeyCode.W)) {
			anim.SetInteger("condition", 1);
			moveDir=new Vector3(0,0,1);
			moveDir*=speed;
			moveDir=transform.TransformDirection(moveDir);
		}
		if(Input.GetKeyUp(KeyCode.W)) {
			anim.SetInteger("condition", 0);
			moveDir=new Vector3(0,0,0);
		}
		if(Input.GetKey(KeyCode.S)) {
			anim.SetInteger("condition", 2);
			moveDir=new Vector3(0,0,-1);
			moveDir*=speed;
			moveDir=transform.TransformDirection(moveDir);
		}
		if(Input.GetKeyUp(KeyCode.S)) {
			anim.SetInteger("condition", 0);
			moveDir=new Vector3(0,0,0);
		}

		if(Input.GetKey(KeyCode.B)) {
			anim.SetInteger("condition", 3);
			moveDir=new Vector3(0,0,0);
		}
		if(Input.GetKeyUp(KeyCode.B)) {
			anim.SetInteger("condition", 0);
		}
		if(Input.GetKeyDown(KeyCode.M)) {
			switchCamera();
		}

		rot+=Input.GetAxis("Horizontal")*rotSpeed*Time.deltaTime;
		transform.eulerAngles=new Vector3(0,rot,0);

		moveDir.y -= gravitacija*Time.deltaTime;
		controller.Move(moveDir*Time.deltaTime);
	}

	void switchCamera() {
		cameraChangeCounter();
	}

	void cameraChangeCounter() {
		int cameraPositionCounter=PlayerPrefs.GetInt("CamPosition");
		cameraPositionCounter++;
		cameraPositionChange(cameraPositionCounter);
	}

	void cameraPositionChange(int camPosition) {
		if(camPosition>1) camPosition=0;

		PlayerPrefs.SetInt("CamPosition", camPosition);

		if(camPosition==0) {
			cam1.SetActive(true);
			cam1AL.enabled=true;

			cam2.SetActive(false);
			cam2AL.enabled=false;
		}
		else {
			cam2.SetActive(true);
			cam2AL.enabled=true;

			cam1.SetActive(false);
			cam1AL.enabled=false;
		}
	}
}
