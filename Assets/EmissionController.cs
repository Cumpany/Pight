using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionController : MonoBehaviour
{
    public GameObject Light;
    public GameObject EmissiveObject;
    float EmissiveIntensity;
    
    public float Intensity;
    // Start is called before the first frame update
    void Start()
    {
        EmissiveIntensity = EmissiveObject.GetComponent<Renderer>().material.GetFloat("_EmissionIntensity");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(EmissiveIntensity);
        Light.GetComponent<Light>().intensity = Intensity;
    }
}
