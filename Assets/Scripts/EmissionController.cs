using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionController : MonoBehaviour
{
    public GameObject Light;
    public GameObject Bulb;
    public GameObject DecoyBulb;
    public bool isOn = false;

    public GameObject Tank1;
    public GameObject Tank2;
    public GameObject Tank3;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Tank1.activeSelf && !Tank2.activeSelf && !Tank3.activeSelf)
        {
            anim.SetBool("StartFlash", true);
        }


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
