using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float jump;
	public float playerGravity;

	bool canJump;

	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		canJump = false;
	}

	// Update is called once per frame
	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		transform.Translate (speed * moveHorizontal, 0f, speed * moveVertical);
	}

	void FixedUpdate () 
	{
		/*float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * speed);*/

		Vector3 downF = new Vector3 (0.0f, playerGravity, 0.0f);
		rb.AddForce(downF);

		if(Input.GetKey("space") && canJump)
		{
			Vector3 jumpVec = new Vector3 (0.0f, jump, 0.0f);
			rb.AddForce (jumpVec, ForceMode.Impulse);
			canJump = false;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("platform"))
		{
			canJump = true;
		}
	}
}
