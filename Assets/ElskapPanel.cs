using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElskapPanel : MonoBehaviour
{
    public GameObject BlueHel;
    public GameObject GreenHel;
    public GameObject YellowHel;
    public GameObject RedHel;

    public GameObject BlueKlippt;
    public GameObject GreenKlippt;
    public GameObject YellowKlippt;
    public GameObject RedKlippt;

    public bool Blue = false;
    public bool Green = false;
    public bool Yellow = false;
    public bool Red = false;

    public GameObject Skap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Blue == BlueKlippt.activeSelf && Green == GreenKlippt.activeSelf && Yellow == YellowKlippt.activeSelf && Red == RedKlippt.activeSelf)
        {
            Skap.GetComponent<ElskapScript>().Done();
        }
    }

    public void BlueClicked()
    {
        if (Blue)
        {
            BlueHel.SetActive(false);
            BlueKlippt.SetActive(true);
        }
        else
        {
            ResetWires();
        }
    }

    public void GreenClicked()
    {
        if (Green)
        {
            GreenHel.SetActive(false);
            GreenKlippt.SetActive(true); 
        }
        else
        {
            ResetWires();
        }
    }

    public void YellowClicked()
    {
        if (Yellow) 
        {
            YellowHel.SetActive(false);
            YellowKlippt.SetActive(true);
        }
        else
        {
            ResetWires();
        }
    }

    public void RedClicked()
    {
        if (Red)
        {
            RedHel.SetActive(false);
            RedKlippt.SetActive(true);
        }
        else
        {
            ResetWires();
        }
    }

    void ResetWires()
    {
        BlueHel.SetActive(true);
        GreenHel.SetActive(true);
        YellowHel.SetActive(true);
        RedHel.SetActive(true);

        BlueKlippt.SetActive(false);
        GreenKlippt.SetActive(false);
        YellowKlippt.SetActive(false);
        RedKlippt.SetActive(false);

        gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
