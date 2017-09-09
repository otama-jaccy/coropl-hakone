using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class ButtonManager : MonoBehaviour
{

	[SerializeField] private GameObject _popUpView;
	[SerializeField] private Button _poseButton;
	
	// Use this for initialization
	void Start () {
		_popUpView.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PauseButton()
	{
		_popUpView.SetActive(true);
		PlayManager.instance.GameStatus = PlayManager.Phase.Ready;
		_poseButton.interactable = false;
	}

	public void Restart()
	{
		_popUpView.SetActive(false);
		_poseButton.interactable = true;
		PlayManager.instance.GameStatus = PlayManager.Phase.Playing;
	}

	public void GameCancel()
	{
		SceneManager.LoadScene("Title");
	}
}

