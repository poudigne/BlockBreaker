using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

  public AudioClip crack;
	public Sprite[] hitSprites;
	public static int brickCount;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");

		// keep track of breakable bricks
		if (isBreakable) {
			brickCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
    AudioSource.PlayClipAtPoint(crack, transform.position);
		// Ball does not trigger sound when brick is destroyed.
		// Not 100% sure why, possibly because brick isn't there.
		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits(){
		if (this.gameObject.tag == "Breakable") {
			timesHit++;
		}
		
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			Destroy (this.gameObject);
			brickCount--;
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
		}
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}

	}
}
