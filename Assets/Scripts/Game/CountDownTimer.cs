using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownTimer : SingletonMonoBehaviour<CountDownTimer>
{
	[SerializeField] private float _maxtime;
	[SerializeField] private Text _timerText;
	[SerializeField] private RxCountDownTimer _rxCountDownTimer;
	public bool StartCountdown;
	private AudioSource _audioSource;
	private bool _startBgm;
	private float _time;

	// Use this for initialization
	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_startBgm = false;
		StartCountdown = false;
		_time = _maxtime;
	}

	// Update is called once per frame
	void Update()
	{
		if (PlayManager.instance.GameStatus != PlayManager.Phase.Playing) return;
		if (_time > 0)
		{
			if (!_startBgm)
			{
				_audioSource.Play();
				_startBgm = true;
			}
			_time -= Time.deltaTime;
			var currentTime = (int) _time;
			_timerText.text = currentTime.ToString();
			if (_time < 4)
			{
				StartCountdown = true;
				_rxCountDownTimer.StartCountDown();
			}
		}

		if (!(_time < 1)) return;
		_time = 0;
		PlayManager.instance.GameStatus = PlayManager.Phase.Fin;
		Observable.Timer(TimeSpan.FromSeconds(3f))
			.Subscribe(_ => SceneManager.LoadScene("Result"));
		_audioSource.Stop();
	}
}
