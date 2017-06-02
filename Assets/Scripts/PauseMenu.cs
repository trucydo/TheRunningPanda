using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel; //String chua ten cua scene MainMenu
	public GameObject pauseMenu;


	public void PauseGame()
	{
		Time.timeScale = 0f; // 0: ngung game; 1: chay bt
		pauseMenu.SetActive(true);
	}

	//Phai set lai time ve 1 cho tat ca nhung cai con lai
	public void ResumeGame()
	{
		Time.timeScale = 1f;
		//yield return new WaitForSeconds(0.5f); 
		pauseMenu.SetActive(false);
	}

	public void RestartGame()
	{
		Time.timeScale = 1f;
		FindObjectOfType<GameManager> ().Reset();
		pauseMenu.SetActive(false);
	}

	public void Quit2MainMenu()
	{
		Time.timeScale = 1f;
		Application.LoadLevel (mainMenuLevel);
	}



}
