using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject space1;
    public GameObject space2;
    //public GameObject player;

    public GameObject ui;

    public GameObject player1;
    public GameObject player2;

    public static bool isui = false;
    public static bool tele = false;


     void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isui==false) {
            space1.SetActive(false);
            space2.SetActive(true);
            //tele = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.SetActive(true);
            isui = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.SetActive(false);
            isui = false;
        }
    }

}
