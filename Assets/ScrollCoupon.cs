using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollCoupon : MonoBehaviour {

	[SerializeField] private GameObject buttonPrefab; // プレハブに入っているボタン

//	[SerializeField] private string couponPath;
	static int couponCount = 5; // 所持しているクーポンの個数
	private static int couponID = -1;
	CouponList couponList;

	// Use this for initialization
	void Start () {
		// 本当はここでサーバとかからクーポンの個数を取得して couponCount に格納したい
//		couponCount = 5;

		// クーポンを並べる場所（Content）を取得
		RectTransform content = GameObject.Find("Canvas/ScrollView/Viewport/Content").GetComponent<RectTransform>();

		// Contentの高さを設定
		//
		float buttonSpace = content.GetComponent<VerticalLayoutGroup>().spacing;
		float buttonHeight = buttonPrefab.GetComponent<LayoutElement>().preferredHeight;
		content.sizeDelta = new Vector2(0, (buttonHeight + buttonSpace) * couponCount);

		// クーポン表示関連
		// クーポン
		couponList = GameObject.Find ("CouponList").GetComponent<CouponList>();
		couponList.AddCoupon(new Coupon(0, couponList.CouponNames[0], couponList.CouponSprites[0]));
		foreach (Coupon coupon in CouponList._couponList) {
			if (coupon.getIsUsed())
				continue;
			GameObject button = (GameObject)Instantiate (buttonPrefab);
			button.transform.SetParent (content, false);
			button.transform.GetComponentInChildren<Text> ().text = coupon.getCouponName();
			button.transform.GetComponent<Button> ().onClick.AddListener (() => OnClick (coupon));
		}

//		for (int i = 0; i < couponCount; i++) {
//			int no = i;
//			// ボタン生成
//			GameObject button = (GameObject) Instantiate(buttonPrefab);
//			// ボタンを Content の子に設定
//			button.transform.SetParent(content, false);
//			// ボタンのテキスト変更
//			button.transform.GetComponentInChildren<Text>().text = "クーポン " + no.ToString();
//			// ボタンのクリックイベント
//			button.transform.GetComponent<Button>().onClick.AddListener(() => OnClick(no));
//		}

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnClick(Coupon coupon) {
		Debug.Log(coupon.getCouponID());
		SceneManager.LoadScene("ShowCoupon");
		couponList.selectedID = coupon.getCouponID();
	}
}
