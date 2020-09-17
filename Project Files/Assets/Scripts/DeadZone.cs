using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour {

	//Reset zone if character somehow falls out of map

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
//Reused script