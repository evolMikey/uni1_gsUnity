using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	//Change between menu canverses and load scenes on button presses

	public GameObject MainMenu;
	public GameObject MapSelect;
	public GameObject ControlsMenu;
	public Button startText;
	public Button controls;
	public Button back;
	public Button exitText;

	void Start () 
	{
		startText = startText.GetComponent<Button> (); //Get button from inspector
		controls = controls.GetComponent<Button> ();
		back = back.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> (); //Get button from inspector
		Cursor.lockState = CursorLockMode.None; //Free cursor
		Cursor.visible = (true); //See cursor
		MainMenu.SetActive (true);
		MapSelect.SetActive (false);
		ControlsMenu.SetActive (false);
	}

	public void StartLevel()
	{
		MainMenu.SetActive (false);
		MapSelect.SetActive (true);
		ControlsMenu.SetActive (false);
	}

	public void Controls()
	{
		MainMenu.SetActive (false);
		MapSelect.SetActive (false);
		ControlsMenu.SetActive (true);
	}

	//Able to set which scene number to load in inspector
	public void Map(int levelnum)
	{
		SceneManager.LoadScene (levelnum);
	}

	public void Back()
	{
		MainMenu.SetActive (true);
		MapSelect.SetActive (false);
		ControlsMenu.SetActive (false);
	}

	public void ExitGame()
	{
		Application.Quit (); //Close application
		Debug.Log ("Exit");
	}
}
//Matthew