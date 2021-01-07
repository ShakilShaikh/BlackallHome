using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColl : MonoBehaviour
{
    // Start is called before the first frame update
    public float minDist = 1.0f;
    public float maxDist = 4.0f;
    public float smooth = 10.0f;
    public float dist;

    public Vector3 dollyAdj;
    Vector3 dollyDir;

    private void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        dist = transform.localPosition.magnitude;
    }
    void Update()
    {
        Vector3 wantedCam = transform.parent.TransformPoint(dollyDir * maxDist);
        RaycastHit hit;
        if(Physics.Linecast(transform.parent.position,wantedCam, out hit))
        //if(Physics.Raycast(transform.position,transform.forward, out hit))
        {
            dist = Mathf.Clamp((hit.distance*0.9f), minDist, maxDist);

        }else 
        {
            dist = maxDist;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * dist, Time.deltaTime * smooth);
    }


}
