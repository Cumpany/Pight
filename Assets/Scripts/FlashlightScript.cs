using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    public GameObject Spotlight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if left mouse button is clicked toggle spotlight on and off
        if (Input.GetMouseButtonDown(0))
        {
            Spotlight.SetActive(!Spotlight.activeSelf);
        }
    }
}
