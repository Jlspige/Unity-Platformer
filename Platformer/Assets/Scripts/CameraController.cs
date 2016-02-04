using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float rotateSpeed = 0.0000000000000005f;
	private Vector3 offset;
	private Vector3 newOffset;
	public float damping = 1;

	// Use this for initialization
	void Start () 
	{
		offset = target.transform.position - transform.position;
	}

	void LateUpdate()
	{
		if (Input.GetMouseButton(0)) //For manually setting the camera angle with the mouse
		{
			/*//offset = target.transform.position - transform.position;
			float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
			float vertical = Input.GetAxis ("Mouse Y") * rotateSpeed;
			target.transform.Rotate (0, horizontal, 0);

			float desiredAngle = target.transform.eulerAngles.y;
			Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);
			transform.position = target.transform.position - (rotation * offset);

			transform.LookAt (target.transform);*/
		}
		/*else
		{
			float currentAngle = transform.eulerAngles.y;
			float desiredAngle = target.transform.eulerAngles.y;
			float angle = Mathf.LerpAngle (currentAngle, desiredAngle, Time.deltaTime * damping);

			Quaternion rotation = Quaternion.Euler (0, angle, 0);
			transform.position = target.transform.position - (rotation * offset);

			transform.LookAt (target.transform);
		}*/
		else
		{
			//transform.position = target.transform.position + offset;
			transform.LookAt(target.transform);
		}
	}
}
