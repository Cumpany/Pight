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
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(Player.transform.position, transform.position) < 4)
        {
            if (!Light1.activeSelf && !Light2.activeSelf && !Light3.activeSelf)
            {
                anim.SetBool("Open", true);
                Canvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                //show fail prompt for 2 seconds
                FailPrompt.SetActive(true);
                StartCoroutine(FailPromptTimer());

            }
        }
    }

    IEnumerator FailPromptTimer()
    {
        yield return new WaitForSeconds(2);
        FailPrompt.SetActive(false);
    }

    public void Done() 
    {
        Canvas.SetActive(false);
        anim2.SetBool("Remove", true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
