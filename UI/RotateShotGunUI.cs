using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShotGunUI : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Vector3 offset;
    void Update()
    {
    
        UpANDdown();
    }
    void UpANDdown()
    {
        float x = transform.position.x;
        float y = Mathf.Sin(Time.time) * Speed + offset.y;
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
