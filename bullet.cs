using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bullet : MonoBehaviour {
	public int moveSpeed = 20;
	private int mouse_left = 20;	//initial
	//public Text YouWinText;
	// Use this for initialization
	void Start () {
		//YouWinText.GetComponents<Text>() = "G8 left: " + mouse_left;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
		transform.position += transform.up * Time.deltaTime* moveSpeed;
		Destroy (gameObject, 0.5f);
	}

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.tag.Equals("enemy")) {
			Destroy(collider.gameObject, 0.1f);
			Destroy (this.gameObject);
			if(mouse_left>0){
				mouse_left--;
				//YouWinText.GetComponents<Text> = "G8 left: " + mouse_left;
			}else{
				Time.timeScale = 0.0f;
			}
		}

	}
}
