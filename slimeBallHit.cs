using UnityEngine;
using System.Collections;

public class slimeBallHit : MonoBehaviour {
	public float weaponDamage;

	ProjectilController myPC;

	public GameObject explosionEffect;

	// Use this for initialization
	void Awake () {
		myPC = GetComponentInParent<ProjectilController> ();


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer==LayerMask.NameToLayer ("Shootable")) {
			myPC.RemoveForce();
			Instantiate(explosionEffect,transform.position, transform.rotation);
			Destroy(gameObject);

		}
		if (other.gameObject.layer==LayerMask.NameToLayer ("Ground")) {
			myPC.RemoveForce();
			Instantiate(explosionEffect,transform.position, transform.rotation);
			Destroy(gameObject);

		}

		}
	void OnTriggerStay2D(Collider2D other) 
	{
		if (other.gameObject.layer==LayerMask.NameToLayer ("Shootable")) {
			myPC.RemoveForce();
			Instantiate(explosionEffect,transform.position, transform.rotation);
			Destroy(gameObject);
			Destroy (other.gameObject);
		}
}
}