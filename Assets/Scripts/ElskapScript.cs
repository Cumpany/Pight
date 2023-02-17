using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElskapScript : MonoBehaviour
{
    public Animator anim;

    public Animator anim2;

    GameObject Player;

    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;

    public GameObject Canvas;

    public GameObject FailPrompt;
    public GameObject Prompt;

    public AudioClip Steam;

    public bool Opened;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < 4)
        {
            if (!Light1.activeSelf && !Light2.activeSelf && !Light3.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    anim.SetBool("Open", true);
                    Canvas.SetActive(true);
                    Player.GetComponent<PlayerController>().canMove = false;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //show fail prompt for 2 seconds
                    FailPrompt.SetActive(true);
                    Prompt.SetActive(false);
                    StartCoroutine(FailPromptTimer());
                }
            }

            if (Opened || Canvas.activeSelf)
            {
                Prompt.SetActive(!true);
            }
            else
            {
                Prompt.SetActive(true);
            }
        }
        else
        {
            Prompt.SetActive(!true);
        }
    }

    IEnumerator FailPromptTimer()
    {
        yield return new WaitForSeconds(2);
        FailPrompt.SetActive(false);
        Prompt.SetActive(true);
    }

    public void Done()
    {
        GetComponent<AudioSource>().PlayOneShot(Steam);
        Opened = true;
        Canvas.SetActive(false);
        anim2.SetBool("Remove", true);
        Player.GetComponent<PlayerController>().canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
