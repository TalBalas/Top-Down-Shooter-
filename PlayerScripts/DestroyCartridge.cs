using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCartridge : MonoBehaviour
{
   
    void Start()
    {
        Destroy(this.gameObject, 2);
    }

    
}
