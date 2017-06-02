using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string playGameLevel;
	public GameObject tutorialMenu;
	public GameObject aboutMenu;

	public void PlayGame()
	{
		Application.LoadLevel (playGameLevel);		
	}

	// Nhap Quit Game
	public void QuitGame()
	{
		Application.Quit ();
	}

	public void Tutorial()
	{
		tutorialMenu.SetActive(true);
	}

	public void turnOffTutorial()
	{
		tutorialMenu.SetActive(false);
	}

	public void About()
	{
		aboutMenu.SetActive(true);
	}

	public void turnOffTAbout()
	{
		aboutMenu.SetActive(false);
	}
}
