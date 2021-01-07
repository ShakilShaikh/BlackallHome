using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CamFolObj;

    public Vector3 pos;

   public float camSpeed = 120.0f;
  /*  public float campAngle = 80.0f;
    public float inputSenstivity = 150.0f;
    public float camX;
    public float camY;
    public float camZ;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    public float rotX = 0.0f;
    public float rotY = 0.0f;*/


   /* void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }*/

    // Update is called once per frame
    /*void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * inputSenstivity * Time.deltaTime;
        rotX += mouseY * inputSenstivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -campAngle, campAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);

        transform.rotation = localRotation;

    }*/

    private void LateUpdate()
    {
        CamUpdate();
    }
    void CamUpdate()
    {
        Transform target = CamFolObj.transform;
        float step = camSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
