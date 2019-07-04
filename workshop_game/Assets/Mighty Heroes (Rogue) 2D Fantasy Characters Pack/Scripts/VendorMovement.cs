using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class VendorMovement : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed;
    private Rigidbody myRigidBody;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private bool isWatchingRight;

    private int walkDirection;

    /*
        Movimiento - WalkDirection:
        El movimiento en Y es siempre cero.
        En X a la derecha es positivo -
        En Z hacia atras/arriba es positivo - 
        
        Case 0 : Z = 1 x = 0
        Case 1 : Z = 0 X = 1
        Case 2 : Z = -1 X = 0
        Case 3 : Z= 0 X = -1

    */
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        isWatchingRight = true;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    myRigidBody.velocity = new Vector3(0,0,moveSpeed);
                    break;
                case 1:
                    if (!isWatchingRight)
                    {
                        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                        isWatchingRight = true;
                    }
                    myRigidBody.velocity = new Vector3(moveSpeed, 0,0);
                    break;
                case 2:
                    myRigidBody.velocity = new Vector3(0, 0,-moveSpeed);
                    break;
                case 3:
                    if (isWatchingRight)
                    {
                        gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                        isWatchingRight = false;
                    }
                    gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                    myRigidBody.velocity = new Vector3(-moveSpeed, 0,0);
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                Idle();
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector3.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }

        }
    }

    public void ChooseDirection() {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
        Walk();
    }

    public void Walk() { animator.Play("Rogue_walk_01"); }
    public void Idle() { animator.Play("Rogue_idle_01"); }


    
}
