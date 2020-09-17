using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUi; //Able to get UI parent

	private bool paused = false; //Toggle pause

	private bool CursorLockedVar; //Toggle cursor lock

	private float CharacterNum;

	void Start () 
	{
		//These set the cursor hidden and locked at start
		PauseUi.SetActive (false);
	}

	void Update (){
		//Toggle menu off
		if (Input.GetButtonDown ("ESC") && !CursorLockedVar) 
		{
			paused = !paused;
		}
		//Toggle menu on
		else if (Input.GetButtonDown ("ESC") && CursorLockedVar) 
		{
			paused = !paused;
		} 
			
		if (paused) 
		{
			PauseUi.SetActive (true);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = (true);
			CursorLockedVar = (false);
			Time.timeScale = 0;
		}

		if (!paused) 
		{
			PauseUi.SetActive (false);
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = (false);
			CursorLockedVar = (true);
			Time.timeScale = 1;
		}
	}
	//Toggle menu off
	public void Resume()
	{
		paused = !paused;
	}
	//Restart level
	public void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	//Load main menu
	public void MainMenu()
	{
		SceneManager.LoadScene (0);
	}
	//Quit game
	public void Quit()
	{
		Application.Quit();
	}
}
//Reused script