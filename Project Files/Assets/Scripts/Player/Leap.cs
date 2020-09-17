using UnityEngine;
using System.Collections;

public class Leap : MonoBehaviour {

	//Unused

    public Rigidbody2D Character;
    public float JumpHeight;
    public float Horizontal;
    GameObject thePlayer;
    Player1Move play1move;


    // Use this for initialization
    void Start () {
        Character = GetComponent<Rigidbody2D>();
        thePlayer = GameObject.Find("Character"); 
        play1move = thePlayer.GetComponent<Player1Move>(); //Refferences the script
    }
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyDown(KeyCode.LeftShift)) //Key bind
		if(play1move.facingRight == true)
                Character.velocity = new Vector3(Horizontal, JumpHeight, 0); //Controls jump height and distance for facing right
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) //Key bind
                if (play1move.facingRight == false) 
                    Character.velocity = new Vector3(-20, JumpHeight, 0); //Controls jump height and distance for facing left
        }
    }
}
//Konnor