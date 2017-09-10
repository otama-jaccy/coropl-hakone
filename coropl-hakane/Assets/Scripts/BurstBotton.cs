using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurstBotton : MonoBehaviour {
	private Button button;

	void Start(){
		button = GetComponent<Button> ();
		Hide ();
	}

	void Visiable(){
		button.interactable = true;
	}

	void Hide(){
		button.interactable = false;
	}
}
