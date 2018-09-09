        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    private Ball ball;
    public bool autoPlay = false;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else {
            AutoPlay();
        }

    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);// setting the position of paddle as (x,y,z)
                                                                             //this.transform.position.y means keep the 
                                                                             //value of y coordinate same as the initial value
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;/* taking the position of mouse
                                                                              .x means only x coordinate of mouse position
                                                                              Screen.width is the width of playspace
                                                                              multiply 16 is to get values between 0 and 16
                                                                              because  the playspace is 16 world units*/
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.66f, 15.33f);//makes the position of mouse as position o
        this.transform.position = paddlePos; //this keyword refers to this script. not using it here will
                                             //get the same result

    }

    void AutoPlay() {

        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);// setting the position of paddle as (x,y,z)
                                                                             //this.transform.position.y means keep the 
                                                                             //value of y coordinate same as the initial value
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);//makes the position of mouse as position o
        this.transform.position = paddlePos; //this keyword refers to this script. not using it here will
                                             //get the same result

    }
}
