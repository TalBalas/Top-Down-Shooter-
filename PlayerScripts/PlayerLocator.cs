using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocator : MonoBehaviour
{
    public static PlayerLocator Instance;
    void Awake()
    {
        Instance = this;
    }
   
}
