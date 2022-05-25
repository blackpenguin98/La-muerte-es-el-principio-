using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float speed = 5;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float rollSpeed = 10;

    public Transform cam;

    public CharacterController controller;

    public LayerMask isGround;
    bool isGrounded;
    public Transform groundCheck;

    public Animator anim;

    bool isAttaking;
    public bool isRoling;

    public GameObject spear;

    bool restoringStamina;
    float waitingTimeS = 4f;
    float timePassedS = 0;
    bool cauntingtime;

    int attackAnimN = 0;

    public bool trowing;

    bool onceT;

    public AudioSource spearhit, spearhit2;

    Vector3 tDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxisRaw("Horizontal") != 0 && !trowing || Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxisRaw("Vertical") != 0 && !trowing )
        {
            if(GetComponent<stats>().stamina >= 2000)
            {
                anim.SetTrigger("roll");
                isRoling = true;
                GetComponent<stats>().stamina -= 2000;
                restoringStamina = false;
                cauntingtime = true;
                timePassedS = 0;
                //StartCoroutine(restoreStamina());
            }
            
           
        }

        if (isRoling)
        {
           
            transform.Translate(transform.worldToLocalMatrix.MultiplyVector(transform.forward) * Time.deltaTime * rollSpeed);
            spear.SetActive(false);
        }
        else
        {
            spear.SetActive(true);
        }

        if (cauntingtime)
        {
            timePassedS += Time.deltaTime;
        }

        if (timePassedS >= waitingTimeS)
        {
            restoringStamina = true;
            cauntingtime = false;
            timePassedS = 0;
        }


        if (restoringStamina)
        {
            GetComponent<stats>().stamina += 8;
        }


        if (isAttaking)
        {
            horizontal = 0;
            vertical = 0;
        }

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetBool("isWalking", true);
        }else
        {
            anim.SetBool("isWalking", false);
        }

        



        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f && !trowing)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, .2f);

        if (isGrounded)
        {
            Debug.Log("piso");
        }
        else
        {
            transform.Translate(new Vector3(0, -9.81f, 0) * Time.deltaTime);

        }


        if (Input.GetButtonDown("Fire1") && GetComponent<stats>().stamina >= 1000 && !trowing)
        {
            isAttaking = true;
            StartCoroutine(enableWalking());
            GetComponent<stats>().stamina -= 1000;
            restoringStamina = false;
            cauntingtime = true;
            timePassedS = 0;

            if (attackAnimN == 0)
            {
                anim.SetTrigger("attack");
                attackAnimN = 1;
                //spearhit.Play();
            } else if( attackAnimN == 1)
            {
                //spearhit2.Play();
                anim.SetTrigger("attack2");
                attackAnimN = 0;
            }


        }

        Debug.Log(trowing);

        if (trowing)
        {
            
            transform.Translate(tDirection * Time.deltaTime * 800);

            if (!onceT)
            {
                onceT = true;
                StartCoroutine(stopTrow());
            }
        }


    }


    IEnumerator enableWalking()
    {
        yield return new WaitForSeconds(1.6f);
        isAttaking = false;
        GameObject.Find("spear:pCylinder3").GetComponent<spear>().hasDamaged = false;
    }

    public void blood()
    {
        Debug.Log("blood");
    }


    IEnumerator restoreStamina()
    {
        yield return new WaitForSeconds(4f);
        restoringStamina = true;

    }


    public void TrollTrow(Vector3 direction)
    {
        tDirection = direction;
    }


    IEnumerator stopTrow()
    {
        yield return new WaitForSeconds(1.2f);
        trowing = false;
        onceT = false;

        
    }


}
