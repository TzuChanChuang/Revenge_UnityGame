using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {
	public GameObject[] players;

	void OnEnable (){
		EasyJoystick.On_JoystickMove += OnJoystickMove;
	}
	
	void OnDisable(){
		EasyJoystick.On_JoystickMove -= OnJoystickMove;
	}
	
	//移動搖桿時
	void OnJoystickMove(MovingJoystick move){
		if (move.joystickName != "AttackJoystick"){
			return;
		}
		
		//取得搖桿偏移量
		float joyPositionX = move.joystickAxis.x;
		players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i=0; i<players.Length; i++) {
			players [i].SetActive(false);
		}
		if (joyPositionX > 0) {
			transform.Find("p2_walk").gameObject.SetActive(true);

			//player_now.SetActive(true);
		} else {
			transform.Find("p1_walk").gameObject.SetActive(true);
		}
	}
}
