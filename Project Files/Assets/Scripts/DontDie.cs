using UnityEngine;
using System.Collections;

public class DontDie : MonoBehaviour {

	//Don't destroy gameobject of scene load

	void Awake () 
	{
		DontDestroyOnLoad (this.gameObject);
	}
}
//Reused script