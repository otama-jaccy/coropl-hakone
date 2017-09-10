using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cream : MonoBehaviour
{
	[SerializeField] private ScoreManager _scoreManager;
	[SerializeField] private AudioClip _audioClip;
	private float _collisionTime;
	private AudioSource _audioSource;
	
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().enabled = false;
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		if (gameObject.transform.position.y < -2.8f)
		{
			Destroy(gameObject);
		}

		if (PlayManager.instance.GameStatus == PlayManager.Phase.Ready)
		{
			gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("UpperBoundary")) return;
		GetComponent<SpriteRenderer>().enabled = true;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("BottomBoundary")) return;
		print("aa");
		Destroy(gameObject);
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		if (!other.gameObject.CompareTag("Player")) return;
		_collisionTime += Time.deltaTime;
		if (_collisionTime > 0.2f)
		{
			_audioSource.PlayOneShot(_audioClip);
			Destroy(gameObject, 0.1f);
			_scoreManager.CalcScore();
			_collisionTime = 0;
		}
	}
}


