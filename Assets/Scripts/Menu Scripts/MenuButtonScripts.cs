using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScripts : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene("SampleScene");
		Time.timeScale = 1;
	}

	public void GoToSettingsMenu()
	{
		SceneManager.LoadScene("SettingsMenu");
	}

	public void GoToStore()
	{
		SceneManager.LoadScene("Store");
	}

	public void GoToMainMenu()
	{
		SceneManager.LoadScene("Menu");
		Time.timeScale = 1;
	}

	public void QuitGame()
	{
		print("Quit Game");
		Application.Quit();
	}
}
