using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowCoupon : MonoBehaviour {

	[SerializeField] private GameObject popUpView;
	[SerializeField] private Image renderer;
	[SerializeField] private Image thumnail;
	[SerializeField] private AudioClip _audioClip;
	private AudioSource _audioSource;
	private CouponList couponList;
	private Sprite couponImage;
	private int _selectedID;

	// Use this for initialization
	void Start () {
		couponList = GameObject.Find ("CouponList").GetComponent<CouponList>();
		popUpView.SetActive (false);
		_selectedID = couponList.selectedID;
		couponImage = couponList.CouponSprites [_selectedID];
		renderer.sprite = couponImage;
		thumnail.sprite = couponImage;
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CouponUse() {
		_audioSource.PlayOneShot(_audioClip);
		popUpView.SetActive (true);
		thumnail.enabled = false;
		var selectCoupon = couponList.CouponIdList.Find(cp => cp == _selectedID);
//		selectCoupon.setIsUsed (true);
		couponList.RemoveCoupon(selectCoupon);
	}

	public void Back() {
		_audioSource.PlayOneShot(_audioClip);
		SceneManager.LoadScene ("MyCoupon");
	}
}
