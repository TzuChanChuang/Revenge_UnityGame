using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stick : MonoBehaviour {
	private GameObject target;
	public float stick_num = 0;
	Text Stick;
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("alien").gameObject;
		Stick = GameObject.FindWithTag("Txt_Stick").gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		float tar_pos_x = target.transform.position.x;
		float tar_pos_y = target.transform.position.y;
		if (Mathf.Sqrt (Mathf.Pow (transform.position.x - tar_pos_x, 2) + Mathf.Pow (transform.position.y - tar_pos_y, 2)) <2) {
			stick_num = int.Parse(Stick.text)+1;
			Stick.text = stick_num.ToString();
			Destroy(this.gameObject);
		}
	}
}
