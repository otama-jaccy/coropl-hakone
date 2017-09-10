using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class ButtonManager : MonoBehaviour
{

	[SerializeField] private GameObject _popUpView;
	[SerializeField] private Button _poseButton;
	[SerializeField] private AudioClip _pushButtonClip;
	private AudioSource _audioSource;
	
	// Use this for initialization
	void Start () {
		_popUpView.SetActive(false);
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PauseButton()
	{
		_audioSource.PlayOneShot(_pushButtonClip);
		_popUpView.SetActive(true);
		PlayManager.instance.GameStatus = PlayManager.Phase.Ready;
		_poseButton.interactable = false;
	}

	public void Restart()
	{
		_audioSource.PlayOneShot(_pushButtonClip);
		_popUpView.SetActive(false);
		_poseButton.interactable = true;
		PlayManager.instance.GameStatus = PlayManager.Phase.Playing;
	}

	public void GameCancel()
	{
		_audioSource.PlayOneShot(_pushButtonClip);
		SceneManager.LoadScene("Title");
	}

	public void BackToTitle()
	{
		_audioSource.PlayOneShot(_pushButtonClip);
		SceneManager.LoadScene("Title");
	}
}

