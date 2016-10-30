using UnityEngine;
using System.Collections;

public class Mortarhit : MonoBehaviour {
	public float weaponDamage;
	
	mortarController myMC;
	
	public GameObject explosionEffect;
	
	// Use this for initialization
	void Awake () {
		myMC = GetComponentInParent<mortarController> ();
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer==LayerMask.NameToLayer ("Shootable")) {
			myMC.RemoveForce();
			Instantiate(explosionEffect,transform.position, transform.rotation);
			Destroy(gameObject);
			
		}
		if (other.gameObject.layer==LayerMask.NameToLayer ("Ground")) {
			myMC.RemoveForce();
			Instantiate(explosionEffect,transform.position, transform.rotation);
			Destroy(gameObject);
			
		}
		
	}
	void OnTriggerStay2D(Collider2D other) 
	{
		if (other.gameObject.layer==LayerMask.NameToLayer ("Shootable")) {
			myMC.RemoveForce();
			Instantiate(explosionEffect,transform.position, transform.rotation);
			Destroy(gameObject);
			Destroy (other.gameObject);
		}
	}
}