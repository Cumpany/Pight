using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject Canvas;

    Animator anim;

    GameObject Player;

    bool Opened = false;

    public bool Animation2;

    public AudioClip Creak;
    AudioSource audioSource;

    public float Distance = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        Canvas.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < Distance && !Opened)
        {
            Canvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Canvas.SetActive(false);
                Opened = true;
                audioSource.PlayOneShot(Creak);

                if (Animation2)
                {
                    anim.SetBool("DoorOpen2", true);
                }
                else
                {
                    anim.SetBool("DoorOpen", true);
                }
            }
        }
        else
        {
            Canvas.SetActive(false);
        }
    }
}
