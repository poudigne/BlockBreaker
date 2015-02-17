using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
    Brick.brickCount = 0;
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel +1 );
	}

	public void BrickDestroyed(){
		print (Brick.brickCount);
		if (Brick.brickCount <= 0) {
			LoadNextLevel();
		}
	}
}
