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

    public AudioClip cut;

    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Blue == BlueKlippt.activeSelf && Green == GreenKlippt.activeSelf && Yellow == YellowKlippt.activeSelf && Red == RedKlippt.activeSelf)
        {
            Skap.GetComponent<ElskapScript>().Done();
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetWires();
        }

        if (gameObject.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void BlueClicked()
    {
        if (Blue)
        {
            Skap.GetComponent<AudioSource>().PlayOneShot(cut);
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
            Skap.GetComponent<AudioSource>().PlayOneShot(cut);
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
            Skap.GetComponent<AudioSource>().PlayOneShot(cut);
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
            Skap.GetComponent<AudioSource>().PlayOneShot(cut);
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

        Player.GetComponent<PlayerController>().canMove = true;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
