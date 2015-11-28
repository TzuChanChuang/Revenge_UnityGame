using UnityEngine;
using System.Collections;

public class alien : MonoBehaviour {
	public int blood;
	private GameObject[] players;
	//players
	private GameObject player_right;
	private GameObject player_left;
	private GameObject player_up;
	private GameObject player_down;
	//guns
	private GameObject gun_right;
	private GameObject gun_left;
	private GameObject gun_up;
	private GameObject gun_down;
	//firepoint	
	private int Weapon = 0; 
	public Transform Weapon_bullet;
	public Transform firePoint_right;	
	public Transform firePoint_left;
	public Transform firePoint_up;	
	public Transform firePoint_down;
	private float firetime;

	private float collision_time =3;

	private int speed = 4;
	void Start(){
		blood = 100;
		players = GameObject.FindGameObjectsWithTag ("Alien");
		for (int i=0; i<players.Length;i++){
			players[i].SetActive(false);
		}
		transform.Find ("alien_right").gameObject.SetActive (true);
		player_right = transform.Find ("alien_right").gameObject;
		player_left = transform.Find ("alien_left").gameObject;
		player_up = transform.Find ("alien_Up").gameObject;
		player_down = transform.Find ("alien_Down").gameObject;
		gun_right = player_right.transform.Find ("gunright").gameObject;
		gun_left = player_left.transform.Find ("gunleft").gameObject;
		gun_up = player_up.transform.Find ("gunup").gameObject;
		gun_down = player_down.transform.Find ("gundown").gameObject;

		firetime = 0;
	}
	
	void OnEnable (){
		EasyJoystick.On_JoystickMove += OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
		EasyButton.On_ButtonUp += On_ButtonUp;	
	}
	
	void OnDisable(){
		EasyJoystick.On_JoystickMove -= OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
		EasyButton.On_ButtonUp -= On_ButtonUp;
	}
	
	
	
