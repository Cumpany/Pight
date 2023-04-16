using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject endScreen;

    public GameObject One;
    public GameObject Two;
    public GameObject Three;

    public AudioClip Splash;
    public AudioClip Glass;

    bool OneActive;
    bool TwoActive;
    bool ThreeActive;

    bool hasEnded;

    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
        Player = GameObject.Find("Player");
        hasEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        OneActive = One.GetComponent<ElskapScript>().Opened;
        TwoActive = Two.GetComponent<ElskapScript>().Opened;
        ThreeActive = Three.GetComponent<ElskapScript>().Opened;

        if (OneActive && TwoActive && ThreeActive)
        {
            if (!hasEnded)
            {
                GetComponent<AudioSource>().PlayOneShot(Splash);
                GetComponent<AudioSource>().PlayOneShot(Glass);
                endScreen.SetActive(true);
                Player.GetComponent<PlayerController>().canMove = false;
                Cursor.lockState = CursorLockMode.None;
            }
            hasEnded = true;
        }
    }
}
