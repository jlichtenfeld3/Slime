using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playermanager : MonoBehaviour {

    public static int health = 100;
    public Slider HealthBar;

    private Rigidbody2D myRigidBody;
	private bool reloading;
	public float waittoreload;
	public string leveltoload;
    // Use this for initialization
    void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
    }

	// Update is called once per frame
	void Update () {
		if (reloading)
		{
			waittoreload -= Time.deltaTime;
			if (waittoreload < 0)
			{
				health = 100;
				Application.LoadLevel(leveltoload);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "theEnemy") {
			health = health - 20;
			HealthBar.value = health;
		}
		if (HealthBar.value < 1) {
			reloading = true;
		}
	
		if (other.gameObject.tag == "smallHealth" && HealthBar.value <= 85) {
			health = health + 15;
			HealthBar.value = health;
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "smallHealth" && HealthBar.value > 85) {
			health = 100;
			HealthBar.value = health;
			Destroy (other.gameObject);
		}


	}
}
