using UnityEngine;
using System.Collections;

public class PlayerRotat : MonoBehaviour {

	public float rotY;
	//public GameObject playerCube;
	//public float rotX;
	// Use this for initialization
	/*void Start () {
	
	}*/
	
	// Update is called once per frame
	void Update () {
		rotY += Input.GetAxis ("Mouse X")* 100.0f * Time.deltaTime;
		transform.rotation = Quaternion.Euler (0f, rotY, 0f);
		//Transform target = playerCube.transform;
		//float step = 20f * Time.deltaTime;
		//transform.position = target.position;
	
	}
}