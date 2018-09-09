using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

public void LoadLevel(string name){
	Debug.Log("Level requested:" + name);
	SceneManager.LoadScene(name);
	}
	public void QuitRequest()
	{
	Debug.Log ("I want to quit the game!");
	}
    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    public void brickDestroyed() {
        if (Brick.breakableCount<=0) {
            LoadNextLevel();
        }
    }
}

