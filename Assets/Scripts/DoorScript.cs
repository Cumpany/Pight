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
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < 2.5 && !Opened)
        {
            Debug.Log("close");
            Canvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Canvas.SetActive(false);
                Opened = true;

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
