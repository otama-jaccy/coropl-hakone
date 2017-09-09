using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollCoupon : MonoBehaviour {

	private GameObject buttonPrefab; // プレハブに入っているボタン
	int couponCount; // 所持しているクーポンの個数

	// Use this for initialization
	void Start () {
		// 本当はここでサーバとかからクーポンの個数を取得して couponCount に格納したい
		couponCount = 5;

		// クーポンを並べる場所（Content）を取得
		RectTransform content = GameObject.Find("Canvas/ScrollView/Viewport/Content")
			.GetComponent<RectTransform>();

		// Contentの高さを設定
		//
		float buttonSpace = content.GetComponent<VerticalLayoutGroup>().spacing;
		float buttonHeight = buttonPrefab.GetComponent<LayoutElement>().preferredHeight;
		content.sizeDelta = new Vector2(0, (buttonHeight + buttonSpace) * couponCount);
		for (int i = 0; i < couponCount; i++) {
			int no = i;
			GameObject button = (GameObject) Instantiate(buttonPrefab);
			button.transform.SetParent(content, false);
			button.transform.GetComponentInChildren<Text>().text = "クーポン " + no.ToString();
			// ボタンのクリックイベント
			button.transform.GetComponent<Button>().onClick.AddListener(() => OnClick(no));
		}

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnClick(int no) {
		Debug.Log(no);
	}
}
