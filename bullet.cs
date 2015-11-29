using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bullet : MonoBehaviour {
	public int moveSpeed = 20;
	Text G8Left;
	public static int g8_count = 10; 
	public Transform Stick;
	public Transform Stick_createpoint;
	// Use this for initialization
	void Start () {
		G8Left =  GameObject.FindWithTag("Txt_G8Left").gameObject.GetComponent<Text>();
		//Debug.Log (G8Left.text);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
		transform.position += transform.up * Time.deltaTime* moveSpeed;
		Destroy (gameObject, 0.5f);

	}

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.tag.Equals ("enemy")) {
			//Destroy(collider.gameObject, 0.0f);
			collider.gameObject.transform.GetChild (0).gameObject.SetActive (false);
			g8_count = int.Parse (G8Left.text) - 1;
			G8Left.text = g8_count.ToString ();
			Destroy (this.gameObject);
			Instantiate (Stick, Stick_createpoint.position, Quaternion.Euler (0f, 0f, 0f));
			if (g8_count == 0) {
				//Debug.Log("yesssssssssssssss");
				Time.timeScale = 0.0f; 
			}
		} else if(!collider.gameObject.tag.Equals ("alien_total")) {
			Destroy (this.gameObject);
		}

	}
}
