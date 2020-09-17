using UnityEngine;
using System.Collections;

public class P1Bullet : MonoBehaviour {

	//Player 1 projectile stats

	public int damage = 0; //Damage done to the other players health

    // Reference to the player healthbar (Michael)
    private GameObject healthBar;

    void Start()
    {
        GetComponent<Audio>().PlaySound(0);
        healthBar = GameObject.Find("P2 Greenbar"); // Searches gameobjects for the health bar (Michael)
    }

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.layer == 10) 
		{
			Debug.Log ("P2 Hit");
            Player2Move player2move = col.gameObject.GetComponent<Player2Move>();
            player2move.playerhealth -= damage;
            healthBar.GetComponent<RectTransform>().sizeDelta = new Vector3((player2move.playerhealth * 590 / 100), 50); // Adjusts the healthbar rect size to mathch player health percentage (Michael)
            Destroy (this.gameObject);
            //GetComponent<Audio>().PlaySound(1);
        }
        if (col.gameObject.layer == 13)
        {
            Destroy(this.gameObject);
        }
    }
}
//Steven, Matthew & Micheal