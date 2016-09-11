using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D myRigidBody;

	private bool moving;

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;

	private Vector3 moveDirection; 

	public float waitToReload; 
	private bool reloading;
	private GameObject thePlayer; 


	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> (); 

		timeBetweenMoveCounter = timeBetweenMove;
		timeToMoveCounter = timeToMove;

	
	}
	
	// Update is called once per frame
	void Update () {

		if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = moveDirection; 

			if(timeToMoveCounter < 0f){
				moving = false; 
				timeBetweenMoveCounter = timeBetweenMove; 
			}

		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = Vector2.zero; 
			if(timeBetweenMoveCounter < 0f) 
			{
				moving = true;
				timeToMoveCounter = timeToMove;

				moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f); 
			}
		}
		if (reloading) {
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				Application.LoadLevel (Application.loadedLevel);
				thePlayer.SetActive (true);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D other) 
	{
		if(other.gameObject.tag == "Player")
		{
			//Destroy (other.gameObject); 
			other.gameObject.SetActive(false);
			reloading = true;
			thePlayer = other.gameObject;
		}
	}
}