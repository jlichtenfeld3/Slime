using UnityEngine;
using System.Collections;

public class cameraFollow2DPlatformer : MonoBehaviour {
	public Transform target; //what the camera is following
	public float smoothing; //dampening effect that occurs on the camera


	Vector3 offset; //difference between character and camera
	float lowY;  //lowest point the camera can go

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;

		lowY = transform.position.y;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCamPos = target.position + offset;

		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
		if (transform.position.y < lowY)
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

	
	}
}
