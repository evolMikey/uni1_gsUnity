using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTimer : MonoBehaviour {

	//Display countdown on ui

	public static float time;

	public Text text;

	void Start () 
	{
		text = GetComponent <Text> ();
	}
	
	void Update () 
	{
		text.text = time.ToString ("f0"); //Simplifie number to have no numbers over the decinal point
	}
}
//Matthew