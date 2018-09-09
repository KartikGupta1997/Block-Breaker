using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public AudioSource crackSound;
    private int timesHit;
    public static int breakableCount = 0;
    private LevelManager levelmanager;
    public Sprite[] hitSprites;
    private bool isBreakable;
    public GameObject smoke;

    void OnCollisionEnter2D(Collision2D collision)
    {   
       
        if (isBreakable) {
            HandleHits();
        }
    }
    void HandleHits() {
        timesHit++;
        
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            print("breakableCount decrement " + breakableCount);
            levelmanager.brickDestroyed();
            GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }
    //TODO Remove this method once we can actually win
    void SimulateWin() {
        levelmanager.LoadNextLevel();
    }

    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else {
            Debug.LogError("Bricks missing");
        }
        
    }
    // Use this for initialization
    void Start () {     

        isBreakable = (this.tag == "Breakable");
        //Keep track of the breakable bricks
        if (isBreakable) {
            breakableCount++;
            print("breakableCount increment " + breakableCount);
        }
        timesHit = 0;
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        
    }

	
	// Update is called once per frame
	void Update () {

     
    }
	}
