using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
	[SerializeField] private CountDownTimer _countDownTimer;
	[SerializeField] private AudioClip _countDownClip;
	private AudioSource _audioSource;
	private bool _isCountdown;
	
	// Use this for initialization
	void Start ()
	{
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayManager.instance.GameStatus == PlayManager.Phase.Fin)
		{
			_audioSource.Stop();
		}

		if (_countDownTimer.StartCountdown && !_isCountdown)
		{
			_audioSource.PlayOneShot(_countDownClip);
			_isCountdown = true;
		}
	}
}
