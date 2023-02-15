using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerScript : MonoBehaviour
{
    GameObject Player;

    Animator anim;

    public GameObject Prompt;
    public GameObject FailPrompt;

    [SerializeField]
    public bool Opened = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < 2 && !Opened)
        {
            Prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Player.GetComponent<PlayerController>().HasKey)
                {
                    Opened = true;
                    Prompt.SetActive(false);
                    anim.SetBool("LockerOpen", true);
                }

                if (!Player.GetComponent<PlayerController>().HasKey)
                {
                    //show fail prompt for 2 seconds
                    FailPrompt.SetActive(true);
                    StartCoroutine(FailPromptTimer());

                }
            }
        }
        else
        {
            Prompt.SetActive(false);
        }
    }



    IEnumerator FailPromptTimer()
    {
        yield return new WaitForSeconds(2);
        FailPrompt.SetActive(false);
    }
}
