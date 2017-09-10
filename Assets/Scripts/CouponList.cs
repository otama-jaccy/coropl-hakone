using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CouponList : SingletonMonoBehaviour<CouponList> {
	
	[SerializeField] public Sprite[] CouponSprites;
	[SerializeField] public String[] CouponNames;
	public static List<Coupon> _couponList;
	public int selectedID = -1;

	void Awake()
	{
		_couponList = new List<Coupon>();
		DontDestroyOnLoad(gameObject);
	}

	public void AddCoupon(Coupon cp)
	{
		print(cp);
		print(_couponList);
		if (cp != null && _couponList != null)
		{
			_couponList.Add(cp);
		}
	}


	public void RemoveCoupon(Coupon cp)
	{
		_couponList.Remove(cp);
	}
}
