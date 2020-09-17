using UnityEngine;
using System.Collections;

public class AudioLock : MonoBehaviour {

	//Stop the backgroundmusic from replaying if menu is loaded again

	public GameObject Audio;

	void Awake () 
	{
		GameObject currentAudio = GameObject.FindGameObjectWithTag ("Audio");
		if (currentAudio == null)
		{
			Instantiate (Audio);
		}
	}

}
//Reused script