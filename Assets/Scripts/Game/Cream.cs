using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cream : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().enabled = false;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("UpperBoundary")) return;
		GetComponent<SpriteRenderer>().enabled = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("ButtomBoundary"))
		{
			Destroy(gameObject);
		}else if (other.gameObject.CompareTag("Player"))
		{
			//スコアを増やす
		}
	}
}
