using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthControl2 : MonoBehaviour {

	//Have current health of player change the health bar

	public GameObject HealthBar; //Healtbar object
	public float MaxHealth; //Max health
	public float CurrentHealth; //Current health
	public GameObject Canvas; //UI canvas
	public GameObject DeathCanvas;

	// Use this for initialization
	void Awake () {
		CurrentHealth = MaxHealth;
		//InvokeRepeating("DecreaseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        
    }
	//void DecreaseHealth() {
	void OnCollisionEnter2D(Collision2D coll){ //Collider
		if (coll.gameObject.tag == "Pro1") //Anything with Enemy tag
		CurrentHealth -= 10f; //Removes -2 from current health
		if (CurrentHealth <= 0f)
		Canvas.SetActive (true); //Enables canvas on 0 health
		if (CurrentHealth <= 0f)
			Destroy (GameObject.FindWithTag("Player")); //Destroys objects tagged player
		if (CurrentHealth <= 0f)
			DeathCanvas.SetActive (false);
			//Application.LoadLevel ("Level");
			//CurrentHealth = 0f;
		float calc_Health = CurrentHealth / MaxHealth;
		SetHealthBar (calc_Health); //Sets healthbar accordingly
        Debug.Log("Player 2 hurt");
	}

	public void SetHealthBar(float Health)
    {
		HealthBar.transform.localScale = new Vector3 (Health, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z); //Sets the scale of the healthbar
	}
}
//Konnor, Matthew & Michael