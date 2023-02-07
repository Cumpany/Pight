using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    public GameObject Spotlight;
    public int MouseButton = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton))
        {
            Spotlight.SetActive(!Spotlight.activeSelf);
        }
    }
}
