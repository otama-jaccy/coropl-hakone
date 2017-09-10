using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CornMove : MonoBehaviour
{
	private Vector2 _from;
	private Vector2 _to;
	private Vector2 _objectPosition;
	[SerializeField] private Sprite[] _cornSprites;
	
	// Use this for initialization
	void Start () {
		var i = Random.Range(0, _cornSprites.Length-1);
		GetComponent<SpriteRenderer>().sprite = _cornSprites[i];
	}
	
	// Update is called once per frame
	void Update ()
	{
		RestrictPosition();
		if (PlayManager.instance.GameStatus != PlayManager.Phase.Fin)
		{
			PlayerMovable();
		}
	}

	private void LateUpdate()
	{
		if (Input.GetMouseButton(0))
		{
			_from = Input.mousePosition;
		}
	}

	private void PlayerMovable()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_from = Input.mousePosition;
			_to = Input.mousePosition;
		}

		if (Input.GetMouseButton(0))
		{
			print(_to.x - _from.x);
			_to = Input.mousePosition;
			_objectPosition = gameObject.transform.position;
			if (Math.Abs((_to.x - _from.x)) > 0.01f)
			{
				_objectPosition.x += (_to.x - _from.x) / 150;
				gameObject.transform.position = _objectPosition;
			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			_from = Input.mousePosition;
			_to = Input.mousePosition;
			_objectPosition = Input.mousePosition;
		}
	}

	private void RestrictPosition()
	{
		float x = gameObject.transform.position.x;
		if (x < -3f)
		{
			x = -3f;
			gameObject.transform.position = new Vector2(x, gameObject.transform.position.y);
		}else if (x > 3f)
		{
			x = 3f;
			gameObject.transform.position = new Vector2(x, gameObject.transform.position.y);
		}
	}
}
