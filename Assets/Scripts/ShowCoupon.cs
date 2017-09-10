using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowCoupon : MonoBehaviour {

	[SerializeField] private GameObject popUpView;
	[SerializeField] private Image renderer;
	[SerializeField] private Image thumnail;
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CouponUse() {
		popUpView.SetActive (true);
		thumnail.enabled = false;
		var selectCoupon = CouponList._couponList.Find(cp => cp.getCouponID() == _selectedID);
		selectCoupon.setIsUsed (true);
	}

	public void Back() {
		SceneManager.LoadScene ("MyCoupon");
	}
}
