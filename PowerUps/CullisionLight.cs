using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullisionLight : MonoBehaviour
{
     ParticleSystem part;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
       // if (other.tag == "Player")
            Debug.Log(other.tag);
    }
}
