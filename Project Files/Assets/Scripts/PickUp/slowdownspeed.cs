using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowdownspeed : MonoBehaviour
{
	//This script was not used
    public int PowerupLength; //Duration of pickup power
    public float slowTimeSpeed = 0.5f; //Amount of slowdown
    float normalTimeScale = 1f; //Number of original speed

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 9 || col.gameObject.layer == 10)
        {
            StartCoroutine(Time_Powerup());
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);

        }
    }

    IEnumerator Time_Powerup()
    {
        Time.timeScale = slowTimeSpeed;
        yield return new WaitForSeconds(PowerupLength);
        Time.timeScale = normalTimeScale;
    }
}
//Mike