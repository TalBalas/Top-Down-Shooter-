using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate3Dobjects : MonoBehaviour
{
    public float speed;
  //  Vector2 lastMousePosition;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetMouseButton(0))
        {


            Vector2 mouseChange = lastMousePosition - (Vector2)Input.mousePosition;

            transform.Rotate(mouseChange.y * speed, 0, mouseChange.x * speed);


        }
        else
        {

            transform.rotation = Quaternion.Euler(0, 90, 0);

        }*/

       // lastMousePosition = Input.mousePosition;
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
