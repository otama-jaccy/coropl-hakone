﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTItle : MonoBehaviour {
	
	[SerializeField] private AudioClip _audioClip;
	private AudioSource _audioSource;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BackToTitle()
	{
		_audioSource.PlayOneShot(_audioClip);
		SceneManager.LoadScene("Title");
	}
}
