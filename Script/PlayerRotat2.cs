using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotat2 : MonoBehaviour
{
    public float rotY;
    public static bool iswalk = false;
    //public GameObject playerCube;
    //public float rotX;
    // Use this for initialization
    /*void Start () {
	
	}*/

    // Update is called once per frame
    void Update()
    {
        //if (iswalk)
        //{
            rotY += Input.GetAxis("Mouse X") * 150.0f * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, rotY, 0f);
       // }
        
        

    }
}
