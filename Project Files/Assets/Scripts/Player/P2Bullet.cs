using UnityEngine;
using System.Collections;

public class P2Bullet : MonoBehaviour {

	//Player 2 projectile stats

	public int damage = 0; //Damage done to the other players health

    // Reference to the player healthbar (Michael)
    private GameObject healthBar;

    void Start()
    {
        GetComponent<Audio>().PlaySound(0);
        healthBar = GameObject.Find("P1 Greenbar"); // Searches gameobjects for the health bar (Michael)
    }

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.layer == 9) 
		{
			Debug.Log ("P1 Hit");
            Player1Move player1move = col.gameObject.GetComponent<Player1Move>();
            player1move.playerhealth -= damage;
            healthBar.GetComponent<RectTransform>().sizeDelta = new Vector3((player1move.playerhealth * 590 / 100), 50); // Adjusts the healthbar rect size to mathch player health percentage (Michael)
            Destroy (this.gameObject);
            //GetComponent<Audio>().PlaySound(1);
        }
        if (col.gameObject.layer == 12)
        {
            Destroy(this.gameObject);
        }
    }
}
//Steven, Matthew & Micheal
