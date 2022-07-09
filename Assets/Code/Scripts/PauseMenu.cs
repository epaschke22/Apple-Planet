using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private GlobalData globalData;
	[SerializeField] private GameObject pauseMenuUI;
    private bool GameIsPaused = false;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Restart()
	{
		Resume();
		globalData.isPlayerAlive = true;
		globalData.isWormAlive = true;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Mainmenu()
	{
		Resume();
		SceneManager.LoadScene("MainMenu");
	}
}
