using UnityEngine;
using System.Collections;

public class CharSpawner : MonoBehaviour {

	//Respawn character on complete health loss

	public Transform P1Spawn; //P1 Spawn point
	public Transform P2Spawn; //P2 Spawn point
    public bool P1Char1;
    public bool P1Char2;
    public bool P1Char3;
    public bool P2Char1;
    public bool P2Char2;
    public bool P2Char3;

    // References to player health bars (Michael)
    private GameObject healthBar1;
    private GameObject healthBar2;

    void Start ()
    {
        // Sets earlier created gameobjects to the correct healthbars (Michael)
        healthBar1 = GameObject.Find("P1 Greenbar");
        healthBar2 = GameObject.Find("P2 Greenbar");

        P1Char1 = false;
        P1Char2 = false;
        P1Char3 = false;
        P2Char1 = false;
        P2Char2 = false;
        P2Char3 = false;
    }

	//Find currently played character and spawn them again, with full health, on death

    public void Player1Spawner()
    {
        CharacterSelect characterselect = GameObject.Find("Character Select").GetComponent<CharacterSelect>();
        characterselect.P1Lock = false;
        if (P1Char1 == true)
        {
            characterselect.P1Char1();
        }
        if (P1Char2 == true)
        {
            characterselect.P1Char2();
        }
        if (P1Char3 == true)
        {
            characterselect.P1Char3();
        }
        healthBar1.GetComponent<RectTransform>().sizeDelta = new Vector3(590, 50); // Sets player1 healthbar back to max (Michael)
    }

    public void Player2Spawner()
    {
        CharacterSelect characterselect = GameObject.Find("Character Select").GetComponent<CharacterSelect>();
		characterselect.P2Lock = false;
        if (P2Char1 == true)
        {
            characterselect.P2Char1();
        }
        if (P2Char2 == true)
        {
            characterselect.P2Char2();
        }
        if (P2Char3 == true)
        {
            characterselect.P2Char3();
        }
        healthBar2.GetComponent<RectTransform>().sizeDelta = new Vector3(590, 50); // Sets player2 healthbar back to max (Michael)
    }
}
//Matthew & Micheal