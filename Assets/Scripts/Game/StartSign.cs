using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartSign : MonoBehaviour {

	private Text _startSign;

	// Use this for initialization
	void Start ()
	{
		_startSign = GetComponent<Text>();
		_startSign.enabled = true;

		StartCoroutine(StartSignCoroutine());
	}

	private void Update()
	{
		if (PlayManager.instance.GameStatus == PlayManager.Phase.Fin)
		{
			FinSign();
		}
		
	}

	private IEnumerator StartSignCoroutine()
	{
		yield return new WaitForSeconds(1f);
		_startSign.text = "Ready...";
		yield return new WaitForSeconds(1f);
		_startSign.text = "Go!";
		yield return  new WaitForSeconds(1f);
		_startSign.enabled = false;
		PlayManager.instance.GameStatus = PlayManager.Phase.Playing;
	}

	private void FinSign()
	{
		_startSign.enabled = true;
		_startSign.text = "Finish!";
		_startSign.color = Color.red;
	}
}
