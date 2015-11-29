using UnityEngine;
using System.Collections;

public class stick : MonoBehaviour {
	private GameObject target;
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("alien").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		float tar_pos_x = target.transform.position.x;
		float tar_pos_y = target.transform.position.y;
		if (Mathf.Sqrt (Mathf.Pow (transform.position.x - tar_pos_x, 2) + Mathf.Pow (transform.position.y - tar_pos_y, 2)) <2) {
			CG_fade_test.item1_count = CG_fade_test.item1_count+1;
			Destroy(this.gameObject);
		}
	}
}
