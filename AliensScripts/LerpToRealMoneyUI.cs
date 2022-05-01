using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpToRealMoneyUI : MonoBehaviour
{
    [SerializeField] float Speed;
      GameObject cam;
    void OnEnable()
    {
        cam = GameObject.FindWithTag("MainCamera");
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerLocator.Instance.transform.position, Time.deltaTime * Speed);

        transform.LookAt(cam.transform.position);
        if (transform.position == PlayerLocator.Instance.transform.position)
        {

            Destroy(this.gameObject);

        }
        Speed += Time.deltaTime * Speed;
    }
   
}
