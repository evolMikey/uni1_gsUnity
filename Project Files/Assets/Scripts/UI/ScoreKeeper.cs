using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	//Keeps track of score, when to add points and who wins at the end of the round

    public Text P1ScoreText;
    public Text P2ScoreText;
    public GameObject EndTimeUI;
    public GameObject P1WinUI;
    public GameObject P2WinUI;
    public GameObject TieUI;

    int P1Score;
    int P2Score;

	//Reset score at the start of a round
    void Start ()
    {
        P1Score = 0;
        P2Score = 0;
        P1ScoreText.text = "" + P1Score;
        P2ScoreText.text = "" + P2Score;

        EndTimeUI.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<PauseMenu>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = (false);
        //CursorLockedVar = (true);
        Time.timeScale = 1;
    }

	//Add point to player 1 score
    public void addP1Score (int P1ScoreAdded)
    {
        P1Score += P1ScoreAdded;
        P1ScoreText.text = "" + P1Score;
    }

	//Add point to player 2 score
    public void addP2Score(int P2ScoreAdded)
    {
        P2Score += P2ScoreAdded;
        P2ScoreText.text = "" + P2Score;
    }

	//Find out who won and display the right ui
    public void EndScore ()
    {
        EndTimeUI.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<PauseMenu>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = (true);
        //CursorLockedVar = (false);
        Time.timeScale = 0;

        if (P1Score > P2Score)
        {
            P1WinUI.SetActive(true);
            P2WinUI.SetActive(false);
            TieUI.SetActive(false);
        }
        if (P1Score < P2Score)
        {
            P1WinUI.SetActive(false);
            P2WinUI.SetActive(true);
            TieUI.SetActive(false);
        }
        if (P1Score == P2Score)
        {
            Debug.Log("Tie");
            P1WinUI.SetActive(false);
            P2WinUI.SetActive(false);
            TieUI.SetActive(true);
        }
    }
}
//Matthew