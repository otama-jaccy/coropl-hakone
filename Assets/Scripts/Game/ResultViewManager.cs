using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ResultViewManager : MonoBehaviour
{

	[SerializeField] private Text _scoreValue;
	[SerializeField] private Text _couponMesText;
	[SerializeField] private Text _getCouponMes;

//	[SerializeField] private CouponList _couponsList;
	[SerializeField] private Image _couponImage;
	
	[SerializeField] private AudioClip _counterClip;
	[SerializeField] private AudioClip _tadasound;
	private float _userScore;
	private float _score;
	private bool _couponMes = false;
	private bool _getcouponMesflag = false;
	private bool _fontreturn = false;
	private bool _firstbool = true;
	private bool _showScore = true;
	private AudioSource _audioSource;
	private CouponList _couponList;

	// Use this for initialization
	void Start ()
	{
		print("start called");
		_userScore = ScoreManager.Score;
		_score = 0;
		
		_audioSource = GetComponent<AudioSource>();
		_couponList = GameObject.Find ("CouponList").GetComponent<CouponList>();

		int couponNum = Random.Range(0, 3);
		print(couponNum);

//		Coupon getcoupon = new Coupon(couponNum, _couponList.CouponNames[couponNum], _couponList.CouponSprites[couponNum]);
		Coupon getcoupon = new Coupon();
		getcoupon.setCouponID(couponNum);
		getcoupon.setCouponName(_couponList.CouponNames[couponNum]);
		getcoupon.setSprite(_couponList.CouponSprites[couponNum]);
		_couponMesText.enabled = false;
		_getCouponMes.enabled = false;
		_couponImage.enabled = false;
		
		_couponImage.sprite = _couponList.CouponSprites[couponNum];
		
//		_couponList.AddCoupon(getcoupon);
		_couponList.AddCoupon(couponNum);
	}
	
	// Update is called once per frame
	void Update ()
	{
		_scoreValue.text = _score.ToString();
		if (_showScore)
		{
			ScoreView();
		}

		if (_couponMes)
		{
			CouponMesAnimation();
		}

		if (_getcouponMesflag)
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
			_showScore = false;
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
					_getcouponMesflag = true;
					_couponMes = false;
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
		_getcouponMesflag = false;
		_getCouponMes.enabled = true;
		_couponImage.enabled = true;
	}
}
