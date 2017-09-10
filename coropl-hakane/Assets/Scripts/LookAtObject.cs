using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour {
	[SerializeField]
	GameObject _object;

	[SerializeField]
	Vector3 _lotate = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (_object.transform);
		transform.Rotate (_lotate);
	}
}
