using UnityEngine;
using System.Collections;

public class firebutton : MonoBehaviour {
	//private GameObject player_1;
	//private GameObject player_2;

	void Start(){
		//player_1 = transform.Find ("p1_walk").gameObject;
		//player_2 = transform.Find ("p2_walk").gameObject;  
	}
	void OnEnable(){
		EasyButton.On_ButtonUp += On_ButtonUp;	
	}
	void OnDisable(){
		EasyButton.On_ButtonUp -= On_ButtonUp;
	}
	void On_ButtonUp(string buttonName){
		if (buttonName=="WeaponButton"){
			transform.Find ("p1_walk").gameObject.transform.Find ("gunleft").gameObject.SetActive (true);
			transform.Find ("p2_walk").gameObject.transform.Find ("gunright").gameObject.SetActive (true);
		}
	}
}
