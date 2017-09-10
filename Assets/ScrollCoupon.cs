using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollCoupon : MonoBehaviour {

	[SerializeField] private GameObject buttonPrefab; // プレハブに入っているボタン
	[SerializeField] private AudioClip _audioClip;
	static int couponCount = 5; // 所持しているクーポンの個数
	private static int couponID = -1;
	CouponList couponList;
	private AudioSource _audioSource;

	// Use this for initialization
	void Start () {
		// クーポンを並べる場所（Content）を取得
		RectTransform content = GameObject.Find("Canvas/ScrollView/Viewport/Content").GetComponent<RectTransform>();

		// Contentの高さを設定
		float buttonSpace = content.GetComponent<VerticalLayoutGroup>().spacing;
		float buttonHeight = buttonPrefab.GetComponent<LayoutElement>().preferredHeight;
		content.sizeDelta = new Vector2(0, (buttonHeight + buttonSpace) * couponCount);

		// クーポン表示関連
		couponList = GameObject.Find ("CouponList").GetComponent<CouponList>();
		List<int> idList = couponList.CouponIdList;

		foreach (var id in idList)
		{
			GameObject button = (GameObject)Instantiate (buttonPrefab);
			button.transform.SetParent (content, false);
			button.transform.GetComponentInChildren<Text> ().text = couponList.CouponNames[id];
			button.transform.GetComponent<Button> ().onClick.AddListener (() => OnClick (id));
		}

		_audioSource = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnClick(int id)
	{
		_audioSource.PlayOneShot(_audioClip);
		SceneManager.LoadScene("ShowCoupon");
		couponList.selectedID = id;
	}
}
