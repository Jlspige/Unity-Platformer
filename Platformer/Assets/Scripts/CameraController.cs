using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public Vector3 cameraOffset; //default camera distance from the player


	public float rotateSpeed = 0.0000000000000005f;
	private Vector3 offset;
	private Vector3 offsetGround;
	private Vector3 offsetAir;
	private Vector3 newOffset;
	private Vector3 newOffsetGround;
	private Vector3 newOffsetAir;
	public float damping;

	// Use this for initialization
	void Start () 
	{
		//cam = this.GetComponent<Camera> ();
		//cameraOffset = new Vector3 (0f, 6.4f, -18.9f);
		//cameraOffset = new Vector3 (0f, 10.0f, -20.0f);
		offset = target.transform.position - transform.position;
		offsetGround = offset;
		offsetGround.y = 0;
	}

	void LateUpdate()
	{
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);
		/*newOffset = target.transform.position - transform.position;
		newOffsetGround = newOffset;
		newOffsetGround.y = 0;
		//If the player gets too far away from the camera, follow it
		if(newOffsetGround.magnitude > offsetGround.magnitude)
		{
			Vector3 newPosition = transform.position;
			//newPosition.x += (newOffsetGround.x - offsetGround.x);
			//newPosition.z += (newOffsetGround.z - offsetGround.z);
			newPosition.x += newOffsetGround.x;
			newPosition.z += newOffsetGround.z;
			//newPosition = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 7.5f);
			newPosition = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
			transform.position = newPosition;
		}*/
		/*if(newOffsetGround.magnitude < offsetGround.magnitude * 0.5)
		{
			Vector3 newPosition = transform.position;
			newPosition.x -= (newOffsetGround.x - offsetGround.x);
			newPosition.z -= (newOffsetGround.z - offsetGround.z);
			newPosition = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 7.5f);
			transform.position = newPosition;
		}*/

		transform.LookAt(target.transform);


		//code for look at
		/*Vector3 targetXZ = target.transform.position;
		targetXZ.y = 0;
		transform.LookAt(targetXZ);*/

		//transform.rotation = Quaternion.LookRotation (newOffset, new Vector3(0, 1, 0));
	}
}
