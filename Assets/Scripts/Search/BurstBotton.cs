﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BurstBotton : MonoBehaviour {
	
	[SerializeField] private AudioClip _audioClip;
	private AudioSource _audioSource;
	private Button button;
	private Color color;
	private Vector3 position;
	private RectTransform rectTransform;
	private float x;
	
	void Start(){
		_audioSource = GetComponent<AudioSource>();
		button = GetComponent<Button> ();
		button.onClick.AddListener(onClick);
		rectTransform = gameObject.GetComponent<RectTransform>();
		position = gameObject.transform.position;
		x = position.x;
		Hide ();
	}
	
	void Visiable()
	{
		position.x = x;
		rectTransform.position = position;
	}

	void Hide()
	{
		position.x = 10000000;
		rectTransform.position = position;
	}

	void onClick()
	{
		_audioSource.PlayOneShot(_audioClip);
		SceneManager.LoadScene("Game");
	}
}
