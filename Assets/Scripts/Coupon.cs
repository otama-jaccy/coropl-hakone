using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coupon {

	[SerializeField] private static int couponID;
	[SerializeField] private static string couponName;
	[SerializeField] private static Sprite sprite;
	[SerializeField] private static bool isUsed = false;

//	public Coupon(int id, string name, Sprite src)
//	{
//		couponID = id;
//		couponName = name;
//		sprite = src;
//	}
	
	// セッタ
	public void setCouponID (int id) {
		couponID = id;
	}

	public void setCouponName (string name) {
		couponName = name;
	}

	public bool setSprite (Sprite src) {
		if (src != null) {
			sprite = src;
			return true;
		}
		return false;
	}

	public void setIsUsed (bool flag) {
		isUsed = flag;
	}

	// ゲッタ
	public int getCouponID () {
		return couponID;
	}

	public string getCouponName () {
		return couponName;
	}

	public Sprite getSprite () {
		return sprite;
	}

	public bool getIsUsed () {
		return isUsed;
	}
}
