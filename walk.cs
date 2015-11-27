using UnityEngine;
using System.Collections;

public class walk : MonoBehaviour {
	private GameObject[] players;
	private int speed = 2;
	void Start(){
		players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i=0; i<players.Length;i++){
			players[i].SetActive(false);
		}
		transform.Find ("p2_walk").gameObject.SetActive (true);
	}

	void OnEnable (){
		EasyJoystick.On_JoystickMove += OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
	}
	
	void OnDisable(){
		EasyJoystick.On_JoystickMove -= OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
	}

	
	
	//移动摇杆结束  
	void OnJoystickMoveEnd(MovingJoystick move)  
	{  
		if (move.joystickName != "WalkJoystick"){
			return;
		}
		transform.Find("p1_walk").gameObject.GetComponent<Animator> ().SetBool ("Walk", false);
		transform.Find("p2_walk").gameObject.GetComponent<Animator> ().SetBool ("Walk", false);
	}  
	
	
	//移动摇杆中  
	void OnJoystickMove(MovingJoystick move)  
	{ 
		if (move.joystickName != "WalkJoystick"){
			return;
		}
		float joyPositionX = move.joystickAxis.x;
		float joyPositionY = move.joystickAxis.y;
		//Debug.Log (joyPositionX);
		if (joyPositionX != 0 || joyPositionY != 0)	{
			transform.Find("p1_walk").Translate (-joyPositionX * Time.deltaTime * speed, joyPositionY * Time.deltaTime * speed, 0);
			transform.Find("p2_walk").Translate (joyPositionX * Time.deltaTime * speed, joyPositionY * Time.deltaTime * speed, 0);
		}
		transform.Find("p1_walk").gameObject.GetComponent<Animator> ().SetBool ("Walk", true);
		transform.Find("p2_walk").gameObject.GetComponent<Animator> ().SetBool ("Walk", true);

	} 
	void Update(){

	}
}
