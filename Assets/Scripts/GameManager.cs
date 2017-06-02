using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;

	private ScoreManager theScoreManager;

	public DeathMenu theDeathScreen;

	public bool powerupReset;

	// Use this for initialization
	void Start () {
		// Lay vi tri ban dau cua Player va Generator Point
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame()
	{
		// Tao Coroutine goi ham RestartGameCo() ben duoi
		//StartCoroutine ("RestartGameCo");
		theScoreManager.scoreIncreasing = false; // Ngung tang diem
		thePlayer.gameObject.SetActive (false); //Player bien mat khi die

		theDeathScreen.gameObject.SetActive(true);
	}

	public void Reset()
	{
		// Inactive cac platform tren man hinh sau khi die
		theDeathScreen.gameObject.SetActive(false);

		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}
		//Set platform Generator va Player ve vi tri ban dau
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true); //Player xuat hien tai vi tri ban dau

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
		powerupReset = true;
	}

	/*public IEnumerator RestartGameCo()
	{
		theScoreManager.scoreIncreasing = false; // Ngung tang diem

		thePlayer.gameObject.SetActive (false); //Player bien mat khi die
		yield return new WaitForSeconds(0.5f); //Delay 0.5s

		// Inactive cac platform tren man hinh sau khi die
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}
		//Set platform Generator va Player ve vi tri ban dau
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true); //Player xuat hien tai vi tri ban dau

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}*/
}
