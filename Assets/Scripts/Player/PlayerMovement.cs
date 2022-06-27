using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6;
    public int player = 1;
    public GameObject gun;
    Quaternion playerRot;

    string horizontalAxis,verticalAxis,strafe;

    public Animator anim;
    int states = 0;
    void Start() 
    {
        if(gameObject.name == "Player1")
        {
            horizontalAxis = "Horizontal";
            verticalAxis = "Vertical";
            strafe = "Strafe1";
        }   
        if(gameObject.name == "Player2")
        {   
            horizontalAxis = "Horizontal2";
            verticalAxis = "Vertical2";
            strafe = "Strafe2";
        }      
    }
    // Update is called once per frame
    void Update()
    {   
        float horizontal = Input.GetAxisRaw(horizontalAxis);
        float vertical = Input.GetAxisRaw(verticalAxis);
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        anim.SetInteger("State",states);

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            controller.Move(direction * speed * Time.deltaTime);
            states = 1;
        }else{
            states = 0;
        }

        if(Input.GetAxisRaw(strafe) != 0)
        {
           gun.transform.rotation = playerRot;

        }else{
            playerRot = transform.rotation;
            gun.transform.rotation = transform.rotation;
        }
    }
}
