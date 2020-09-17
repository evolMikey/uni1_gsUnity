using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player2Move : MonoBehaviour {

	//Player 2 movement, interactions and stats

    public float Hspeed = 0f; // horizontal speed of the character -s
    public float vspeed = 0f; // vertical speed of the character -s
    private float hmove = 0f; // Horizontal Movement -s
    //private float vmove = 0f; // vertical movement -s
    private float MDistance;
    public float maxMDistance = 15f; // max range of melee attack -s
    public int playerhealth = 100;
	public int score = 0;
    public int Mdamage;   // Melee Damage -s
    public int Rdamage;   // Ranged Damage -s
    public float MRate = 0.5f; // Melee Swing Rate -s
    public float nextswing = 0.5f; // Next melee swin -s
	public float RRate = 0.5f;     // Ranged fire rate -s
	public float nextshot = 1f;  // Next ranged shot -s
    //public bool facingright = true; // is the character facing right -s
    public bool pcaster;  // checks if the player has picked up the pcaster -s
    public LayerMask groundlayer; // creates a layer mask for the ground layer
	public LayerMask treelayer;
	public Transform P2ProSpawner;
	public bool facingRight = false;


    public Text winscoretext;
    public Text wintimetext;
    //GameObject[] gameWinObjects;  // array to hold the objects on game win

    //private SpriteRenderer spriterenderer; 
	//private SpriteRenderer slashrender;


    public GameObject Projectile;



    
    Rigidbody2D rb;
    Rigidbody2D rb3;




    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "pickup")
        {
            score = score + 10;
            Debug.Log("score +10");
            Destroy(other.gameObject);
        }
    


    }


    bool isgrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 2.5f;

        RaycastHit2D groundhit = Physics2D.Raycast(position, direction, distance, groundlayer);         //raycast to detect if player is grounded
        if (groundhit.collider != null)
        {
            return true;

        }
        return false;

    }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();    // gets the character rigidbody -s
       // rb3 = GetComponentInChildren<Rigidbody2D>();
        //spriterenderer = GetComponent<SpriteRenderer>(); // gets the spriterenderer in the player character -s 
		//slashrender = GetComponentInChildren<SpriteRenderer>(); // gets the sprite renderer in the child of the character
    }

    //public void showgameover()
    //{
    //    foreach (GameObject g in gameWinObjects)
    //    {
    //        g.SetActive(true);

    //    }
    //}
        // Update is called once per frame
        void Update () {
        hmove = Input.GetAxis("P2Horizontal"); // hmove is the horizontal axis of movement -s
        //vmove = Input.GetAxis("P2Vertical"); // vmove is the vertical axis of movement -s
                                           // rb.velocity = new Vector2(Hspeed * hmove, vspeed * vmove);

        if (playerhealth <= 0)
        {
            ScoreKeeper scorekeeper = GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>();
            CharSpawner charspawner = GameObject.Find("Character Spawner").GetComponent<CharSpawner>();
            scorekeeper.addP1Score(1);
            charspawner.Player2Spawner();
            Destroy(this.gameObject);
        }
      


  //      if (score > 160)
  //      {
  //          SceneManager.LoadScene(4);

  //      }


  //      if (winscoretext != null)
  //      {
		//	winscoretext.text = ("score:" + GameObject.Find("CharacterP").GetComponent<Player1Move>().score.ToString());   // seets the text object to show the score
  //      }

  //      if (rb.transform.position.y < -26)
		//{
		//	SceneManager.LoadScene (3);
		//}

		if ((Input.GetKey(KeyCode.LeftArrow)))
        {
            //facingright = false;                               // changes the facingright bool to false because the character is facing left -s
            //spriterenderer.flipX = true;                       // flips the sprite -s
            rb.velocity = new Vector2(Hspeed * hmove, rb.velocity.y);  // moves the character left  because hmove is less than 0  -s
         //   Debug.Log(hmove);
            
        }
		if ((Input.GetKey(KeyCode.RightArrow)))
        {
            //facingright = true;
            //spriterenderer.flipX = false;  // flips the sprite renderer

            rb.velocity = new Vector2(Hspeed * hmove,rb.velocity.y);    //moves the character right because Hmove is above 0   -s
          //  Debug.Log(hmove);

        }
		if ((Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (!isgrounded())
            {
                return;
            }
            else
            { 
            rb.velocity = new Vector2(rb.velocity.x, vspeed);   // allows the player to jump   -s
          //  Debug.Log(vmove);
        }



        }



		if (Input.GetKey(KeyCode.RightShift) && (Time.time > nextshot))
            {

			nextshot = Time.time + RRate;

            Ranged();  // calls the ranged function
         

        }
		if (hmove > 0 && !facingRight)
			Flip ();
		else if (hmove < 0 && facingRight)
			Flip ();

    }

	void Flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;

		transform.localScale = theScale;
	}

   public void Ranged(){
        GameObject clone;
		if (facingRight) {
			
			clone = (GameObject)Instantiate (Projectile, P2ProSpawner.position, P2ProSpawner.rotation) as GameObject;     // instantiates the Projectile prefab object at the pla ers position -s
			Projectile.GetComponent<SpriteRenderer>().flipX=true; 
			Debug.Log ("Projectile Spawned");
			clone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (50f, 0f);  // adds velocity to the rigidbody of the prefabs -s
		} else {
			//if clone.GetComponent<BoxCollider2D
			clone = (GameObject)Instantiate (Projectile, P2ProSpawner.position, transform.rotation) as GameObject;     // instantiates the Projectile prefab object at the pla ers position -s
			Projectile.GetComponent<SpriteRenderer>().flipX=false; 
			Debug.Log ("Projectile Spawned");
			clone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-50f, -0f);     // adds velocity to the rigidbody of the prefab firing it to the left -s



		}
		Destroy (clone, 2);    // destroys the projectile fired from the character. -s
    }
    public void Melee()
    {


    }
}
//Steven & Matthew
