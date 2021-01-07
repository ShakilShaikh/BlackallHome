using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaby : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private string horizontalInputname;
    [SerializeField] private string verticalInputname;


    public CharacterController cont;
    public Animator anim;
    public Rigidbody rb;

   // public GameObject frontCam;
    //public GameObject tpv;
    public GameObject sword;

    public AudioSource step;
    public AudioSource walk;
    public AudioSource axe;

    private Vector3 rootpos;

    public float life = 100f;
    public float speed = 0.9f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public bool iswalking = false;
    public bool isrun = false;
    public bool jump = false;
    public bool isrunning = false;
    public bool isSword = false;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 moveto = Vector3.up;
    void Start()
    {
        cont = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //frontCam.SetActive(true);
        rootpos = new Vector3(-32.10019f, -0.1199999f, 13.7989f);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isrun != true)
            {
                iswalking = true;
                speed = 6f;
                anim.SetInteger("stat", 1);
            }
            else
            {
                speed = 20;
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
        if (Input.GetKeyDown(KeyCode.A))
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
        }

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
        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //isrun = false;
        //anim.SetBool("run", false);
        //}

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            if (isSword == false)
            {
                isSword = true;
                sword.SetActive(true);
                anim.SetBool("sword", true);
            }
            else
            {
                isSword = false;
                sword.SetActive(false);
                anim.SetBool("sword", false);
                anim.SetInteger("stat", 0);

            }

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            //frontCam.SetActive(false);
            //tpv.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            //frontCam.SetActive(true);
            //tpv.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
            jump = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetTrigger("jump");
            jump = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            //anim.SetBool("aiming", true);
            axeSound();
            anim.SetTrigger("SingleHit");
        }
        if (Input.GetMouseButtonUp(0))
        {
            //anim.SetBool("aiming", false);
        }
        stepSound();
        runSound();
        PlayerMovement();


        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)


        // Move the controller
        //cont.Move(moveDirection * Time.deltaTime);
    }

    void PlayerMovement()
    {
        float horiInput = Input.GetAxis(horizontalInputname) * speed * 0.3f;
        float verInput = Input.GetAxis(verticalInputname) * speed;

        Vector3 forwardMove = transform.forward * verInput;
        Vector3 rightMove = transform.right * horiInput * 2f;
        //Vector3 velocity = transform.up * 9.8f * -20f;
        //Vector3 temp = forwardMove + rightMove + velocity;
        //Debug.Log (temp);
        moveDirection = forwardMove + rightMove;
        if (cont.isGrounded == true && jump == true)
        {
            moveDirection.y = jumpSpeed * 100 * Time.deltaTime;
        }
        if (cont.isGrounded != true)
        {
            // We are grounded, so recalculate

            // moveDirection.y -= gravity * Time.deltaTime;

        }
        cont.SimpleMove(moveDirection);
    }
    void stepSound()
    {
        if (walk.isPlaying == false && iswalking == true && isrun == false && cont.isGrounded == true)
        {
            walk.volume = Random.Range(0.4f, 0.6f);
            walk.pitch = Random.Range(0.8f, 1.1f);
            walk.Play();

        }
    }

    void runSound()
    {
        if (step.isPlaying == false && isrun == true && isrunning == true && cont.isGrounded == true && iswalking == false)
        {
            step.volume = Random.Range(0.4f, 0.6f);
            step.pitch = Random.Range(0.8f, 1.1f);
            step.Play();
        }
    }

    void axeSound()
    {
        if (axe.isPlaying == false)
        {
            axe.Play();
        }
    }

    public void resetPos() {
        gameObject.transform.position = rootpos;
    }
}