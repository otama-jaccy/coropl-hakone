using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	[SerializeField] private Text _scoreValue;
	public static float Score;
	
	// Use this for initialization
	void Start ()
	{
		Score = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		_scoreValue.text = Score.ToString();
	}

	public void CalcScore()
	{
		Score += 10;
	}
}
