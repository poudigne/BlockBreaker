using UnityEngine;	
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		hasStarted = false;
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
		} 

		if (Input.GetMouseButtonDown (0)) {
			this.rigidbody2D.isKinematic = false;
			this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			hasStarted =true;
		}
	}
	void OnCollisionEnter2D(Collision2D other){
    Vector2 tweak = new Vector2(Random.Range(0f,0.2f),Random.Range(0f, 0.2f));
		if (hasStarted) {
			audio.Play ();
      this.rigidbody2D.velocity += tweak;
		}
	}
}
