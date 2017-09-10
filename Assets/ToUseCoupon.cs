using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouseCoupon : MonoBehaviour {
	
	[SerializeField] private AudioClip _audioClip;
	private AudioSource _audioSource;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SceneLoadToList () {
		_audioSource.PlayOneShot(_audioClip);
		SceneManager.LoadScene ("MyCoupon");
	}

}
