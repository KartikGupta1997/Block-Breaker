using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    public bool hasStarted = false;
    private bool hasClicked = false;
    private AudioSource boingSound;
    // Use this for initialization
	void Start () {
        //finds a paddle object at the start of the game. Since there is only one paddle in the scene, the paddle is selected
        //this saves us time of everytime connecting the paddle script to the ball when creating a new level
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        boingSound = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
        //when the boolean is false, this statement executes so that at each frame, the position
        //of the ball is not reset
        if (!hasStarted) {
            this.transform.position = paddleToBallVector + paddle.transform.position;

        }
        //when mouse button is clicked, this statement executes
        if (Input.GetMouseButtonDown(0)) {
            if (!hasClicked)
            {
                print("Mouse button Clicked!");
                hasStarted = true;//this makes the boolean true so that position of ball doesn't reset after each frame
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                hasClicked = true;
                
            }
            }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.1f));

        if (hasStarted)
        {
            boingSound.Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

}
