using System;
using System.Collections.Generic;
using UnityEngine;

public class CouponList : SingletonMonoBehaviour<CouponList> {
	
	[SerializeField] public Sprite[] CouponSprites;
	[SerializeField] public String[] CouponNames;
//	public List<Coupon> _couponList;
	public List<int> CouponIdList;
	public int selectedID = -1;

	void Start()
	{
		DontDestroyOnLoad(gameObject);
//		_couponList = new List<Coupon>();	
		CouponIdList = new List<int>();
	}

//	public void AddCoupon(Coupon cp)
	public void AddCoupon(int id)
	{
//		print(cp);
		if (id != null &&  CouponIdList!= null)
		{
//			_couponList.Add(usergetcoupon);
			CouponIdList.Add(id);
		}
	}


//	public void RemoveCoupon(Coupon cp)
	public void RemoveCoupon(int id)
	{
//		_couponList.Remove(cp);
		CouponIdList.Remove(id);
	}
}
