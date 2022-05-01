using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayParticals : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;
    void Awake()
    {
        particleSystem.Play();
    }
}
