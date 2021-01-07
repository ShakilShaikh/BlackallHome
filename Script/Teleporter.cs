using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform pos;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            transform.position = pos.position;
        }
    }
}
