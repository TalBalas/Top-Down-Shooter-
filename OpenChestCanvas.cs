using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestCanvas : MonoBehaviour
{
    [SerializeField] GameObject UICanvas;
    [SerializeField] GameObject UIOpenChestCanvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            UICanvas.SetActive(false);
            UIOpenChestCanvas.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            UICanvas.SetActive(true);
            UIOpenChestCanvas.SetActive(false);
        }
    }
}
