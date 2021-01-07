using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Shakil : MonoBehaviour
{

    [SerializeField] private string horizontalInputname;
    [SerializeField] private string verticalInputname;


    public Animator anim;
    public CharacterController cont;
    public Transform focusObj;


    public int action = 1;


    public float life = 100f;
    public float speed = 5f;
    public float jumpSpeed = 50.0f;
    public float gravity = 20.0f;
    float next_spawn_time;

    public bool iswalking = false;
    public bool isrun = false;
    public bool jump = false;
    public bool isrunning = false;
    public bool isSword = false;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 moveto = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.W))
        {
            
            //Vector3 target = new Vector3(focusObj.localPosition.x, transform.position.y, focusObj.localPosition.z);

            PlayerRotat2.iswalk = true;
            speed = 2f;
            //Invoke("MakeWalk", 0.5f);
            anim.SetInteger("stat", 1);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            //speed = 2f;
            PlayerRotat2.iswalk = false;
            anim.SetInteger("stat", 0);
        }*/
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerRotat2.iswalk = true;
            
            if (isrun != true)
            {
                iswalking = true;
                speed = 2f;
                anim.SetInteger("stat", 1);
            }
            else
            {
                speed = 10f;
                isrunning = true;
                anim.SetBool("run", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            //speed = 0f;
            iswalking = false;
            isrunning = false;
            anim.SetBool("run", false);
            anim.SetInteger("stat", 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //speed = 0f;
            iswalking = false;
            anim.SetInteger("stat", 2);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            //speed = 0f;
            iswalking = false;
            anim.SetInteger("stat", 0);
        }
       /* if (Input.GetKeyDown(KeyCode.A))
        {
            //speed = 0f;
            iswalking = false;
            anim.SetInteger("stat", 4);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            //speed = 0f;
            iswalking = false;
            anim.SetInteger("stat", 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //speed = 0f;
            iswalking = false;
            anim.SetInteger("stat", 3);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            //speed = 0f;
            iswalking = false;
            anim.SetInteger("stat", 0);
        }*/

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isrun != true)
            {
                isrun = true;
            }
            else
            {
                isrun = false;
            }
            // if (iswalking == false)
            // {

            // anim.SetBool("run", true);
            //}

        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
            jump = true;
            anim.SetInteger("stat", 7865);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetTrigger("jump");
            jump = false;
            anim.SetInteger("stat", 0);
        }
        */
        if (Input.GetMouseButtonDown(0))
        {
            //anim.SetBool("aiming", true);
            //axeSound();
            //anim.SetTrigger("10");
            //anim.SetTrigger("10");
            punch();
        }
        if (Input.GetMouseButtonUp(0))
        {
            //anim.SetInteger("stat", 10);

            //anim.SetBool("aiming", false);

            anim.SetInteger("stat", 0);
        }
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horiInput = Input.GetAxis(horizontalInputname) * speed * 0f;
        float verInput = Input.GetAxis(verticalInputname) * speed * 2f;

        Vector3 forwardMove = transform.forward * verInput;
        Vector3 rightMove = transform.right * horiInput * 2f;
        //Vector3 velocity = transform.up * 9.8f * -20f;
        //Vector3 temp = forwardMove + rightMove + velocity;
        //Debug.Log (temp);
        moveDirection = forwardMove + rightMove;
        if (cont.isGrounded == true && jump == true)
        {
            moveDirection.y = jumpSpeed *120f;
        }
        if (cont.isGrounded != true)
        {
            // We are grounded, so recalculate

             moveDirection.y -= gravity * Time.deltaTime;

        }
        cont.SimpleMove(moveDirection);
    }



    private void focusFace()
    {
        Vector3 target = new Vector3(focusObj.transform.position.x, transform.position.y, focusObj.transform.position.z);
        transform.LookAt(target);

    }
    void MakeWalk() {
        PlayerRotat2.iswalk = true;
        speed = 2f;
    }

    void punch() 
    {
        int n = action % 3;
        Debug.Log(n);
        anim.SetTrigger(n.ToString());
        action++;
    }

}
