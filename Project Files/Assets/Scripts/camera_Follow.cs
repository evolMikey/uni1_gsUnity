using UnityEngine;
using System.Collections;

public class camera_Follow : MonoBehaviour
{
    // Class created by Michael Edmond - S6105173
	//Unused

    public GameObject player1; // Player one
    public GameObject player2; // Player two
    private float dampTime = 1.0f;

    private Vector3 targetPos;
    private Vector3 velocity = Vector3.one;
    public float camDistance;

    // Use this for initialization
    void Start()
    {
        // Sets initial camera position to the middle of both characters
        targetPos = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
        gameObject.transform.position = targetPos;
        camDistance = 15;
    }

    void Update()
    {
        // Finds players, assigns them to variables
        player1 = GameObject.FindWithTag("Player 1");
        player2 = GameObject.FindWithTag("Player 2");


        // Figures out distance between characters
        camDistance = Vector3.Distance(player1.transform.position, player2.transform.position);
        // Sets camera "size" to this distance
        gameObject.GetComponent<Camera>().orthographicSize = (camDistance / 3);
        if (gameObject.GetComponent<Camera>().orthographicSize < 3)
        {
            gameObject.GetComponent<Camera>().orthographicSize = 3;
        }
        if (gameObject.GetComponent<Camera>().orthographicSize > 15)
        {
            gameObject.GetComponent<Camera>().orthographicSize = 15;
        }

        if (camDistance < 10)
        {
            // Constantly sets targetPos to middle of characters, SmoothDamps to targetPos
            targetPos = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);

            // Adjusts camera x position to not go too far off-screen
            if (targetPos.x + camDistance > 15)
            {
                targetPos.x = 10;
            }
            if (targetPos.x - camDistance < 15)
            {
                targetPos.x = -10;
            }
            targetPos.y = -10;

            // SmoothDamp will smoothly translate the camera to the target location
            gameObject.transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dampTime);
        }
        else
        {
            // Sets camera targetPos to middle of world if the distance is too far
            targetPos = Vector3.zero;
            gameObject.transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dampTime);
        }
    }
}
//Michael