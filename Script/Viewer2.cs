using UnityEngine;
using System.Collections;

public class Viewer2 : MonoBehaviour {
	public float CameraMoveSpeed = 120.0f;
	//public GameObject CameraObjfollow;
	//public GameObject ExoRedFollow;
	public Vector3 rot;
	public float rotX;
	public float rotY;
	public float ClamAngle=35.0f;


	// Use this for initialization
	void Start () {
		rot = transform.localRotation.eulerAngles;
		rotX = rot.x;
		rotY = rot.y;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Mouse Y");
		float z = Input.GetAxis ("Mouse X");
		rotX += x * 100.0f * Time.deltaTime * -1f;
		rotY += z * 100.0f * Time.deltaTime;
		rotX = Mathf.Clamp (rotX, -ClamAngle, ClamAngle);
		//rotY = Mathf.Clamp (rotY, -ClamAngle, ClamAngle);
		//Debug.Log (rotX + " "+rotY);
		Quaternion localRotation =  Quaternion.Euler(rotX,rotY,0.0f);
		transform.rotation = localRotation;

	}

	//void FixedUpdate(){
		//camUp ();
	//}

	/*void camUp(){
			//Transform target = CameraObjfollow.transform;
			//float step = CameraMoveSpeed * Time.deltaTime;
			//transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}*/
}
