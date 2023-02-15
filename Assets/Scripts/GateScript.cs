using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    GameObject Player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < 10)
        {
            anim.SetBool("Open", true);
        }
    }
}
