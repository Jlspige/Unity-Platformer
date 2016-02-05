using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float speed2;
	public float jump;
	public float playerGravity;

	bool canJump;

	private Rigidbody rb;

	//public Camera viewCamera;

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
		Vector3 movement = new Vector3(0f, 0f, speed2 * moveVertical);
		transform.Translate (movement);

		Vector3 R = Camera.main.transform.position - transform.position;
		Vector3 V = new Vector3(speed2 * moveHorizontal, 0f, 0f);
		float w = 180 * V.magnitude / (Mathf.PI * R.magnitude);
		if(moveHorizontal > 0)
		{
			transform.RotateAround (Camera.main.transform.position, Vector3.up, w * 1);
		}
		else
		{
			transform.RotateAround (Camera.main.transform.position, Vector3.up, w * -1);
		}

		//Code to make player face travel direction
		//transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
		//change Vector3.forward to direction of travel after it's found using the code below






		/*float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3(0.5f * moveHorizontal, 0f, 0.5f * moveVertical);
		transform.LookAt(transform.position + movement);
		transform.Translate (movement);*/

		/*//Code for movement relative to the camera
		//Get the z and x unit vectors of the camera
		Vector3 cameraForward = Camera.main.transform.forward;
		Vector3 cameraRight = Camera.main.transform.right;
		Vector3.Normalize (cameraForward);
		Vector3.Normalize (cameraRight);
		//Get the input from keyboard controls
		float moveVertical = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		//Combine vectors and eliminate y axis movement
		cameraForward = cameraForward * moveVertical;
		cameraForward.y = 0;
		cameraRight = cameraRight * moveHorizontal;
		cameraRight.y = 0;
		//transform.Translate(cameraForward);
		//transform.Translate (cameraRight);
		Vector3 movement = cameraForward + cameraRight;
		transform.Translate (movement);
		Vector3.Normalize (movement);*/
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
