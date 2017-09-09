using UnityEngine;

public class CreamGenerator : MonoBehaviour
{
	[SerializeField] private GameObject _cream;
	[SerializeField] private float _maxLeft;
	[SerializeField] private float _maxRight;
	[SerializeField] private float _instantiateY;
	[SerializeField] private float _spanTime;
	float timeElapsed;
//	[SerializeField] private Sprite[] _creamSprites;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayManager.instance.GameStatus == PlayManager.Phase.Playing)
		{
			timeElapsed = +Time.deltaTime;
			if (timeElapsed >= _spanTime)
			{
				GenerateCream();
				timeElapsed = 0.0f;
			}
		}
	}
	
	private void GenerateCream()
	{
		//creamをInstantiate 
		var cream = Instantiate(_cream);
		var x =  Random.Range( _maxLeft, _maxRight);
		cream.transform.position = new Vector2(x, _instantiateY); //instantiate positionの指定
//		var length = _creamSprites.Length;
//		var i = Random.Range(0, length); //配列長分のコーンの種類
		var creamColor = new Color(Random.Range(0f,256f), Random.Range(0f,256f), Random.Range(0f,256f));
		var creamsprite = cream.GetComponent<SpriteRenderer>(); 
		creamsprite.color = creamColor; //spriteの指定
	}
}
