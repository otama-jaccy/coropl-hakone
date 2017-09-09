using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager: SingletonMonoBehaviour<PlayManager>
{
	public Phase GameStatus;
	
	public enum Phase
	{
		Ready,
		Playing,
		Fin
	}

	public bool Generatable;
	
	// Use this for initialization
	void Start () {
		GameStatus = Phase.Ready;	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