	//移动摇杆结束  
	void OnJoystickMoveEnd(MovingJoystick move)  
	{  
		if (move.joystickName == "WalkJoystick"){
			player_right.GetComponent<Animator> ().SetBool ("Walk", false);
			player_left.GetComponent<Animator> ().SetBool ("Walk", false);
			player_up.GetComponent<Animator> ().SetBool ("Walk", false);
			player_down.GetComponent<Animator> ().SetBool ("Walk", false);

		}
	}  
	
	
	//移动摇杆中  
	void OnJoystickMove(MovingJoystick move)  
	{ 
		if (move.joystickName == "WalkJoystick"){
			float joyPositionX = move.joystickAxis.x;
			float joyPositionY = move.joystickAxis.y;
			//Debug.Log (joyPositionX);
			if (joyPositionX != 0 || joyPositionY != 0)	{
				transform.Translate (joyPositionX * Time.deltaTime * speed, joyPositionY * Time.deltaTime * speed, 0);	
			}
			player_right.GetComponent<Animator> ().SetBool ("Walk", true);
			player_left.GetComponent<Animator> ().SetBool ("Walk", true);
			player_up.GetComponent<Animator> ().SetBool ("Walk", true);
			player_down.GetComponent<Animator> ().SetBool ("Walk", true);

		}
		if (move.joystickName == "AttackJoystick") {
			float joyPositionX = move.joystickAxis.x;
			float joyPositionY = move.joystickAxis.y;

			if (joyPositionX > 0 && joyPositionY < Mathf.Sqrt(0.5f) && joyPositionY > -Mathf.Sqrt(0.5f) && Mathf.Abs(joyPositionX)>=Mathf.Abs(joyPositionY)) {//turn right
				player_left.SetActive (false);
				player_up.SetActive (false);
				player_down.SetActive (false);
				player_right.SetActive (true);
				if(Weapon==1&& firetime>=0.2f){
					//shoot
					Instantiate(Weapon_bullet, firePoint_right.position,Quaternion.Euler(0f, 0f, -90f));
					firetime = 0;
				}
			} else if(joyPositionX < 0 && joyPositionY < Mathf.Sqrt(0.5f) && joyPositionY > -Mathf.Sqrt(0.5f)&& Mathf.Abs(joyPositionX)>=Mathf.Abs(joyPositionY)) {//turn left
				player_right.SetActive (false);
				player_up.SetActive (false);
				player_down.SetActive (false);
				player_left.SetActive (true);
				if(Weapon==1&& firetime>=0.2f){
					//shoot
					Instantiate(Weapon_bullet, firePoint_left.position,Quaternion.Euler(0f, 0f, 90f));
					firetime = 0;
				}
			}else if(joyPositionY > 0 && joyPositionX < Mathf.Sqrt(0.5f) && joyPositionX > -Mathf.Sqrt(0.5f)) {//turn up
				player_right.SetActive (false);
				player_up.SetActive (true);
				player_down.SetActive (false);
				player_left.SetActive (false);
				if(Weapon==1&& firetime>=0.2f){
					//shoot
					Instantiate(Weapon_bullet, firePoint_up.position,Quaternion.Euler(0f, 0f, 0f));
					firetime = 0;
				}
			}else if(joyPositionY < 0 && joyPositionX < Mathf.Sqrt(0.5f) && joyPositionX > -Mathf.Sqrt(0.5f)) {//turn down
				player_right.SetActive (false);
				player_up.SetActive (false);
				player_down.SetActive (true);
				player_left.SetActive (false);
				if(Weapon==1 && firetime>=0.2f){
					//shoot
					Instantiate(Weapon_bullet, firePoint_down.position,Quaternion.Euler(0f, 0f, 180f));
					firetime = 0;
				}
			}

		}
	} 
	void On_ButtonUp(string buttonName){
		if (buttonName=="WeaponButton"){
			gun_right.SetActive (true);
			gun_left.SetActive (true);
			gun_up.SetActive (true);
			gun_down.SetActive (true);
			Weapon = 1;
		}
	}
	void Update(){
		firetime += Time.deltaTime;
		if (blood == 0) {
			Time.timeScale = 0.0f; 
		}
	}
	void OnCollisionStay2D(Collision2D collider){
		if(collider.gameObject.tag.Equals("enemy") && blood>0 && collision_time>=1.5){
			blood-=5;
			player_right.GetComponent<Animator> ().SetBool ("Attacked", true);
			player_left.GetComponent<Animator> ().SetBool ("Attacked", true);
			player_up.GetComponent<Animator> ().SetBool ("Attacked", true);
			player_down.GetComponent<Animator> ().SetBool ("Attacked", true);
			collision_time =0;
		}
		collision_time += Time.deltaTime;
	}
	/*void OnTriggerStay2D(Collider2D collider){
		if(collider.gameObject.tag.Equals("enemy") && blood>0 && collision_time>=1.5){
			blood-=5;
			player_right.GetComponent<Animator> ().SetBool ("Attacked", true);
			player_left.GetComponent<Animator> ().SetBool ("Attacked", true);
			player_up.GetComponent<Animator> ().SetBool ("Attacked", true);
			player_down.GetComponent<Animator> ().SetBool ("Attacked", true);
			collision_time =0;
		}
		collision_time += Time.deltaTime;
	}*/
	void OnCollisionExit2D(Collision2D collider){
		Debug.Log("Exit");
		player_right.GetComponent<Animator> ().SetBool ("Attacked", false);
		player_left.GetComponent<Animator> ().SetBool ("Attacked", false);
		player_up.GetComponent<Animator> ().SetBool ("Attacked", false);
		player_down.GetComponent<Animator> ().SetBool ("Attacked", false);
		collision_time =3;
	}
	/*void OnTriggerExit2D(Collider2D collider){
		Debug.Log("Exit");
		player_right.GetComponent<Animator> ().SetBool ("Attacked", false);
		player_left.GetComponent<Animator> ().SetBool ("Attacked", false);
		player_up.GetComponent<Animator> ().SetBool ("Attacked", false);
		player_down.GetComponent<Animator> ().SetBool ("Attacked", false);
		collision_time =3;
	}*/
}
