using UnityEngine;
using System.Collections;

public class PickupPoints : MonoBehaviour {

	// DIem cong them
	public int scoreToGive;
	private ScoreManager theScoreManager; // Goi lai ScoreManager

	private AudioSource coinSound;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
		coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Kiem tra player va cham Coin (1 Collider bat ky)
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Panda") {
			theScoreManager.AddScore (scoreToGive);
			gameObject.SetActive (false);
			if (coinSound.isPlaying) {
				coinSound.Stop ();
				coinSound.Play ();
			} else
				coinSound.Play ();
		}
	}
}
