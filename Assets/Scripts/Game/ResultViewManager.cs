using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ResultViewManager : MonoBehaviour
{

	[SerializeField] private Text _scoreValue;
	[SerializeField] private Text _couponMesText;
	[SerializeField] private Text _getCouponMes;
	[SerializeField] private Image _couponImage;
	[SerializeField] private Sprite[] _couponSprite;
	private float _userScore;
	private float _score;
	private bool _couponMes = false;
	private bool _getcouponMes = false;
	private bool _fontreturn = false;

	// Use this for initialization
	void Start ()
	{
//		_userScore = ScoreManager.Score;
		int couponNum = Random.Range(0, _couponSprite.Length);
		_couponImage.sprite = _couponSprite[couponNum];
		_score = 0;
		_userScore = 800;
		_couponMesText.enabled = false;
		_getCouponMes.enabled = false;
		_couponImage.enabled = false;
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
		}
		if ((int) _score >= (int) _userScore)
		{
			_score = _userScore;
			_couponMes = true;
		}
	}

	private void CouponMesAnimation()
	{
		_couponMesText.enabled = true;
		if (_couponMesText.GetComponent<Text>().fontSize < 90)
		{
			_couponMesText.GetComponent<Text>().fontSize += 2;
		}
		if (_couponMesText.GetComponent<Text>().fontSize > 90 || _couponMesText.GetComponent<Text>().fontSize < 99)
		{
			if (!_fontreturn)
			{
				_couponMesText.GetComponent<Text>().fontSize += 2;
			}
			else
			{
				_couponMesText.GetComponent<Text>().fontSize -= 1;
				if (_couponMesText.GetComponent<Text>().fontSize <= 90)
				{
					_couponMesText.GetComponent<Text>().fontSize = 90;
					_getcouponMes = true;
				}
			}
		}
		if (_couponMesText.GetComponent<Text>().fontSize >= 99)
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
