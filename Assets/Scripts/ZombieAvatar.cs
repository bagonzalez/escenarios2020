using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAvatar : MonoBehaviour
{
    public float horinzontalMove;
    public float verticalMove;
    public CharacterController zombie;
    public float zombiePlayer;
    public Vector3 zombieInput;
    public Camera mainCamera;
    public Vector3 camForward;
    public Vector3 camRight;
    public Vector3 moveZombie;
    public float gravity = 9.8f;
    public float fallVelocity;

    // Start is called before the first frame update
    void Start()
    {

        zombie = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horinzontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        zombieInput = new Vector3(horinzontalMove, 0, verticalMove);
        zombieInput = Vector3.ClampMagnitude(zombieInput, 1);
        camDirection();
        moveZombie = zombieInput.x * camRight + zombieInput.z * camForward;
        moveZombie = moveZombie * zombiePlayer;
        zombie.transform.LookAt(zombie.transform.position + moveZombie);
        setGravity();
        zombie.Move(moveZombie * Time.deltaTime);
    
    }

    void camDirection(){

        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    
    void setGravity(){

        
        if (zombie.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            moveZombie.y = fallVelocity;
        }else{
           fallVelocity -=gravity * Time.deltaTime;
           moveZombie.y = fallVelocity;
        }
    }

}
