using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

	public Text scoreText;
	public Text hiScoreText;

	public float scoreCount;
	public float hiScoreCount;

	public string mainMenuLevel; //String chua ten cua scene MainMenu

	public void RestartGame()
	{
		FindObjectOfType<GameManager> ().Reset();
	}

	public void Quit2MainMenu()
	{
		Application.LoadLevel (mainMenuLevel);
	}

	public void Update()
	{
		SetScores ();
	}

	public void SetScores()
	{
		scoreCount = FindObjectOfType<ScoreManager> ().ReturnScore ();
		hiScoreCount = FindObjectOfType<ScoreManager> ().ReturnHighScore ();
		scoreText.text = "" + Mathf.Round (scoreCount);//Lam tron thanh so nguyen
		hiScoreText.text = "" + Mathf.Round (hiScoreCount);
	}
}
