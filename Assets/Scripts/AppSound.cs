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
	void Update ()
	{
		GetComponent<AudioSource>().volume = 0.8f;
		if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "Result")
		{
			GetComponent<AudioSource>().volume = 0f;
		}
	}
}
