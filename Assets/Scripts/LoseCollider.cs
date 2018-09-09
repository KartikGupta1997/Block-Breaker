using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager gameover; //gameover is the instance name for LevelManager function

    void OnTriggerEnter2D(Collider2D trigger) {
        print("Trigger");
        Brick.breakableCount = 0;//resets the breakableCount to 0 so that when we 
                                //lose and play again, breakableCount is recalculated
        gameover.LoadLevel("Lose screen"); // loads the win screen when the ball passes through the rectangular trigger
    }

    void OnCollisionEnter2D(Collision2D collision) {
        print("Collider");
    }
	// Use this for initialization
	void Start () {
        gameover = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
