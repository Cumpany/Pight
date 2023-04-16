using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionController : MonoBehaviour
{
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Bulb;
    //public bool isOn = false;
    public bool Light1On = false;
    public bool Light2On = false;

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

        if (Light1On)
        {
            Light1.SetActive(true);
        }
        else
        {
            Light1.SetActive(false);
        }
        if (Light2On)
        {
            Light2.SetActive(true);
        }
        else
        {
            Light2.SetActive(false);
        }
        //if (isOn)
        //{
        //    Light.SetActive(true);
        //    Bulb.SetActive(true);
        //    DecoyBulb.SetActive(false);
        //}
        //else
        //{
        //    Light.SetActive(false);
        //    Bulb.SetActive(false);
        //    DecoyBulb.SetActive(true);
        //}
    }
}
