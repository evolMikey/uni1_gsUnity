using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEAL : MonoBehaviour
{

    //public GameObject Player;
    public int HealthIncrease; //Health added to player

    bool heathlock;

    private GameObject P1healthBar;
    private GameObject P2healthBar;

    void Start()
    {
        heathlock = false;
        P1healthBar = GameObject.Find("P1 Greenbar"); // Searches gameobjects for the health bar
        P2healthBar = GameObject.Find("P2 Greenbar"); // Searches gameobjects for the health bar
    }

	public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 10 && heathlock == false)
        {
            GameObject.Find("SoundEffects").GetComponent<Audio>().PlaySound(0);
            Player2Move player2move = col.gameObject.GetComponent<Player2Move>();
            player2move.playerhealth += HealthIncrease;
            if (player2move.playerhealth == 100)
            {
                P2healthBar.GetComponent<RectTransform>().sizeDelta = new Vector3((player2move.playerhealth * 590 / 100), 50); // Adjusts the healthbar rect size to mathch player health percentage
            }
            Destroy(this.gameObject);

        }
        if (col.gameObject.layer == 9 && heathlock == false)
        {
            GameObject.Find("SoundEffects").GetComponent<Audio>().PlaySound(0);
            Player1Move player1move = col.gameObject.GetComponent<Player1Move>();
            player1move.playerhealth += HealthIncrease;
            if (player1move.playerhealth == 100)
            {
                P1healthBar.GetComponent<RectTransform>().sizeDelta = new Vector3((player1move.playerhealth * 590 / 100), 50); // Adjusts the healthbar rect size to mathch player health percentage
            }
            Destroy(this.gameObject);

        }
    }
}
//Mike