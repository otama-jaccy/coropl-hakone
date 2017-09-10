using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppSound : SingletonMonoBehaviour<AppSound> {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		print(GetComponent<AudioSource>().isPlaying);
		if (!GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "Result")
		{
			GetComponent<AudioSource>().Stop();
		}
	}
}
