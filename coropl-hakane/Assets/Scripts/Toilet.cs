using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Unity.Map;
using UnityEngine.UI;

public class Toilet : MonoBehaviour {
	[SerializeField]
	private AbstractMap _map;

	[SerializeField]
	private float lon,lat;

	[SerializeField]
	Button burst_button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Conversions.GeoToWorldPosition(lon,lat,
										_map.CenterMercator,
										_map.WorldRelativeScale).ToVector3xz();
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Player") {
			Debug.Log ("BURST");
			burst_button.SendMessage ("Visiable");
		}
	}

	void OnTriggerExit(Collider other){
		if (other.name == "Player") {
			Debug.Log ("NOT BURST");
			burst_button.SendMessage ("Hide");
		}
	}
}
