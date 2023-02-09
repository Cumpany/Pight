using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject Canvas;

    Animator anim;

    GameObject Player;

    bool Opened = false;
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
        if (Vector3.Distance(Player.transform.position, transform.position) < 2 && !Opened)
        {
            Canvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("DoorOpen", true);
                Canvas.SetActive(false);
                Opened = true;
            }
        }
        else
        {
            Canvas.SetActive(false);
        }      
    }
}
