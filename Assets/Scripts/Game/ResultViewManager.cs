﻿using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ResultViewManager : MonoBehaviour
{

	[SerializeField] private Text _scoreValue;
	[SerializeField] private Text _couponMesText;
	[SerializeField] private Text _getCouponMes;

	[SerializeField] private CouponList _couponsList;
	[SerializeField] private Image _couponImage;
	
	[SerializeField] private AudioClip _counterClip;
	[SerializeField] private AudioClip _tadasound;
	private float _userScore;
	private float _score;
	private bool _couponMes = false;
	private bool _getcouponMes = false;
	private bool _fontreturn = false;
	private bool _firstbool = true;
	private AudioSource _audioSource;

	// Use this for initialization
	void Start ()
	{
//		_userScore = ScoreManager.Score;
		_userScore = 800;
		_score = 0;
		
		_audioSource = GetComponent<AudioSource>();

		int couponNum = Random.Range(0, 2);

		Coupon getcoupon = new Coupon(couponNum, _couponsList.CouponNames[couponNum], _couponsList.CouponSprites[couponNum]);
		
		
		_couponMesText.enabled = false;
		_getCouponMes.enabled = false;
		_couponImage.enabled = false;
		
		_couponImage.sprite = _couponsList.CouponSprites[couponNum];
		
		_couponsList.AddCoupon(getcoupon);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		ScoreView();

		if (_couponMes)
		{
			CouponMesAnimation();
		}

		if (_getcouponMes)
		{
			ShowCoupon();
		}
	}

	private void ScoreView()
	{
		_scoreValue.text = _score.ToString();
		if ((int)_score < (int)_userScore)
		{
			_score += 10;
			_audioSource.PlayOneShot(_counterClip);
		}
		if ((int) _score >= (int) _userScore)
		{
			_score = _userScore;
			_couponMes = true;
		}
	}

	private void CouponMesAnimation()
	{
		if (_firstbool)
		{
			_audioSource.PlayOneShot(_tadasound);
			_firstbool = false;
		}
		_couponMesText.enabled = true;
		if (_couponMesText.GetComponent<Text>().fontSize < 70)
		{
			_couponMesText.GetComponent<Text>().fontSize += 2;
		}
		if (_couponMesText.GetComponent<Text>().fontSize > 70 || _couponMesText.GetComponent<Text>().fontSize < 80)
		{
			if (!_fontreturn)
			{
				_couponMesText.GetComponent<Text>().fontSize += 2;
			}
			else
			{
				_couponMesText.GetComponent<Text>().fontSize -= 1;
				if (_couponMesText.GetComponent<Text>().fontSize <= 70)
				{
					_couponMesText.GetComponent<Text>().fontSize = 70;
					_getcouponMes = true;
				}
			}
		}
		if (_couponMesText.GetComponent<Text>().fontSize >= 80)
		{
			_couponMesText.GetComponent<Text>().fontSize -= 1;
			_fontreturn = true;
		}
	}

	private void ShowCoupon()
	{
		_getCouponMes.enabled = true;
		_couponImage.enabled = true;
	}
}
