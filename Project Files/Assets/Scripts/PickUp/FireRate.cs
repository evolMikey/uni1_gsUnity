using UnityEngine;
using System.Collections;

public class FireRate : MonoBehaviour {


    public int PowerupLength; //Duration of pickup power
    public float FMultiply; //Fire rate boost number
    float normalFrate = 0.5f; //Return fire rate to normal

    private Player1Move player1move;
    private Player2Move player2move;


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 9)
        {
            GameObject.Find("SoundEffects").GetComponent<Audio>().PlaySound(0);
            player1move = col.gameObject.GetComponent<Player1Move>();
            StartCoroutine(P1FR_Powerup());
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        if (col.gameObject.layer == 10)
        {
            GameObject.Find("SoundEffects").GetComponent<Audio>().PlaySound(0);
            player2move = col.gameObject.GetComponent<Player2Move>();
            StartCoroutine(P2FR_Powerup());
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

    }
    
    IEnumerator P1FR_Powerup()
    {
        player1move.RRate = FMultiply;
        yield return new WaitForSeconds(PowerupLength);
        player1move.RRate = normalFrate;
    }

    IEnumerator P2FR_Powerup()
    {
        player2move.RRate = FMultiply;
        yield return new WaitForSeconds(PowerupLength);
        player2move.RRate = normalFrate;
    }
}
//Ryan