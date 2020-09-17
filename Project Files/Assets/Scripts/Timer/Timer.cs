using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	//Time untill round end

	public float countdown;
	public GameObject EndTimeUI;
    public GameObject ScoreKeeper;

	void Start () 
	{
		EndTimeUI.SetActive (false);
	}
	
	void Update () 
	{
		countdown -= Time.deltaTime;
		TextTimer.time = countdown;

		if (countdown < 0) 
		{
            ScoreKeeper scorekeeper = GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>();
            scorekeeper.EndScore(); //Call the score keeper script to display game over Ui
		}
	}
}
//Matthew