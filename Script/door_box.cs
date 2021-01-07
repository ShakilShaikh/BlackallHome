using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_box : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ui;
    public GameObject gate;
    public GameObject knob1;
    public GameObject knob2;
    public GameObject mirror;
    public GameObject plate;
    public GameObject port2;

    public AudioSource d;
    public AudioSource c;
    public static bool isui = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isui==true)
        {
            gate.SetActive(false);
            knob1.SetActive(false);
            knob2.SetActive(false);
            plate.SetActive(false);
            mirror.SetActive(false);
            port2.SetActive(false);
            c.Play();
            Invoke("closeDoor", 3f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.SetActive(true);
            isui = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.SetActive(false);
            isui = false;
        }
    }
    void closeDoor() 
    {
        gate.SetActive(true);
        knob1.SetActive(true);
        knob2.SetActive(true);
        plate.SetActive(true);
        mirror.SetActive(true);
        port2.SetActive(true);
        d.Play();
    }
}
