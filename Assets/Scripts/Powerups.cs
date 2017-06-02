using UnityEngine;
using System.Collections;

public class Powerups : MonoBehaviour {

	public bool doublePoints;
	public bool safeMode;
	public bool slowDown;

	public float powerupLength;

	private PowerupManager thePowerupManager;
	public Sprite[] powerupSprite;



	// Use this for initialization
	void Start () {
		thePowerupManager = FindObjectOfType<PowerupManager> ();

	}
	// Run if activated
	void Awake() {
		int powerupSelector = Random.Range (0, 2);
		switch (powerupSelector) {
		case 0:
			doublePoints = true;
			break;
		case 1:
			safeMode = true;
			break;
		}

		GetComponent<SpriteRenderer> ().sprite = powerupSprite [powerupSelector];


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Panda") {
			thePowerupManager.ActivatePowerup (doublePoints, safeMode, powerupLength);
		}
		gameObject.SetActive (false);
	}
}
