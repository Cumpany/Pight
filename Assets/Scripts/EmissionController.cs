using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionController : MonoBehaviour
{
    public GameObject Light;
    public GameObject Bulb;
    public GameObject DecoyBulb;
    public bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            Light.SetActive(true);
            Bulb.SetActive(true);
            DecoyBulb.SetActive(false);
        }
        else
        {
            Light.SetActive(false);
            Bulb.SetActive(false);
            DecoyBulb.SetActive(true);
        }
    }
}
