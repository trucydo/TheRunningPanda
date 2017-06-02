/// <summary>
/// Camera cotroller.
/// Xu ly Camera --> Khung camera (khong chay theo Player - Player la trung tam) ma se chay truoc Player 1 doan
/// </summary>

using UnityEngine;
using System.Collections;

public class CameraCotroller : MonoBehaviour {

	public PlayerController thePlayer;

	private Vector3 lastPlayerPosition; //luu vector3(x,y,z) giu vi tri cua Player
	private float distanceToMove; // Camera se chay len truoc 1 doan 

	// Use this for initialization
	void Start () {
		// Tim vi tri player dang o dau --> luu vao thePlayer
		thePlayer = FindObjectOfType<PlayerController> ();
		// Lay vi tri thePlayer
		lastPlayerPosition = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Khoang cach dich Camera = khoang cach bay gio cua Player - khoang cach duoc luu o LastPosition
		// (do toc do PLayer tang dan nen distnaceToMove khong phai la bien tinh ma phai gan lai moi frame)
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		// Dich 1 doan = vi tri truc x hien tai + distanceToMove
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z); //Vi tri Camera
		// Gan lai cho lastPlayerPosition
		lastPlayerPosition = thePlayer.transform.position;
	}
}
