using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	public int enemy_upperbound;
	private int enemy_num=0;
	public Transform mouse;
	public Transform door_point;
	private	int random_dir;
	private float time;
	// Use this for initialization
	void Start () {
		enemy_upperbound =20;
		enemy_num = 0;
		time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (enemy_num < enemy_upperbound && time > 3) {
			random_dir = Random.Range (1, 4);
			Instantiate (mouse, door_point.position, Quaternion.Euler (0f, 0f, random_dir * 90f));
			time = 0;
			enemy_num++;
		}
	}
}
