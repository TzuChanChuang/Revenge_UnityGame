using UnityEngine;
using System.Collections;

public class mouse : MonoBehaviour {
	private float moveSpeed = 2f;
	private float time;
	private int dir;
	private	int random_dir;
	private GameObject target;
	private Vector3 mouse_ini_pos;
	// Use this for initialization
	void Start () {
		time = 0f;
		//Destroy (gameObject, 50f);
		target = GameObject.Find ("alien").gameObject;

		mouse_ini_pos = new Vector3(this.transform.position.x, this.transform.position.y,this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		transform.position += transform.up * Time.deltaTime *moveSpeed;
		float tar_pos_x = target.transform.position.x;
		float tar_pos_y = target.transform.position.y;
		//float tar_pos_z = target.transform.position.z;
		if (this.gameObject.transform.GetChild (0).gameObject.activeSelf == false) {
			transform.rotation = Quaternion.Euler (0f, 0f, 180f);
			transform.position += transform.up * Time.deltaTime *2000;
			Destroy(this);
		} else {
			if (Mathf.Sqrt (Mathf.Pow (transform.position.x - tar_pos_x, 2) + Mathf.Pow (transform.position.y - tar_pos_y, 2)) < 7) {
				transform.LookAt (target.transform); 
				transform.Rotate (0, -90, -90);
			} else {
				if (transform.position.x >= 20 || transform.position.x <= -18 || transform.position.y >= 7 || transform.position.y <= -10) {
					transform.LookAt (mouse_ini_pos); 
					transform.Rotate (0, -90, -90);
					time = 1;
				} else if (time > 3) {
					random_dir = Random.Range (0, 360);
					transform.rotation = Quaternion.Euler (0f, 0f, random_dir);
					time = 0;
				}
			}
		}
	}
	
}
