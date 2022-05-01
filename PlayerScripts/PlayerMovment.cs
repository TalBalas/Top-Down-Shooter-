using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] Rigidbody RB;
    [SerializeField] float SpeedMovment;
    [SerializeField] float turnSmoothing;
    public bool IsMoving;
    [SerializeField] GameObject Enemy;
    [SerializeField] Animator anim;
    [SerializeField] Joystick joystick;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }


    void Update()
    {
        // MovmentWithJoystic();
        Movment();
        if (!IsMoving)
        {
            anim.SetBool("ToRun",false);
        }
        else
        {
            anim.SetBool("ToRun", true);
        }
    }
    void MovmentWithJoystic()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3( joystick.Horizontal * 100 , 0,  joystick.Vertical*100).normalized;

        if (direction.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSmoothing * Time.deltaTime);

        }
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            IsMoving = true;
            RB.AddForce(direction * SpeedMovment * Time.deltaTime);

        }
        else
        {
            IsMoving = false;
        }


    }
    void Movment()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
       
        if (direction.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSmoothing * Time.deltaTime);
           
        }
        if (horizontal !=0 || vertical != 0)
        {
            IsMoving = true;
            RB.AddForce(direction * SpeedMovment * Time.deltaTime);
            
        }
        else
        {
            IsMoving = false;
        }
      
        
    }
   
}

