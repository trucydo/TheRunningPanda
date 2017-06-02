using UnityEngine;
using System.Collections;

public class PowerupManager : MonoBehaviour {

	private bool doublePoints;
	private bool safeMode;
	private bool slowDown;

	private bool powerupActive;
	private float powerupLengthCounter;

	private ScoreManager theScoreManager;
	private PlatformGenerator thePlatformGenerator;
	private GameManager theGameManager;

	private float normalPointsperSecond;
	private float spikeRate;

	private PlatformDestroyer[] spikeList;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
		thePlatformGenerator = FindObjectOfType<PlatformGenerator> ();
		theGameManager = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (powerupActive) {
			powerupLengthCounter -= Time.deltaTime;

			if (theGameManager.powerupReset) {
				powerupLengthCounter = 0;
				theGameManager.powerupReset = false;
			}
			if (doublePoints) {
				theScoreManager.pointsPerSec = normalPointsperSecond * 2;
				theScoreManager.shouldDouble = true;
			}
			if (safeMode) {
				thePlatformGenerator.randomSpikeThreshold = 0;
			}

			if (powerupLengthCounter <= 0) {
				theScoreManager.pointsPerSec = normalPointsperSecond;
				theScoreManager.shouldDouble = false;
				thePlatformGenerator.randomSpikeThreshold = spikeRate;

				powerupActive = false;
			}
		}
	}
	//public void ActivatePowerup(bool points, bool safe, bool slow, float time)
	public void ActivatePowerup(bool points, bool safe, float time)
	{
		doublePoints = points;
		safeMode = safe;
		//slowDown = slow;
		powerupLengthCounter = time;

		normalPointsperSecond = theScoreManager.pointsPerSec;
		spikeRate = thePlatformGenerator.randomSpikeThreshold;

		if (safeMode) {
			spikeList = FindObjectsOfType<PlatformDestroyer> ();
			for (int i = 0; i < spikeList.Length; i++) { //name.Contains("Spike")
				if (spikeList [i].gameObject.name == "Spikes(Clone)") {
					spikeList [i].gameObject.SetActive (false);
				}
			}
		}


		powerupActive = true;
	}
}
