using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text hiScoreText;

	public float scoreCount;
	public float hiScoreCount;

	public float pointsPerSec;

	public bool scoreIncreasing;

	public bool shouldDouble;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("HighScore")) {
			hiScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreIncreasing) {
			scoreCount += pointsPerSec * Time.deltaTime;

			if (scoreCount > hiScoreCount) {
				hiScoreCount = scoreCount;
				PlayerPrefs.SetFloat ("HighScore", hiScoreCount);
			}

			scoreText.text = "Score: " + Mathf.Round (scoreCount);//Lam tron thanh so nguyen
			hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount);
		}
	}

	// Them diem
	public void AddScore(int pointsToAdd){
		if (shouldDouble)
			pointsToAdd = pointsToAdd * 2;
		scoreCount += pointsToAdd;
	}

	public float ReturnScore()
	{
		return scoreCount;
	}
	public float ReturnHighScore()
	{	
		return hiScoreCount;
	}
}
