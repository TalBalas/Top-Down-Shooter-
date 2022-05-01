using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullets : MonoBehaviour
{
    [SerializeField] float Speed;
    void FixedUpdate()
    {
        BulletForce();
       
    }
    public void BulletForce()
    {
        transform.position = transform.position + transform.forward * Speed * Time.fixedDeltaTime;

    }
}
