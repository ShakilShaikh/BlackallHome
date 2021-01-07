using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource wood;
    public AudioSource machine;

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
    }*/
    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "door")
        {
            wood.Play();
        }
        if (obj.tag == "machine")
        {
            machine.Play();
        }
        Debug.Log(obj.gameObject.tag);
    }
}
