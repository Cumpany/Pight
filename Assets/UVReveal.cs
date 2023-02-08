using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UVReveal : MonoBehaviour
{

    public Material material;
    public Light spotlight;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        material.SetVector("_LightPosition", spotlight.transform.position);
        material.SetVector("_LightDirection", -spotlight.transform.forward);
        material.SetFloat("_LightAngle", spotlight.spotAngle);
    }
}