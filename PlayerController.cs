using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//movement variables
	public float maxSpeed;
	Rigidbody2D myRB;
	Animator myAnim;
//also helps with shooting
	bool facingRight;

	//for shooting
	public Transform slimeTip;
	public Transform mortarTip;
	public GameObject MortarBall;
	public GameObject SlimeBall;
	private float fireRate = 0.5f;
	private float nextFire = 0f;


	//jumping variables
	private bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;
	// for jump pad
	public float jumpPadStrength;

	//for special shooting
	public Slider UniversalAmmoBar;
	public static int UniversalAmmo = 100;


	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();

		facingRight = true;


	}
	void Update (){
		if (grounded && Input.GetAxis ("Jump") > 0) {
			grounded = false;
			myAnim.SetBool("isGrounded",grounded);
			myRB.AddForce(new Vector2(0, jumpHeight));


		}
		//player shooting
		if (Input.GetAxisRaw ("Fire1") > 0)
			fireSlimeBall ();
		if (Input.GetAxisRaw ("Fire2") > 0)
			fireMortar ();


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		//check if we are grounded if no then we are falling
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool ("isGrounded", grounded);
		myAnim.SetFloat ("verticalSpeed", Mathf.Abs (move));


		
		myAnim.SetFloat ("speed", Mathf.Abs (move));
		myRB.velocity = new Vector2 (move * maxSpeed, myRB.velocity.y);

		if (move > 0 && !facingRight) {
			flip ();
		} else if (move<0&&facingRight) {
			flip();
		}
	}

	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void fireSlimeBall(){
		if(Time.time> nextFire) {
			nextFire = Time.time + fireRate;

			if(facingRight){
				Instantiate( SlimeBall, slimeTip.position, Quaternion.Euler (new Vector3 (0,0, 0)));
			}
			else if (!facingRight) {
				Instantiate( SlimeBall, slimeTip.position, Quaternion.Euler (new Vector3 (0,0,180f)));


			}

		}
	}
	void fireMortar(){
		if(Time.time> nextFire && UniversalAmmo > 5) {
			nextFire = Time.time + fireRate;
			if(facingRight){
			Instantiate( MortarBall, mortarTip.position, Quaternion.Euler (new Vector3 (0,0,90)));
			}
			else if (!facingRight) {
				Instantiate( MortarBall, mortarTip.position, Quaternion.Euler (new Vector3 (0,0,90f)));
			}
			UniversalAmmo = UniversalAmmo - 5;
				UniversalAmmoBar.value = UniversalAmmo;
		}
	}
	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "smallMana" && UniversalAmmo <= 85) {
			UniversalAmmo = UniversalAmmo + 15;
			UniversalAmmoBar.value = UniversalAmmo;
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "smallMana" && UniversalAmmo > 85) {
			UniversalAmmo = 100;
			UniversalAmmoBar.value = UniversalAmmo;
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag == "jumpPad") {
			grounded = false;
			myAnim.SetBool("isGrounded",grounded);
			myRB.AddForce(new Vector2(0, jumpHeight * jumpPadStrength));


		}
	}
}