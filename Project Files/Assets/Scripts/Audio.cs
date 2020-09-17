using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	public AudioClip[] audioClip;

	public void PlaySound (int clip)
	{
		GetComponent<AudioSource>().clip = audioClip [clip];
		GetComponent<AudioSource>().Play ();
	}
}
//Reused script