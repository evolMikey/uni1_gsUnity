using UnityEngine;
using System.Collections;
using System;

public class CharacterSelect : MonoBehaviour {

	//Be able to select which character to play at the start of a round

    public GameObject CharSelectUi; //Able to get UI parent
    public Transform P1Spawn; //P1 spawn point
	public Transform P2Spawn; //P2 spawn point
    public GameObject P1Character1;
    public GameObject P1Character2;
    public GameObject P1Character3;
    public GameObject P2Character1;
    public GameObject P2Character2;
    public GameObject P2Character3;
    public bool P1Lock;
    public bool P2Lock;

    void Start ()
    {
        CharSelectUi.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<PauseMenu>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = (true);
        //CursorLockedVar = (false);
        Time.timeScale = 0;
        P1Lock = false;
        P2Lock = false;
    }

	//Button that starts the round only when two characters have been selected
    public void Ready()
    {
        if (P1Lock == true && P2Lock == true)
        {
            CharSelectUi.SetActive(false);
            GameObject.Find("Main Camera").GetComponent<PauseMenu>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);
            //CursorLockedVar = (true);
            Time.timeScale = 1;
        }
    }
		
    public void P1Char1()
    {
        if (P1Lock == false)
        {
            Instantiate (P1Character1, P1Spawn.position, P1Spawn.rotation);
            P1Lock = true;
			CharSpawner charspawner = GameObject.Find("Character Spawner").GetComponent<CharSpawner>();
			charspawner.P1Char1 = true;
        }
    }

    public void P1Char2()
    {
        if (P1Lock == false)
        {
			Instantiate(P1Character2, P1Spawn.position, P1Spawn.rotation);
            P1Lock = true;
			CharSpawner charspawner = GameObject.Find("Character Spawner").GetComponent<CharSpawner>();
			charspawner.P1Char2 = true;
        }
    }
    public void P1Char3()
    {
        if (P1Lock == false)
        {
			Instantiate(P1Character3, P1Spawn.position, P1Spawn.rotation);
            P1Lock = true;
			CharSpawner charspawner = GameObject.Find("Character Spawner").GetComponent<CharSpawner>();
			charspawner.P1Char3 = true;
        }
    }
    public void P2Char1()
    {
        if (P2Lock == false)
        {
			Instantiate(P2Character1, P2Spawn.position, P2Spawn.rotation);
            P2Lock = true;
			CharSpawner charspawner = GameObject.Find("Character Spawner").GetComponent<CharSpawner>();
			charspawner.P2Char1 = true;
        }
    }
    public void P2Char2()
    {
        if (P2Lock == false)
        {
			Instantiate(P2Character2, P2Spawn.position, P2Spawn.rotation);
            P2Lock = true;
			CharSpawner charspawner = GameObject.Find("Character Spawner").GetComponent<CharSpawner>();
			charspawner.P2Char2 = true;
        }
    }
    public void P2Char3()
    {
        if (P2Lock == false)
        {
			Instantiate(P2Character3, P2Spawn.position, P2Spawn.rotation);
            P2Lock = true;
			CharSpawner charspawner = GameObject.Find("Character Spawner").GetComponent<CharSpawner>();
			charspawner.P2Char3 = true;
        }
    }
}
//Matthew